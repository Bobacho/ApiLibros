FROM bitnami/dotnet-sdk:8.0.303

RUN mkdir -p /home/app

COPY . /home/app

WORKDIR /home/app

RUN dotnet restore

EXPOSE 5184

CMD ["dotnet","run","environment=Production"]
