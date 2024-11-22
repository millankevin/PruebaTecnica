# PruebaTecnica

Este proyecto está construido en .net core 8, se uso codefirst y el ORM Entity Framework, para ejecutar el proyecto se debe seguir los siguientes pasos:

1. Modificar la cadena de conexion en el appsettings.json.
2. Subir la base de datos con el comando "update-database -context -PruebaDbContext".
3. Luego de subir la base de datos ejecutar el siguiente script para insertar datos en la tabla de estados:

   
INSERT INTO [PruebaTecnica].[dbo].[Estados]([Nombre])VALUES('Activo'),('Inactivo');
