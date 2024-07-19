FROM bitnami/dotnet-sdk:8.0.303

RUN mkdir -p /home/app

COPY . /home/app

WORKDIR /home/app

RUN dotnet restore

RUN dotnet publish -c Release -o out

EXPOSE 5000

USER root
RUN chmod +x /opt/bitnami/dotnet-sdk/bin/dotnet

ENTRYPOINT ["dotnet", "out/ApiLibros.dll"]
