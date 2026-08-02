# MicroserviceProject

Modern .NET teknolojileri kullanılarak geliştirilen, mikroservis mimarisini temel alan örnek bir projedir.

Projede Minimal API, CQRS, MediatR ve MongoDB kullanılarak modüler, ölçeklenebilir ve sürdürülebilir bir mimari oluşturulmaktadır.

---

# 🚀 Kullanılan Teknolojiler

- .NET 8
- ASP.NET Core 8 Minimal API
- MongoDB
- MongoDB.EntityFrameworkCore
- MediatR
- MassTransit
- AutoMapper
- Swagger / OpenAPI
- Docker
- Docker Compose

---

# 🏛 Mimari

Proje Feature (özellik) bazlı klasör yapısı kullanılarak geliştirilmektedir.

```text
MicroserviceProject
│
├── MicroserviceProject.Catalog.Api
│
├── MicroserviceProject.Shared
│
├── docker-compose
│
├── README.md
│
└── MicroserviceProject.sln
```

Projede kullanılan mimari yaklaşımlar:

- Minimal API
- CQRS (Command Query Responsibility Segregation)
- Mediator Pattern (MediatR)
- Dependency Injection
- Options Pattern
- Result Pattern
- Factory Method
- Extension Methods
- Generic Programming

---

# 📦 Proje Yapısı

## MicroserviceProject.Catalog.Api

Catalog mikroservisini içermektedir.

Mevcut özellikler:

- Kategori oluşturma
- Kategori doğrulama
- MongoDB bağlantısı
- CQRS yapısı
- MediatR kullanımı
- AutoMapper entegrasyonu
- Standart API cevap modeli
- Merkezi hata yönetimi

---

## MicroserviceProject.Shared

Servisler tarafından ortak kullanılan yapıların bulunduğu katmandır.

İçerdiği yapılar:

- ServiceResult
- Generic ServiceResult<T>
- EndpointResult Extensions
- CommonService Extensions
- ProblemDetails yönetimi
- Validation hata cevapları
- Refit Exception dönüşümleri

---

# 🔧 Altyapı

## Dependency Injection

Servis kayıtları Extension Method yapısı ile merkezi olarak yönetilmektedir.

```csharp
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));
```

---

## Options Pattern

Uygulama ayarları (`appsettings.json`) Strongly Typed sınıflara bağlanmaktadır.

```csharp
builder.Services.AddOptions<MongoOptions>();
```

Bu yapı sayesinde Connection String gibi ayarlar merkezi olarak yönetilmektedir.

---

## Minimal API

API endpointleri Controller yerine Minimal API yaklaşımı ile geliştirilmektedir.

```csharp
app.MapGroup("/api/categories");
```

---

## CQRS

İşlemler Command ve Query olarak birbirinden ayrılmıştır.

```text
Features
└── Categories
    ├── Create
    ├── Update
    ├── Delete
    └── GetAll
```

Her işlem kendi Request, Response ve Handler sınıflarına sahiptir.

---

## MediatR

Endpoint ile Business Logic katmanı birbirinden tamamen ayrılmıştır.

```text
HTTP Request
        │
        ▼
Minimal API Endpoint
        │
        ▼
Mediator
        │
        ▼
Command / Query Handler
        │
        ▼
Business Logic
```

---

## AutoMapper

DTO ile Entity nesneleri arasındaki dönüşümler AutoMapper kullanılarak gerçekleştirilmektedir.

Bu sayede manuel property eşleştirmeleri ortadan kaldırılmıştır.

---

## Result Pattern

API'den dönen tüm başarılı ve başarısız cevaplar standart bir yapı üzerinden yönetilmektedir.

Başlıca cevap tipleri:

- 200 OK
- 201 Created
- 204 No Content
- 400 Bad Request
- 404 Not Found
- ProblemDetails

---

## Factory Method

`ServiceResult` sınıfı nesneleri doğrudan oluşturulmak yerine statik metotlar kullanılarak üretilmektedir.

Örnek:

```csharp
ServiceResult.SuccessAsNoContent();

ServiceResult.Error(...);

ServiceResult<T>.SuccessAsOk(data);

ServiceResult<T>.SuccessAsCreated(data, url);
```

Bu yaklaşım daha okunabilir, güvenli ve standart bir kullanım sağlar.

---

## Extension Methods

Tekrarlayan işlemler Extension Method kullanılarak merkezi hale getirilmiştir.

Örneğin:

- IServiceCollection
- WebApplication
- RouteGroupBuilder
- ServiceResult

tiplerine yeni davranışlar eklenmiştir.

---

# 🔄 İstek Yaşam Döngüsü

```text
HTTP Request
        │
        ▼
Minimal API Endpoint
        │
        ▼
Model Binding
        │
        ▼
MediatR
        │
        ▼
Command / Query Handler
        │
        ▼
AutoMapper
        │
        ▼
AppDbContext
        │
        ▼
MongoDB
        │
        ▼
ServiceResult<T>
        │
        ▼
EndpointResult Extension
        │
        ▼
HTTP Response
```

---

# 📦 Kullanılan NuGet Paketleri

- MediatR
- MassTransit
- AutoMapper
- MongoDB.EntityFrameworkCore
- FluentValidation
- Refit
- NewId
- Swashbuckle.AspNetCore

---

# 📈 Proje Durumu

| Özellik | Durum |
|----------|:----:|
| Catalog Service | ✅ |
| Shared Library | ✅ |
| MongoDB | ✅ |
| CQRS | ✅ |
| MediatR | ✅ |
| AutoMapper | ✅ |
| Dependency Injection | ✅ |
| Options Pattern | ✅ |
| Result Pattern | ✅ |
| Swagger | ✅ |
| Docker Compose | ✅ |
| Basket Service | ⏳ |
| Order Service | ⏳ |
| Identity Service | ⏳ |
| Redis | ⏳ |
| RabbitMQ | ⏳ |
| API Gateway | ⏳ |
| YARP | ⏳ |

---

# 🎯 Amaç

Bu proje;

- Mikroservis mimarisini uygulamak,
- Modern ASP.NET Core yaklaşımlarını kullanmak,
- Servisler arası ortak bileşenleri Shared katmanında toplamak,
- CQRS ve MediatR ile sorumlulukları ayırmak,
- Sürdürülebilir ve ölçeklenebilir bir yazılım mimarisi oluşturmak

amacıyla geliştirilmektedir.
