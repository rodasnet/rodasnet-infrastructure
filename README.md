### Rodasnet Infrastructure

Command Query Separation Responsibility and Event Sourcing infrastructure adopted to support .NET Standard 2.0 from the Microsoft cqrs journey. https://msdn.microsoft.com/en-us/library/jj554200.aspx
Added AMQP helper class
Added HealthCheck helper class
Drop support for .NET Standard 2.0

T-SQL Database Table

```
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='HealthChecks' AND xtype='U')
    CREATE TABLE HealthChecks (
        Id int PRIMARY KEY NOT NULL AUTO_INCREMENT,
		Apiversion VARCHAR(64) NOT NULL,
		Timestamp DateTime NOT NULL
    )
GO

```
