
# 🏠 RealEstateApp - API .NET 8

Este es un proyecto de backend para una aplicación de bienes raíces, construido con .NET 8 y arquitectura limpia (hexagonal), utilizando MongoDB, MediatR y CQRS.

---

## 🧱 Arquitectura

- ✔️ Arquitectura limpia (Hexagonal)
- ✔️ CQRS + MediatR
- ✔️ FluentValidation
- ✔️ MongoDB
- ✔️ Logging estructurado
- ✔️ Manejo global de errores
- ✔️ Respuesta estándar con `ApiResponse<T>`
- ✔️ Swagger UI

---

## 🚀 Tecnologías

- [.NET 8](https://dotnet.microsoft.com/)
- [MongoDB](https://www.mongodb.com/)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://fluentvalidation.net/)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

---

## 📦 Estructura

```
RealEstateApp/
├── RealEstateApp.Domain
├── RealEstateApp.Application
├── RealEstateApp.Infrastructure
└── RealEstateApp.WebApi
```

---

## ▶️ ¿Cómo correr el proyecto?

### 1. Clona el repositorio

```bash
git clone https://github.com/tuusuario/RealEstateApp.git
cd RealEstateApp
```

### 2. Levanta MongoDB

Puedes usar Docker:

```bash
docker run -d -p 27017:27017 --name mongo mongo
```

O instalar MongoDB localmente desde: https://www.mongodb.com/try/download/community

### 3. Ejecuta la solución

```bash
dotnet restore
dotnet build
dotnet run --project RealEstateApp.WebApi
```

La API estará disponible en:  
➡️ `https://localhost:7023/swagger`

---

## 🧪 Seed de datos

En la carpeta seedData se encuentran los archivos para insertar data de demostración.
- El seed contiene una aplicación node.js que realiza la insercción de la data.
- Para realizar este proceso siga los siguientes pasos:
  1. Instale los paquetes de node usando npm i
  2. en el cmd, powershell o su consola de preferecia, ejecute los siguientes comandos en el orden que se presentan:
     - node seedowner.js
     - node seedproperties.js
     - node seedpropertyimage.js


---

## 📚 Endpoints disponibles

- `GET /api/properties` → Listado con filtros (`name`, `address`, `minPrice`, `maxPrice`)


## 📄 Licencia

MIT - 2025
