# MicroserviceProject

Modern .NET teknolojileri kullanılarak geliştirilen mikroservis mimarisi örnek projesidir.

Projede Minimal API, CQRS, MediatR, MongoDB ve modern ASP.NET Core yaklaşımları kullanılarak ölçeklenebilir ve modüler bir yapı oluşturulmaktadır.

---

# 🚀 Kullanılan Teknolojiler

- .NET 9
- ASP.NET Core 9 Minimal API
- Entity Framework Core 9
- MongoDB
- MediatR
- MassTransit
- Swagger / OpenAPI

---

# 🏛 Mimari

Proje Feature (Özellik) bazlı klasör yapısı kullanılarak geliştirilmiştir.

```text
src
└── services
    └── catalog
        └── MicroserviceProject.Catalog.Api

shared
└── MicroserviceProject.Shared
```

Kullanılan mimari yaklaşımlar:

- Minimal API
- CQRS (Command Query Responsibility Segregation)
- MediatR
- Dependency Injection
- Options Pattern
- Result Pattern
- Generic Response Model
- Extension Methods
- Factory Method

---

# 📦 Mevcut Özellikler

## Catalog Servisi

- Kategori oluşturma
- Kategori doğrulama
- MongoDB bağlantısı
- Standart API cevap modeli (ServiceResult)
- Merkezi hata yönetimi (ProblemDetails)

---

# 🔧 Altyapı

## Dependency Injection

Servis kayıtları Extension Method yapısı ile yönetilmektedir.

```csharp
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
```

---

## Options Pattern

`appsettings.json` dosyasındaki ayarlar Strongly Typed sınıflara bağlanmaktadır.

Örnek:

```csharp
builder.Services.AddOptions<MongoOptions>();
```

---

## Minimal API

API endpointleri Controller yerine Minimal API yaklaşımı ile geliştirilmektedir.

Örnek:

```csharp
app.MapGroup("/api/categories");
```

---

## CQRS

İşlemler Command ve Query olarak birbirinden ayrılmıştır.

Örnek yapı:

```text
Features
└── Categories
    └── Create
        ├── CreateCategoryCommand
        ├── CreateCategoryCommandHandler
        └── CreateCategoryResponse
```

---

## MediatR

Endpoint ile Business Logic birbirinden bağımsız hale getirilmiştir.

```text
HTTP Request
        │
        ▼
Minimal API
        │
        ▼
MediatR
        │
        ▼
Command Handler
        │
        ▼
Veritabanı
```

---

## Result Pattern

API'den dönen tüm cevaplar `ServiceResult` yapısı ile standart hale getirilmektedir.

Desteklenen cevap tipleri:

- 200 OK
- 201 Created
- 204 No Content
- 400 Bad Request
- 404 Not Found
- ProblemDetails

---

# 🔄 İstek Akışı

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
Command Handler
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

# 🎯 Kullanılan Tasarım Desenleri

- CQRS
- Mediator Pattern
- Result Pattern
- Factory Method
- Options Pattern
- Dependency Injection
- Extension Method
- Generic Programming

---

# 📌 Yol Haritası

Projeye ilerleyen aşamalarda aşağıdaki servis ve teknolojilerin eklenmesi planlanmaktadır.

- Basket Service
- Order Service
- Identity Service
- API Gateway
- Redis
- RabbitMQ
- MassTransit
- YARP
- Docker
- Docker Compose
- Authentication & Authorization
