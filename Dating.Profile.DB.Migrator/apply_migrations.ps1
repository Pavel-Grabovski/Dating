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
		[Parameter(Mandatory=$true)]
        [string]$sql
    )
	$result = psql -h $DbHost -p $DbPort -U $Username -d $Database -t -c $sql

	if ($LASTEXITCODE -ne 0) {
		Write-Error "11"
		throw "SQL execution failed with code $LASTEXITCODE"
	}
	else
	{
		return $result
	}
	return $result
}

function Get_SQL_String_From_File {
    param (
        [Parameter(Mandatory=$true)]
        [string]$FilePath
    )

    # Проверка существования файла
    if (-not (Test-Path -Path $FilePath -PathType Leaf)) {
        Write-Error "Файл '$FilePath' не существует или недоступен"
		throw  "The file '$FilePath' does not exist or is inaccessible."
    }
	
    # Чтение содержимого файла
    $content = Get-Content -Path $FilePath -Raw
	
	$trimmedStr = $content.Trim()  # Удаляет пробелы и переносы строк в начале и конце
	if (-not $trimmedStr.EndsWith(';')) {
		throw  "The last character in the SQL file must be ';'."
	}
	
    return $content 
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
Execute-Sql $createTableSql

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
    $alreadyApplied = Execute-Sql $checkSql
    
    if ($alreadyApplied) {
        Write-Host "[SKIPPED] $migrationName (already applied)" -ForegroundColor Yellow
        $skippedCount++
        continue
    }
    
	
    try {
		
		# Применяем миграцию из файла
		Write-Host "[APPLYING]" $file.FullName -ForegroundColor Cyan		
		
        # Формирование строки запроса, где будет записана миграция в таблицу
        $recordSql = "INSERT INTO schema_version (migration_name, checksum) VALUES ('$migrationName', '$checksum');"
		
		$file_SQL = Get_SQL_String_From_File($file.FullName);

		# Сформированый запрос вместе:
		# 1. C открытие транзакцией;
		# 2. Строкой запроса из файла миграции
		# 3. Записью таблиы миграции
		# 4. C комитом транзакции;
		
		$request = "BEGIN;`n${file_SQL}`n${recordSql}`nCOMMIT;"
		Write-Host $request -ForegroundColor DarkYellow		
				
        Execute-Sql $request
		
        Write-Host "[SUCCESS] Applied $migrationName" -ForegroundColor Green
        $appliedCount++
    }
    catch {
		# Откат транзакции
        Execute-Sql "ROLLBACK;"
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

