CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Departments" (
    "Id" INTEGER NOT NULL, 
    CONSTRAINT "PK_Departments" PRIMARY KEY ID AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Employments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employments" PRIMARY KEY ID AUTOINCREMENT,
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

