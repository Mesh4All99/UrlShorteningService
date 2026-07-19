<div align="center">

<!-- Animated Header Banner -->
<img src="https://capsule-render.vercel.app/api?type=waving&color=0:6366f1,50:8b5cf6,100:ec4899&height=220&section=header&text=🔗%20ShorterUrls&fontSize=50&fontColor=ffffff&fontAlignY=35&desc=URL%20Shortening%20Service&descSize=20&descAlignY=55&animation=fadeIn" width="100%" />

<!-- Typing Animation -->
<a href="#">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&weight=600&size=22&pause=1000&color=8B5CF6&center=true&vCenter=true&random=false&width=600&lines=⚡+High-Performance+URL+Shortener;🔒+Custom+Aliases+Support;📊+Built-in+Click+Tracking;⚡+Redis+Cache-Aside+Pattern;🚀+Powered+by+.NET+10+Minimal+APIs" alt="Typing SVG" />
</a>

<br/>

<!-- Badges Row 1 -->
[![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![EF Core](https://img.shields.io/badge/EF_Core_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://docs.microsoft.com/ef/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://docs.microsoft.com/dotnet/csharp/)

<!-- Badges Row 2 -->
[![Redis](https://img.shields.io/badge/Redis-DC382D?style=for-the-badge&logo=redis&logoColor=white)](https://redis.io/)
[![License](https://img.shields.io/badge/License-MIT-22c55e?style=for-the-badge&logo=opensourceinitiative&logoColor=white)](#-license)
[![Minimal APIs](https://img.shields.io/badge/Minimal_APIs-ff6b6b?style=for-the-badge&logo=fastapi&logoColor=white)](#)
[![Scalar Docs](https://img.shields.io/badge/Scalar_Docs-6366f1?style=for-the-badge&logo=swagger&logoColor=white)](#)

<br/>

<!-- Short Description -->
<p>
  <strong>🌐 A sleek, high-performance RESTful API for URL shortening</strong><br/>
  <sub>Built with modern .NET 10 Minimal APIs • PostgreSQL • Entity Framework Core • Redis Cache</sub>
</p>

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif" width="100%">

</div>

<br/>

## 🌟 Features

<table>
<tr>
<td width="50%">

### ⚡ Core Features
| Feature | Description |
|:---:|:---|
| 🔗 | **URL Shortening** — Convert long URLs to short, shareable links |
| ✨ | **Custom Aliases** — Choose your own short URL identifier |
| 🎲 | **Auto Generation** — 7-character random IDs when no alias provided |
| 📊 | **Click Tracking** — Built-in analytics with click counter |

</td>
<td width="50%">

### 🛡️ Technical Highlights
| Feature | Description |
|:---:|:---|
| 🚀 | **Minimal APIs** — Lightweight, high-performance endpoints |
| 🗄️ | **PostgreSQL** — Robust, scalable data storage |
| ⚡ | **Redis Cache** — Cache-aside pattern with 5-minute TTL for fast redirects |
| 📝 | **Scalar Docs** — Interactive API documentation at `/docs` |
| 🔄 | **Auto Redirect** — Seamless HTTP 302 redirection |

</td>
</tr>
</table>

<br/>

## 🏗️ Architecture

```mermaid
graph LR
    A["🌐 Client"] -->|POST /shorturl| B["⚡ Minimal API"]
    A -->|GET /:alias| B
    B -->|"1. Check cache"| E["⚡ Redis Cache"]
    E -->|"Cache HIT → return URL"| B
    E -->|"Cache MISS"| C["🔧 Services"]
    C -->|"2. EF Core query"| D["🗄️ PostgreSQL"]
    D -->|"3. URL found → store in cache"| E
    C --> B
    B -->|302 Redirect| A

    style A fill:#6366f1,stroke:#4f46e5,color:#fff
    style B fill:#8b5cf6,stroke:#7c3aed,color:#fff
    style C fill:#ec4899,stroke:#db2777,color:#fff
    style D fill:#06b6d4,stroke:#0891b2,color:#fff
    style E fill:#DC382D,stroke:#b02020,color:#fff
```

<br/>

## 🧰 Tech Stack

<div align="center">

| Layer | Technology | Badge |
|:---:|:---|:---:|
| **Runtime** | .NET 10 | ![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=flat-square&logo=dotnet&logoColor=white) |
| **Language** | C# | ![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white) |
| **Framework** | ASP.NET Core Minimal APIs | ![ASP.NET](https://img.shields.io/badge/ASP.NET_Core-0078D4?style=flat-square&logo=dotnet&logoColor=white) |
| **ORM** | Entity Framework Core 10 | ![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=flat-square&logo=dotnet&logoColor=white) |
| **Database** | PostgreSQL | ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=flat-square&logo=postgresql&logoColor=white) |
| **DB Provider** | Npgsql | ![Npgsql](https://img.shields.io/badge/Npgsql-336791?style=flat-square&logo=postgresql&logoColor=white) |
| **Cache** | Redis (StackExchange.Redis) | ![Redis](https://img.shields.io/badge/Redis-DC382D?style=flat-square&logo=redis&logoColor=white) |
| **Cache Abstraction** | `IDistributedCache` + `IRedisCache` | ![.NET](https://img.shields.io/badge/IDistributedCache-512BD4?style=flat-square&logo=dotnet&logoColor=white) |
| **API Docs** | Scalar | ![Scalar](https://img.shields.io/badge/Scalar-6366f1?style=flat-square&logo=swagger&logoColor=white) |

</div>

<br/>

## 📁 Project Structure

```
🗂️ ShorterUrls/
│
├── 📂 Cache/                 # Redis Caching Layer
│   ├── IRedisCache.cs        # Cache abstraction (GetData<T>, SetData<T>)
│   └── RedisCache.cs         # IDistributedCache implementation (5-min TTL)
│
├── 📂 Data/                  # DbContext & Database Configuration
│   └── ApplicationDbContext.cs
│
├── 📂 Dtos/                  # Data Transfer Objects
│   ├── urlshortenRequest.cs  # Request DTO (url, alias)
│   └── UrlShortenResponse.cs # Response DTO (shortenUrl)
│
├── 📂 Helpers/               # Utility Classes
│   └── RandomizedCharachters.cs  # Random ID Generator
│
├── 📂 Migrations/            # EF Core Database Migrations
│
├── 📂 Models/                # Domain Models
│   └── Url.cs                # URL Entity (Id, LongUrl, ShortUrl, ClickCount)
│
├── 📂 Properties/            # Launch Settings
│
├── 🟢 Program.cs             # Entry Point & Endpoint Definitions
├── ⚙️ appsettings.json       # App Configuration & Connection Strings
├── 📦 ShorterUrls.csproj     # Project File & Dependencies
└── 📄 README.md              # You are here! 😄
```

<br/>

## 🚀 Getting Started

### 📋 Prerequisites

<div align="center">

| Requirement | Version | Installation |
|:---:|:---:|:---:|
| ![.NET](https://img.shields.io/badge/.NET_SDK-512BD4?style=flat-square&logo=dotnet&logoColor=white) | **10.0+** | [Download](https://dotnet.microsoft.com/download) |
| ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=flat-square&logo=postgresql&logoColor=white) | **14.0+** | [Download](https://www.postgresql.org/download/) |
| ![Redis](https://img.shields.io/badge/Redis-DC382D?style=flat-square&logo=redis&logoColor=white) | **6.0+** | [Download](https://redis.io/download/) |

</div>

### ⚙️ Installation

<details>
<summary><b>📥 Step 1 — Clone the Repository</b></summary>

```bash
git clone https://github.com/Mesh4All99/UrlShorteningService.git
cd UrlShorteningService
```

</details>

<details>
<summary><b>🗄️ Step 2 — Configure Database & Redis Connection</b></summary>

Update the connection strings in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Host=localhost; Port=5432; Database=UrlShorterDb; Username=postgres; Password=YOUR_PASSWORD;",
    "Redis": "localhost:6379"
  }
}
```

> 💡 **Tip:** Make sure Redis is running before starting the application. The default port is `6379`.

</details>

<details>
<summary><b>📦 Step 3 — Apply Migrations</b></summary>

```bash
dotnet ef database update
```

> 💡 **Tip:** If you don't have EF tools installed, run:
> ```bash
> dotnet tool install --global dotnet-ef
> ```

</details>

<details>
<summary><b>▶️ Step 4 — Run the Application</b></summary>

```bash
dotnet run
```

🎉 The API will be available at `https://localhost:7xxx`

📖 **API Documentation** is accessible at `/docs` in development mode (powered by Scalar).

</details>

<br/>

## 📡 API Reference

### 🔗 Shorten a URL

```http
POST /shorturl
Content-Type: application/json
```

<table>
<tr>
<td width="50%">

**📤 Request Body**
```json
{
  "url": "https://example.com/very/long/url/path",
  "alias": "my-link"  // ⬅️ Optional
}
```

</td>
<td width="50%">

**📥 Response** `200 OK`
```json
{
  "shortenUrl": "https://localhost:7xxx/my-link"
}
```

</td>
</tr>
</table>

> [!NOTE]
> - If `alias` is provided → it will be used as the custom short URL identifier
> - If `alias` is omitted → a random 7-character ID will be auto-generated

> [!WARNING]
> - Returns `400 Bad Request` if the URL format is invalid
> - Returns `400 Bad Request` if the alias is already taken

---

### 🔄 Redirect to Original URL

```http
GET /{alias}
```

| Parameter | Type | Description |
|:---:|:---:|:---|
| `alias` | `string` | **Required**. The short URL identifier |

> **Response:** `302 Found` — Redirects to the original long URL & increments click counter

> [!TIP]
> Redirects use a **cache-aside pattern**: the alias is looked up in Redis first (⚡ fast path). On a cache miss, the URL is fetched from PostgreSQL, stored in Redis with a **5-minute TTL**, then the redirect is served. Click counts are incremented on every request.

<br/>

## 📊 Database Schema

```mermaid
erDiagram
    URL {
        string Id PK "Short alias (7 chars or custom)"
        string LongUrl "Original full URL"
        string ShortUrl "Complete shortened URL"
        int ClickCount "Number of redirects"
    }
```

<br/>

## 🤝 Contributing

<div align="center">

Contributions are welcome! Feel free to open issues and pull requests.

[![GitHub Issues](https://img.shields.io/badge/Report_Bug-red?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Mesh4All99/UrlShorteningService/issues)
[![Feature Request](https://img.shields.io/badge/Request_Feature-22c55e?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Mesh4All99/UrlShorteningService/issues)

</div>

<br/>

## 📄 License

This project is available for free use.

<br/>

<!-- Footer Wave -->
<img src="https://capsule-render.vercel.app/api?type=waving&color=0:6366f1,50:8b5cf6,100:ec4899&height=120&section=footer" width="100%" />

<div align="center">

**⭐ If you found this project helpful, give it a star!**

<br/>

Made with ❤️ using .NET 10

</div>
