# Use a slim ASP.NET base image for .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Create a working directory for the application
WORKDIR /app
EXPOSE 80
EXPOSE 8080

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src/Presentation

# Copy csproj files and restore as distinct layers
COPY ["src/Presentation/LogsLiteThinking.API/LogsLiteThinking.API.csproj", "Presentation/"]
COPY ["src/Core/LogLiteThinking.Application/LogLiteThinking.Application.csproj", "Core/"]
COPY ["src/Infrastructure/LogLiteThinking.Infrastructure/LogLiteThinking.Infrastructure.csproj", "Infrastructure/"]
COPY ["src/Domain/LogLiteThinking.Domain/LogLiteThinking.Domain.csproj", "Domain/"]
COPY ["src/Shared/LogsLiteThinking.Shared/LogsLiteThinking.Shared.csproj", "Shared/"]

RUN dotnet restore "Presentation/LogsLiteThinking.API.csproj"

# Copy the rest of the source code
COPY . .

WORKDIR "src/Presentation/LogsLiteThinking.API/"
RUN dotnet build "LogsLiteThinking.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "LogsLiteThinking.API.csproj" -c Release -o /app/publish

# Use the runtime image to run the application
FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogsLiteThinking.API.dll"]