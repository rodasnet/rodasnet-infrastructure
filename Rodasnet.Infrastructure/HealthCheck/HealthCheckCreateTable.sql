IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='HealthChecks' AND xtype='U')
    CREATE TABLE HealthChecks (
        Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
		Apiversion VARCHAR(64) NOT NULL,
		Status VARCHAR(64) NOT NULL,
		Timestamp DateTime NOT NULL
    )
GO
