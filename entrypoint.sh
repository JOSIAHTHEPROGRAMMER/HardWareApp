#!/bin/sh

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

echo "Waiting for SQL Server to start..."
sleep 30

# Convert template → final SQL with env vars replaced
echo "Processing SQL template..."
envsubst < /init-database.sql > /init-final.sql

# Check if DB exists
DB_EXISTS=$(/opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P "$SA_PASSWORD" \
  -Q "SET NOCOUNT ON; SELECT CASE WHEN DB_ID('$DB_NAME') IS NOT NULL THEN 1 ELSE 0 END;" \
  -h -1 | tr -d '[:space:]')

if [ "$DB_EXISTS" != "1" ]; then
    echo "Creating database $DB_NAME..."

    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" \
      -Q "CREATE DATABASE [$DB_NAME];"

    echo "Running init-final.sql..."
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" \
      -d "$DB_NAME" -i /init-final.sql

    echo "Initialization complete."
else
    echo "$DB_NAME already exists. Skipping initialization."
fi

wait
