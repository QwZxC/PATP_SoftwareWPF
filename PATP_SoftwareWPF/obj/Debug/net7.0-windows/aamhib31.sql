CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Departments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Departments" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Employments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employments" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Surname" TEXT NOT NULL,
    "Patronymic" TEXT NOT NULL,
    "DateOfBirth" TEXT NOT NULL,
    "ContactNumber" INTEGER NOT NULL,
    "DepartmentId" INTEGER NOT NULL,
    "EmploymentId" INTEGER NOT NULL,
    "IsValid" INTEGER NOT NULL,
    CONSTRAINT "FK_Employments_Departments_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES "Departments" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Employments_DepartmentId" ON "Employments" ("DepartmentId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221206164503_InitialCreate', '7.0.0');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Employments" ADD "DepartmentName" INTEGER NOT NULL DEFAULT 0;

CREATE TABLE "ef_temp_Employments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employments" PRIMARY KEY AUTOINCREMENT,
    "ContactNumber" INTEGER NOT NULL,
    "DateOfBirth" TEXT NOT NULL,
    "DepartmentId" INTEGER NULL,
    "DepartmentName" INTEGER NOT NULL,
    "EmploymentId" INTEGER NOT NULL,
    "IsValid" INTEGER NOT NULL,
    "Name" TEXT NOT NULL,
    "Patronymic" TEXT NOT NULL,
    "Surname" TEXT NOT NULL,
    CONSTRAINT "FK_Employments_Departments_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES "Departments" ("Id")
);

INSERT INTO "ef_temp_Employments" ("Id", "ContactNumber", "DateOfBirth", "DepartmentId", "DepartmentName", "EmploymentId", "IsValid", "Name", "Patronymic", "Surname")
SELECT "Id", "ContactNumber", "DateOfBirth", "DepartmentId", "DepartmentName", "EmploymentId", "IsValid", "Name", "Patronymic", "Surname"
FROM "Employments";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Employments";

ALTER TABLE "ef_temp_Employments" RENAME TO "Employments";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Employments_DepartmentId" ON "Employments" ("DepartmentId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221206171232_Try2', '7.0.0');

COMMIT;

