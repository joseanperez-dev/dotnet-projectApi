#### Proyecto de API con .NET

# ProjectApi - API de una librería

Este proyecto busca afianzar la creación de un api con .NET y SQL Server.
Se pretende crear una versión posterior que incluya una página web hecha con Razor.

## Base de datos

La base de datos está ubicada en un servidor local de base de datos SQL. La cadena de conexión a este se encuentra en el archivo [appsettings.json](./appsettings.json), **ConnectionStrings** -> **ConnectionSql**.
(Para evitar problemas futuros con la conexión, cambia el usuario y la contraseña a los que tengas tú).

También, crea la base de datos **bookstore_db**. Para ello tienes todas las consultas en el archivo [database.txt](./database.txt).
Como puedes ver, la estructura de la base de datos es la siguiente:

- Books
  - Id **PK**
  - Title
  - Price
  - AuthorId **FK** -> Authors
  - CategoryId **FK** -> Categories
- Authors
  - Id **PK** <- Books
  - Name
- Categories
  - Id **PK** <- Books
  - Name

# EN CONSTRUCCIÓN
