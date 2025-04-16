# 🎙️ AudioEmotionDetector

AudioEmotionDetector är en .NET 7 Web API-applikation som låter användare ladda upp ljudfiler, analysera dem och få tillbaka emotionella tolkningar. Projektet använder JWT för autentisering och Entity Framework Core för datalagring i SQL Server.

---

## 📐 Arkitektur

Projektet är uppdelat i följande lager:

- `Controllers/` – Hanterar HTTP-anrop (GET, POST, PUT, DELETE)
- `Models/` – Domänmodeller (t.ex. `User`, `AudioRecord`)
- `Mapping/` – Innehåller `DataSeeder` och `JwtTokenGenerator`
- `Program.cs` – Bootstrapper för applikationen
- `appsettings.json` – Konfiguration av t.ex. databaskoppling och JWT
- `Migrations/` – Hanterar EF Core databasschema
- `wwwroot/AudioFiles` – Lagrar uppladdade ljudfiler

---

## 🛠️ Teknikstack

| Teknik              | Användning                |
|---------------------|---------------------------|
| ASP.NET Core Web API| Backend/API               |
| Entity Framework    | ORM & databasåtkomst      |
| SQL Server          | Databas                   |
| JWT Bearer Auth     | Autentisering             |
| Swagger             | API-dokumentation         |

---

## 🚀 Installation

1. **Klona projektet:**

```bash
git clone https://github.com/YAZM16/AudioEmotionDetector.git
cd AudioEmotionDetector
Verbb | Route | Beskrivning
GET | /api/audio | Lista alla ljudfiler
GET | /api/audio/{id} | Hämta en specifik ljudfil
POST | /api/audio/upload | Ladda upp ljudfil
PUT | /api/audio/{id} | Uppdatera ljudfilens info
DELETE | /api/audio/{id} | Radera ljudfil


Verbb | Route | Beskrivning
GET | /api/users | Lista alla användare
GET | /api/users/{id} | Visa en användare
POST | /api/users | Skapa användare
PUT | /api/users/{id} | Uppdatera användare
DELETE | /api/users/{id} | Radera användare
