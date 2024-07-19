FROM bitnami/dotnet-sdk:8.0.303

RUN mkdir -p /home/app

RUN chown -R 1001:1001 /home/app

COPY . /home/app

WORKDIR /home/app

RUN chmod +x /opt/bitnami/dotnet-sdk/bin/dotnet

RUN dotnet restore

RUN dotnet publish -c Release -o out

EXPOSE 5000

USER 1001

ENTRYPOINT ["dotnet", "out/ApiLibros.dll"]
