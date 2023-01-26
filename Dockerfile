FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY ./TaskPlanner ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .

ENV ASPNETCORE_URLS http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TaskPlannerWeb.dll"]