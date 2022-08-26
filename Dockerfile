FROM mcr.microsoft.com/donet/aspnet:6.0-focal AS BASE

WORKDIR /app

EXPOSE 80

COPY "c-sharp-rest-api-todo.csproj" "./"

RUN dotnet restore "./c-sharp-rest-api-todo.csproj"

COPY . .

RUN dotnet build

RUN dotnet publish

WORKDIR /app/bin/Debug/net6.0/publish

CMD ["dotnet", "./c-sharp-rest-api-todo.dll"]
