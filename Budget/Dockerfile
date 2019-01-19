FROM microsoft/dotnet:2.2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM threax/build AS build
WORKDIR /src
COPY Budget/Budget.csproj Budget/
RUN dotnet restore Budget/Budget.csproj
COPY . .
WORKDIR /src/Budget
RUN dotnet build Budget.csproj -c Release -o /app

FROM build AS publish
RUN yarn run yarn-install
RUN yarn run clean
RUN yarn run build
RUN dotnet publish Budget.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Budget.dll"]
