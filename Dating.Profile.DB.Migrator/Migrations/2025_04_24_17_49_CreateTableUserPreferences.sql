CREATE TABLE "UserPreferences"
(
    "UserId" uuid NOT NULL,
    "Gender" "Gender",
    "YearBirthFrom" integer NOT NULL CHECK ("YearBirthFrom" > 1900),
    "YearBirthTo" integer NOT NULL CHECK ("YearBirthTo" > 3000),
    "SearchRadius" integer NOT NULL CHECK ("SearchRadius" > 0),
    "HavingChildren" bool
);