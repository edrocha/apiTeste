#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TESTE.Cep.Servico/TESTE.Cep.Servico.csproj", "TESTE.Cep.Servico/"]
RUN dotnet restore "TESTE.Cep.Servico/TESTE.Cep.Servico.csproj"
COPY . .
WORKDIR "/src/TESTE.Cep.Servico"
RUN dotnet build "TESTE.Cep.Servico.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TESTE.Cep.Servico.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TESTE.Cep.Servico.dll"]