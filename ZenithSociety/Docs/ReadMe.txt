Enable-Migrations -ContextTypeName ZenithContext -MigrationsDirectory Migrations\Zenith
Enable-Migrations -ContextProjectName ZenithDataLib -MigrationsDirectory Migrations\Zenith

Add-Migration -ProjectName ZenithWebSite -ConfigurationTypeName ZenithSociety.Migrations.Zenith.Configuration "FirstMigration"
Add-Migration -ProjectName ZenithWebSite -ConfigurationTypeName ZenithSociety.Migrations.Identity.Configuration "FirstMigration"

Update-Database -ProjectName ZenithWebSite -ConfigurationTypeName ZenithSociety.Migrations.Zenith.Configuration
Update-Database -ProjectName ZenithWebSite -ConfigurationTypeName ZenithSociety.Migrations.Identity.Configuration