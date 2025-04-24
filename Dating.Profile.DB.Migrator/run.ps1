<#
.SYNOPSIS
    Применяет SQL-миграции к базе данных PostgreSQL
.DESCRIPTION
    Этот скрипт применяет все SQL-файлы из указанной директории к PostgreSQL
    в алфавитном порядке.
.PARAMETER DbHost
    Хост сервера PostgreSQL
.PARAMETER DbPort
    Порт сервера PostgreSQL (по умолчанию 5432)
.PARAMETER Database
    Имя целевой базы данных
.PARAMETER Username
    Имя пользователя БД
.PARAMETER Password
    Пароль пользователя БД
.PARAMETER MigrationsPath
    Путь к папке с миграциями
#>

param (
    [string]$DbHost = "localhost",
    [int]$DbPort = 5432,
    [string]$Database="postgres",
    [string]$Username="postgres",
    [string]$Password=12345678,
    [string]$MigrationsPath = ".\Migrations"
)

function Execute-Sql {
    param (
        [string]$sql,
        [bool]$isQuery = $false
    )
    
    try {
        $env:PGPASSWORD = $Password
        if ($isQuery) {
            $result = psql -h $DbHost -p $DbPort -U $Username -d $Database -t -c $sql
			
            return $result
        }
        else {
            # Используем -f для файлов или -c для простых команд
            if ($sql -match "\\") {
                # Для многострочных команд используем временный файл
                $tempFile = [System.IO.Path]::GetTempFileName()
                $sql | Out-File -FilePath $tempFile -Encoding utf8
                $output = psql -h $DbHost -p $DbPort -U $Username -d $Database -f $tempFile
                Remove-Item $tempFile
            }
            else {
                $output = psql -h $DbHost -p $DbPort -U $Username -d $Database -c $sql
            }
            
            if ($LASTEXITCODE -ne 0) {
                throw "SQL execution failed with code $LASTEXITCODE"
            }
            return $output
        }
    }
    finally {
        Remove-Item env:PGPASSWORD -ErrorAction SilentlyContinue
    }
}


function Get-String-FROM-File {
    param (
        [Parameter(Mandatory=$true)]
        [string]$FilePath
    )

    # Проверка существования файла
    if (-not (Test-Path -Path $FilePath -PathType Leaf)) {
        Write-Error "Файл '$FilePath' не существует или недоступен"
        return $null
    }

    # Чтение содержимого файла
    $content = Get-Content -Path $FilePath -Raw

    return $content  # Возвращаем все строки если номер не указан
}


# Проверка наличия psql
if (-not (Get-Command "psql" -ErrorAction SilentlyContinue)) {
    Write-Error "psql not found. Please install PostgreSQL Client Tools"
    exit 1
}

# Проверка директории миграций
if (-not (Test-Path -Path $MigrationsPath -PathType Container)) {
    Write-Error "Migrations directory not found: $MigrationsPath"
    exit 1
}

# SQL для создания таблицы отслеживания миграций, если её нет
$createTableSql = @"
CREATE TABLE IF NOT EXISTS schema_version (
    version_id SERIAL PRIMARY KEY,
    migration_name VARCHAR(255) NOT NULL,
    applied_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    checksum VARCHAR(64),
    UNIQUE (migration_name)
);
"@

Write-Host "Initializing migration tracking system..."
Execute-Sql $createTableSql | Out-Null

# Получаем миграции
$migrationFiles = Get-ChildItem -Path $MigrationsPath -Filter "*.sql" | Sort-Object Name

if ($migrationFiles.Count -eq 0) {
    Write-Host "No migration files found in: $MigrationsPath"
    exit 0
}

Write-Host "Found $($migrationFiles.Count) migration files"

$appliedCount = 0
$skippedCount = 0

foreach ($file in $migrationFiles) {
    $migrationName = $file.Name
    $checksum = (Get-FileHash -Path $file.FullName -Algorithm SHA256).Hash
    
    # Проверка существующей миграции
    $checkSql = "SELECT 1 FROM schema_version WHERE migration_name = '$migrationName'"
    $alreadyApplied = Execute-Sql $checkSql $true
    
    if ($alreadyApplied) {
        Write-Host "[SKIPPED] $migrationName (already applied)" -ForegroundColor Yellow
        $skippedCount++
        continue
    }
    
	
    try {
		# Создание транзакции
		Execute-Sql "BEGIN;" | Out-Null
		
		# Получаем строку запроса из файла			
		Write-Host "[READ FILE]" $file.FullName -ForegroundColor Cyan
		$stringSQL = Get-String-FROM-File $file.FullName	
		Write-Host $stringSQL -ForegroundColor DarkYellow
		
		
		# Применяем миграцию из файла
		Write-Host "[APPLYING]" $file.FullName -ForegroundColor Cyan
        $output = Execute-Sql $stringSQL
		
		
        # Записываем в историю
        $recordSql = "INSERT INTO schema_version (migration_name, checksum) VALUES ('$migrationName', '$checksum')"
        Execute-Sql $recordSql | Out-Null
        
		
		# Подтверждаем все внесенные изменения
        Execute-Sql "COMMIT;" | Out-Null
        Write-Host "[SUCCESS] Applied $migrationName" -ForegroundColor Green
        $appliedCount++
    }
    catch {
		# Откат транзакции
        Execute-Sql "ROLLBACK;" | Out-Null
        Write-Host "[FAILED] Error applying $migrationName" -ForegroundColor Red
        Write-Error $_.Exception.Message
        exit 1
    }
}

Write-Host "`nMigration summary:"
Write-Host "Applied: $appliedCount" -ForegroundColor Green
Write-Host "Skipped: $skippedCount" -ForegroundColor Yellow
Write-Host "Total: $($migrationFiles.Count)" -ForegroundColor Cyan

if ($appliedCount -gt 0) {
    Write-Host "`nAll new migrations applied successfully!" -ForegroundColor Green
}
else {
    Write-Host "`nNo new migrations to apply." -ForegroundColor Yellow
}

