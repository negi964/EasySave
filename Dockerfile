FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /source
COPY . .
RUN dotnet restore "EasySave.csproj" --disable-parallel
RUN dotnet publish "EasySave.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app 
COPY --from=build /app ./
RUN dotnet add package Newtonsoft.Json --version 13.0.2


EXPOSE 5000
ENTRYPOINT ["dotnet", "EasySave.dll"]