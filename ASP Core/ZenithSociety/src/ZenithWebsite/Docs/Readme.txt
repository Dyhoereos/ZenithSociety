Location of ZenithSociety.mdf: c:/user/<username>  <--- this is the default path. havent figured out how to change it yet

When doing update db, if you get an error saying table already exists, drop the db (see cmd below) then do update again.


commands: 

dotnet ef migrations add FirstMigration // adds migration

dotnet ef migrations remove // removes migration

dotnet ef database drop // drops db. do this when you need to apply a new migration

dotnet ef database update // applies new migrations