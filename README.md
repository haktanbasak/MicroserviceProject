# MicroserviceProject

Modern .NET 8 teknolojileri kullanılarak geliştirilen, mikroservis mimarisi prensiplerini temel alan örnek bir projedir.

Projede ASP.NET Core Minimal API, CQRS, MediatR, MongoDB ve ortak Shared kütüphanesi kullanılarak modüler, ölçeklenebilir ve sürdürülebilir bir servis mimarisi oluşturulmaktadır.

---

# 🚀 Kullanılan Teknolojiler

- .NET 8
- ASP.NET Core 8 Minimal API
- MongoDB
- MongoDB.EntityFrameworkCore
- MediatR
- AutoMapper
- MassTransit
- FluentValidation
- Refit
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
│   ├── Features
│   ├── Repositories
│   ├── Options
│   ├── Program.cs
│   └── appsettings.json
│
├── MicroserviceProject.Shared
│   ├── Extensions
│   └── ServiceResult.cs
│
├── docker-compose.yml
├── README.md
└── MicroserviceProject.sln
```

Projede kullanılan mimari yaklaşımlar:

- Minimal API
- Feature Based Architecture
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

### Mevcut Özellikler

- ✅ Kategori oluşturma
- ✅ Tüm kategorileri listeleme
- ✅ ID'ye göre kategori getirme
- ✅ AutoMapper ile DTO dönüşümü
- ✅ CQRS yapısı
- ✅ MediatR kullanımı
- ✅ MongoDB bağlantısı
- ✅ Standart API cevap modeli (ServiceResult)
- ✅ Merkezi hata yönetimi (ProblemDetails)

---

## MicroserviceProject.Shared

Tüm mikroservisler tarafından ortak kullanılacak altyapıları içermektedir.

### İçerdiği Yapılar

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

`appsettings.json` içerisindeki ayarlar Strongly Typed sınıflara bağlanmaktadır.

```csharp
builder.Services.AddOptions<MongoOptions>();
```

Bu sayede bağlantı bilgileri ve uygulama ayarları merkezi olarak yönetilmektedir.

---

## Minimal API

API endpointleri Controller yerine Minimal API yaklaşımı kullanılarak geliştirilmektedir.

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
    ├── GetAll
    └── GetById
```

Her işlem kendi Request, Handler ve Endpoint yapısına sahiptir.

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
MediatR
        │
        ▼
Command / Query Handler
        │
        ▼
Business Logic
```

---

## AutoMapper

Entity ve DTO nesneleri arasındaki dönüşümler AutoMapper kullanılarak gerçekleştirilmektedir.

Bu sayede tekrar eden manuel property eşleştirme kodları azaltılmış ve bakım kolaylığı sağlanmıştır.

---

## Result Pattern

API'den dönen tüm başarılı ve başarısız cevaplar standart bir yapı üzerinden yönetilmektedir.

Desteklenen cevap tipleri:

- 200 OK
- 201 Created
- 204 No Content
- 400 Bad Request
- 404 Not Found
- ProblemDetails

---

## Factory Method

`ServiceResult` nesneleri doğrudan oluşturulmak yerine statik metotlar aracılığıyla üretilmektedir.

```csharp
ServiceResult.SuccessAsNoContent();

ServiceResult.Error(...);

ServiceResult<T>.SuccessAsOk(data);

ServiceResult<T>.SuccessAsCreated(data, url);
```

Bu yaklaşım daha okunabilir, güvenli ve standart bir kullanım sunmaktadır.

---

## Extension Methods

Tekrarlayan servis kayıtları ve endpoint dönüşümleri Extension Method kullanılarak merkezi hale getirilmiştir.

Örnek olarak aşağıdaki tipler genişletilmektedir:

- IServiceCollection
- RouteGroupBuilder
- ServiceResult

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
AppDbContext
        │
        ▼
MongoDB
        │
        ▼
Entity
        │
        ▼
AutoMapper
        │
        ▼
DTO
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
- AutoMapper
- MassTransit
- FluentValidation
- MongoDB.EntityFrameworkCore
- Refit
- NewId
- Swashbuckle.AspNetCore

---

# 📊 Mevcut Durum

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
| Docker | ✅ |
| Docker Compose | ✅ |

---

# 🚀 Planlanan Bileşenler

Projeye ilerleyen bölümlerde aşağıdaki servis ve teknolojilerin eklenmesi planlanmaktadır.

- Basket Service
- Order Service
- Identity Service
- Redis
- RabbitMQ
- API Gateway
- YARP

---

# 📚 Öğrenilen Mimari Yaklaşımlar

Bu projede aşağıdaki yazılım geliştirme yaklaşımları uygulanmaktadır.

- Feature Based Architecture
- Minimal API
- CQRS
- Mediator Pattern
- Dependency Injection
- Options Pattern
- Result Pattern
- Factory Method
- Extension Methods
- Generic Programming

---

# 🎯 Amaç

Bu projenin temel amacı;

- Mikroservis mimarisini modern .NET teknolojileri ile uygulamak,
- Minimal API yaklaşımını gerçek bir projede kullanmak,
- CQRS ve MediatR ile sorumlulukları ayırmak,
- Ortak bileşenleri Shared katmanında toplamak,
- Modüler, sürdürülebilir ve ölçeklenebilir bir yazılım mimarisi oluşturmak,
- Gerçek dünya projelerinde kullanılan tasarım desenlerini uygulamalı olarak geliştirmektir.
