FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MillionaireGame.Question/MillionaireGame.Question.API/MillionaireGame.Question.API.csproj", "MillionaireGame.Question/MillionaireGame.Question.API/"]
RUN dotnet restore "MillionaireGame.Question/MillionaireGame.Question.API/MillionaireGame.Question.API.csproj"
COPY . .
WORKDIR "/src/MillionaireGame.Question/MillionaireGame.Question.API"
RUN dotnet build "MillionaireGame.Question.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MillionaireGame.Question.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MillionaireGame.Question.API.dll"]