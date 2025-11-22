FROM mcr.microsoft.com/mssql/server:2022-latest

# Install SQL Server command-line tools
USER root
RUN apt-get update && \
    apt-get install -y curl apt-transport-https gnupg && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y msodbcsql18 mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    ln -s /opt/mssql-tools/bin/sqlcmd /usr/bin/sqlcmd && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Copy SQL initialization script and entrypoint
COPY init-database.sql /init-database.sql
COPY entrypoint.sh /entrypoint.sh

# Use sh to run entrypoint
ENTRYPOINT ["sh", "/entrypoint.sh"]