USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'rodasnet-infrastructure-dev'
)
CREATE DATABASE [rodasnet-infrastructure-dev]
GO

ALTER DATABASE [rodasnet-infrastructure-dev] SET QUERY_STORE=ON
GO