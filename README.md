\# MicroserviceProject



Bu repository, \*\*.NET ile Microservices\*\* eğitimini takip ederken geliştirdiğim projeyi ve kendi aldığım teknik notları içermektedir.



> Amaç sadece projeyi tamamlamak değil; kullanılan mimariyi, tasarım desenlerini ve .NET ekosistemini detaylı şekilde öğrenmektir.



\---



\# 🚀 Kullanılan Teknolojiler



\- .NET 9

\- ASP.NET Core Minimal API

\- MediatR

\- CQRS

\- MongoDB

\- Dependency Injection

\- Options Pattern

\- Result Pattern



\---



\# 📂 Proje Yapısı



```text

MicroserviceProject

│

├── src

│   └── services

│       └── catalog

│           └── MicroserviceProject.Catalog.Api

│

└── shared

&#x20;   └── MicroserviceProject.Shared

```



> Not: Shared projesi eğitim sürecinde ayrı bir Class Library olarak oluşturulmuştur.



\---



\# 📖 Şu Ana Kadar Öğrenilen Konular



\## ✅ Minimal API



Controller yerine endpoint tanımları kullanılmaktadır.



Örnek:



```csharp

app.MapGroup("api/categories");

```



\---



\## ✅ Dependency Injection



Servislerin uygulama içerisinde otomatik oluşturulmasını sağlar.



Örnek:



```csharp

builder.Services.AddOptionsExt();

builder.Services.AddDatabaseServiceExt();

```



\---



\## ✅ Options Pattern



`appsettings.json` içerisindeki ayarlar Strongly Typed olarak okunmaktadır.



Örnek:



```csharp

builder.Services.AddOptions<MongoOptions>()

```



\---



\## ✅ CQRS



Her işlem kendi Feature klasörü altında tutulmaktadır.



Örnek yapı:



```text

Features

&#x20;└── Categories

&#x20;     └── Create

&#x20;          ├── CreateCategoryCommand

&#x20;          ├── CreateCategoryCommandHandler

&#x20;          └── CreateCategoryResponse

```



\---



\## ✅ MediatR



Endpoint ile Business Logic birbirinden ayrılmıştır.



```text

HTTP Request

&#x20;     │

&#x20;     ▼

Endpoint

&#x20;     │

&#x20;     ▼

Mediator

&#x20;     │

&#x20;     ▼

Handler

&#x20;     │

&#x20;     ▼

Database

```



\---



\## ✅ Result Pattern



API'den dönen başarılı ve başarısız cevapların tek tip olması sağlanmaktadır.



Başarılı cevap:



```text

200 OK

```



Başarısız cevap:



```text

ProblemDetails

```



\---



\# 🔄 Request Akışı



```text

HTTP Request

&#x20;     │

&#x20;     ▼

Minimal API Endpoint

&#x20;     │

&#x20;     ▼

Mediator

&#x20;     │

&#x20;     ▼

Command Handler

&#x20;     │

&#x20;     ▼

AppDbContext

&#x20;     │

&#x20;     ▼

MongoDB

&#x20;     │

&#x20;     ▼

ServiceResult

&#x20;     │

&#x20;     ▼

ToGenericResult()

&#x20;     │

&#x20;     ▼

HTTP Response

```



\---



\# 📌 Notlar



Bu repository eğitim ilerledikçe güncellenecektir.



Her yeni bölümde;



\- Kullanılan teknolojiler

\- Tasarım desenleri

\- Gerçek hayat örnekleri

\- Mülakat notları

\- Öğrenme notları



README dosyasına eklenecektir.



\---



\# 📚 Kaynak



\- Udemy - .NET ile Microservices

