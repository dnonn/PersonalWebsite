rmdir /S /Q "Migrations"

dotnet ef --startup-project ../Chat.API/ migrations add Initial