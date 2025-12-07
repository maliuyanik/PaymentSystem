# Payment System Architecture (.NET 9 / C#)

Bu proje, **Object-Oriented Programming (OOP)** prensiplerinin ve modern **.NET** mimarisinin uygulanmasını simüle eden modüler bir ödeme sistemi altyapısıdır.

Mevcut Java tecrübemi ve OOP yetkinliğimi, **C# ve .NET ekosistemine** adapte etmek amacıyla; daha önce Java ile geliştirdiğim bir mimariyi **syntax, bellek yönetimi ve yapısal farklılıkları (Java vs C#)** analiz ederek .NET 9 üzerinde yeniden inşa ettim.

## Projenin Amacı ve Kazanımlar
Bu projeyi geliştirirken odaklandığım temel teknikler ve C# özellikleri:

* **Modern C# Özellikleri:** `.NET 9`, `File-scoped namespaces`, `Top-level statements` (tercihe bağlı), `Global usings`.
* **Immutability & Güvenlik:** Veri bütünlüğü için `init-only` property'ler ve encapsulation.
* **Veri Tipleri:** Java'daki `UUID` yerine `.NET 9` ile gelen sıralı **UUID v7 (`Guid.CreateVersion7`)** kullanımı.
* **Pattern Matching:** `Switch expressions` kullanılarak daha okunabilir kod yapısı.
* **Extension Methods:** Enum yönetimi için Java stili sınıflar yerine C#'a özgü **Extension Method** yaklaşımı.
* **Polymorphism & Abstraction:** `BasePayment` abstract sınıfı ve `IPaymentProcessor` arayüzü ile loosely coupled mimari.
* **Validation:** Constructor seviyesinde **Fail-Fast** ilkesi ve Crypto Wallet validation için **Regex Source Generators**.
* **Mocking:** `INetworkConnection` arayüzü üzerinden bağımlılıkların (Dependency Injection) yönetilmesi ve test edilebilir yapı.

## Mimari Yapı

Proje, genişletilebilir (Open/Closed Principle) bir yapıda tasarlanmıştır:

* **BasePayment (Abstract):** Tüm ödeme yöntemlerinin atası. Temel ID, tarih ve validasyon kurallarını yönetir.
* **CreditCardPayment:** Kredi kartı spesifik validasyonları ve maskeleme işlemlerini içerir.
* **CryptoPayment (Abstract & Concrete):** Kripto ödemeleri için özelleştirilmiş altyapı. `BitcoinPayment` ve `EthereumPayment` sınıfları, ilgili Regex kurallarını **compile-time** üreterek performans sağlar.
