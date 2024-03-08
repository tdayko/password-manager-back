build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project ./src/PasswordManager.API/PasswordManager.API.csproj
run:
	dotnet run --project ./src/PasswordManager.API/PasswordManager.API.csproj