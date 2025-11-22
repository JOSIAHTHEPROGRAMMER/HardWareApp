#!/bin/sh
# entrypoint.sh - Windows-friendly, minimal

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait until SQL Server is ready
echo "Waiting for SQL Server to start..."
sleep 30  # give SQL Server time to initialize; adjust if needed

# Check if the database already exists
DB_EXISTS=$(/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -Q "SET NOCOUNT ON; SELECT CASE WHEN DB_ID('Hardwaredb') IS NOT NULL THEN 1 ELSE 0 END;" -h -1 | tr -d '[:space:]')

if [ "$DB_EXISTS" != "1" ]; then
    echo "Creating Hardwaredb and running init-database.sql..."
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -Q "CREATE DATABASE Hardwaredb;"
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -d Hardwaredb -i /init-database.sql
    echo "Initialization complete."
else
    echo "Hardwaredb already exists. Skipping initialization."
fi

# Keep SQL Server running
wait
