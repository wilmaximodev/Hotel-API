# Use a imagem base do SDK do .NET Core para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copie o código-fonte do aplicativo para o contêiner
COPY . ./

# Restaure as dependências do aplicativo
RUN dotnet restore

# Compile o aplicativo
RUN dotnet publish -c Release -o out

# Use uma imagem menor para o ambiente de produção
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copie os arquivos publicados do aplicativo para o contêiner
COPY --from=build-env /app/out .

# Inicie o aplicativo quando o contêiner for iniciado
ENTRYPOINT ["dotnet", "TrybeHotel.dll"]