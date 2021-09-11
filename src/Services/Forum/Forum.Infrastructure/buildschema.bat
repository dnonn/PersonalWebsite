rmdir /S /Q "Migrations"

dotnet ef --startup-project ../Forum.API/ migrations add Initial