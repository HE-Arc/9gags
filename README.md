# Backend
## Requirements
* ASP .net Core 2.x
* Visual Studio

## Start

Open the 9gags solution in `backend/9gags`

## Migrate database
Open the *Package Manager Console* located in : *tools* -> *NuGet Package Manager* -> *Package Manager Console*.

Then enter this command :

```sh
Update-Database
```

## Run backend
Hit *ctrl + f5* or go to *Debug* -> *Start Without Debugging*

This will open a browser, ignore it.

# Frontend
## Requirements
* npm

## Install dependencies

```sh
cd frontend
npm install
```

## Run frontend

```sh
npm run serve
```

## See result
Open a browser and go to 127.0.0.1:8080.