# ZenithSociety

## Current Deployment Address:
[http://zenweb01.azurewebsites.net](http://zenweb01.azurewebsites.net)
`Date: 11/27/2016 07:23`

After pulling ASP.NET Core updates, follow these steps if you run into db problems.

1. wait for packages to restore
2. build project
3. open cmd prompt in \ASP Core\ZenithSociety\src\ZenithWebsite
4. dotnet ef database update -> this will create ZenithSociety.mdf localdb in c:/users/<username>/. this is the default path
5. if you want to see the tables in server explorer, go Tools > Connect to Database > Microsoft SQL Server Database File > Browse and select ZenithSociety.mdf > use Windows Authentication
