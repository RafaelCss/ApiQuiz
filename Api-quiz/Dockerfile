#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api-quiz/ApiQuiz.csproj", "Api-quiz/"]
COPY ["Autenticacao/Seguranca.csproj", "Autenticacao/"]
COPY ["Dominio/Dominio.csproj", "Dominio/"]
COPY ["Configuracao/Configuracao.csproj", "Configuracao/"]
COPY ["Infra/Infra.csproj", "Infra/"]
RUN dotnet restore "Api-quiz/ApiQuiz.csproj"
COPY . .
WORKDIR "/src/Api-quiz"
RUN dotnet build "ApiQuiz.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiQuiz.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiQuiz.dll"]