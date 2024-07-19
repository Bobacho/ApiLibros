FROM okteto/dotnetcore:8

RUN mkdir -p /home/app

COPY . /home/app

WORKDIR /home/app

RUN dotnet restore

RUN dotnet publish -c Release -o out

EXPOSE 5000

CMD ["dotnet", "out/ApiLibros.dll"]
