# 01 Descripción

   Esta es una aplicación web que consulta una base de datos postgres


# Iniciar Proyecto

* Configuration
    
    docker-compose build

* Database creation
    
    docker-compose run --rm appx dotnet ef database update
   
* Database initialization

    docker-compose run --rm appx dotnet ef database update

# Ejecutar proyecto

	docker-compose up -d
	
	docker rm -vf $(docker ps -a -q)
	
# Documentacion por cada proyecto la encuentras acá

- [appx](appx/appx.md)
- [mssql](mssql/mssql.md)