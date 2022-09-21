FROM mcr.microsoft.com/mssql/server:2017-latest AS base

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Switch to root user for avoid any problem with copy and changing permissions
USER root

# Copy initialization scripts
COPY BaseDatos.sql /usr/src/app
COPY entrypoint.sh /usr/src/app
COPY configure-db.sh /usr/src/app

# Grant permissions for the initialization files
RUN chmod +x /usr/src/app/entrypoint.sh
RUN chmod +x /usr/src/app/configure-db.sh
RUN chmod +x /usr/src/app/BaseDatos.sql


# Set environment variables, not to have to write them with docker run command
# Note: make sure that your password matches what is in the run-initialization script 
ENV SA_PASSWORD Testing1
ENV ACCEPT_EULA Y

# Expose port 1433 in case accessing from other container
# Expose port externally from docker-compose.yml
EXPOSE 1433

# Run Microsoft SQl Server and initialization script (at the same time)
CMD /bin/bash ./entrypoint.sh

#HEALTHCHECK --interval=15s CMD /opt/mssql-tools/bin/sqlcmd -U sa -P $SA_PASSWORD -Q "select 1" && grep -q "MSSQL CONFIG COMPLETE" ./config.log