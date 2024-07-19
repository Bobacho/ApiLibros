FROM ubuntu/dotnet-aspnet:8.0-24.04_stable

RUN mkdir -p /home/app

COPY . /home/app

WORKDIR /home/app

RUN dotnet restore

RUN dotnet publish -c Release -o out

EXPOSE 5000

CMD ["dotnet", "out/ApiLibros.dll"]
