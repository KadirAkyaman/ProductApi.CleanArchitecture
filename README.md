# ProductApi.CleanArchitecture

[Click here for the English version of this document.](./README.EN.md)

---

### Proje Açıklaması

Bu API, ürünler için temel CRUD (Oluşturma, Okuma, Güncelleme, Silme) operasyonlarını yönetir. Clean Architecture prensiplerine uygun olacak şekilde katmanlı yapı kullanılmış, her katmanın sorumlulukları net biçimde ayrılmıştır.

### Temel Özellikler

-   **Katmanlı Mimari:** `Domain`, `Application`, `Infrastructure` ve `Api` olmak üzere 4 ana katmandan oluşur.
-   **SOLID Prensipleri:** Proje genelinde Tek Sorumluluk (Single Responsibility) ve Bağımlılıkların Tersine Çevrilmesi (Dependency Inversion) gibi prensipler uygulanmıştır.
-   **Repository & Unit of Work Desenleri:** Veri erişim mantığı, iş katmanından tamamen soyutlanmış ve transaction yönetimi merkezileştirilmiştir.
-   **Asenkron Programlama:** Performansı ve ölçeklenebilirliği artırmak için tüm I/O işlemleri `async/await` kullanılarak asenkron olarak gerçekleştirilmiştir.
-   **Güçlü Tipli Yapılandırma:** Veritabanı bağlantısı gibi ayarlar, Options Pattern kullanılarak yönetilmektedir.
-   **Global Hata Yönetimi:** Tüm beklenmedik hatalar, merkezi bir `Middleware` tarafından yakalanarak standart ve kullanıcı dostu bir formatta yanıtlanır.
-   **Gelişmiş API Dokümantasyonu:** Swagger arayüzü, hem endpoint'leri hem de DTO şemalarını açıklayan XML yorumları ile zenginleştirilmiştir.

### API Endpoint'leri

Bu API, ürün yönetimi için aşağıdaki temel RESTful operasyonları sunar. Tüm endpoint'lerin detaylı kullanımı, parametreleri ve dönüş modelleri için lütfen çalışan uygulamadaki **Swagger arayüzünü** kullanın.

| Metot  | Endpoint            | Açıklama                   |
| :----- | :------------------ | :------------------------- |
| `GET`  | `/api/products`     | Tüm ürünleri listeler.     |
| `GET`  | `/api/products/{id}`| Tek bir ürünü getirir.     |
| `POST` | `/api/products`     | Yeni bir ürün oluşturur.   |
| `PUT`  | `/api/products/{id}`| Mevcut bir ürünü günceller.|
| `DELETE`| `/api/products/{id}`| Bir ürünü siler.           |

### Kullanılan Teknolojiler

-   **.NET 9** 
-   ASP.NET Core Web API
-   Entity Framework Core
-   PostgreSQL
-   AutoMapper
-   FluentValidation
-   Swagger

### Kurulum ve Çalıştırma Adımları

Bu projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin.

#### Ön Gereksinimler

-   .NET SDK (Projede kullanılan versiyon ile uyumlu)
-   PostgreSQL veritabanı sunucusu
-   Bir veritabanı yönetim aracı (opsiyonel)

#### Kurulum

1.  **Repository'yi Klonlayın:**
    ```sh
    git clone https://github.com/KadirAkyaman/KayraExport.ProductApi
    ```

2.  **Veritabanı Bağlantısını Yapılandırın:**
    -   `src/KayraExport.Api/appsettings.json` dosyasını açın.
    -   `DatabaseSettings` bölümü altındaki `DefaultConnection` alanında, `User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;` kısmlarını kendi PostgreSQL kullanıcı adı ve şifrenizle değiştirin.

    ```json
    "DatabaseSettings": {
    "DefaultConnection": "Server=127.0.0.1;Port=5432;Database=ProductAPI;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
    }
    ```

3.  **Veritabanı Migration'larını Uygulayın:**
    -   Projenin ana dizininde (yani `.sln` dosyasının olduğu yerde) bir terminal açın.
    -   Aşağıdaki komutu çalıştırarak veritabanını ve `Products` tablosunu oluşturun:
    ```sh
    dotnet ef database update --startup-project src/KayraExport.Api
    ```

4.  **Uygulamayı Çalıştırın:**
    -   Aynı terminalde, uygulamayı başlatmak için aşağıdaki komutu çalıştırın:
    ```sh
    dotnet run --project src/KayraExport.Api
    ```

5.  **API'ye Erişin:**
    -   Uygulama, terminalde belirtilen adresler üzerinde çalışmaya başlayacaktır. Hangi portları kullanacağını görmek için `src/KayraExport.Api/Properties/launchSettings.json` dosyasındaki `applicationUrl` alanını kontrol edebilirsiniz (Örneğin: `https://localhost:5020`).
    -   API'yi test etmek ve dokümantasyonu görmek için tarayıcınızda HTTPS adresinin sonuna `/swagger` ekleyerek gidin (Örneğin: `https://localhost:7001/swagger`).

### CI/CD ve PaaS Deploy

Bu proje, GitHub Actions ile basit bir Continuous Integration (CI) pipeline’ına sahiptir. Projeyi bir PaaS hizmetine (örn. Azure App Service, Render, Railway) deploy ederek Continuous Deployment (CD) süreci de kullanılabilir.

PaaS ortamında **DB_CONNECTION** isimli environment variable verilirse, uygulama bu değeri kullanacaktır.

Eğer environment variable sağlanmazsa, uygulama localdeki `appsettings.json` dosyasında tanımlı Options Pattern yapılandırmasını kullanır ve uygulama bu şekilde çalışmaya devam eder.

Bu sayede CI sayesinde her push sonrası build kontrolü yapılır, CD ile de PaaS ortamına otomatik deploy sağlanabilir.

---
