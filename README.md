# PortfolioSite

ASP.NET Core MVC ile geliştirilmiş, iki dilli (TR/EN) ve yönetim paneli olan kişisel portfolyo web sitesi. Sitedeki tüm içerik (ana sayfa, hakkımda, projeler, yetenekler, linkler, iletişim paneli, footer) admin panelinden kod yazmadan yönetilir.

**Canlı site:** https://yeldabatti-portfolio-chbbeud5fegqbvds.westeurope-01.azurewebsites.net

## Özellikler

- **Dinamik içerik:** Tüm bölümler veritabanından gelir, admin panelinden düzenlenir
- **Çok dilli:** TR | EN seçici, cookie ile dil hatırlama, `.resx` ile sabit yazılar
- **Yönetim paneli:** Hero, Hakkımda, Projeler (3 kart tipi, görsel yükleme), Yetenekler, Sosyal Linkler, İletişim paneli ve konular, Footer, Site Ayarları (CV yükleme), Gelen Mesajlar
- **İletişim formu:** Sunucu doğrulaması, anti-forgery jetonu, honeypot ve e-posta bazlı gönderim sınırı
- **Güvenlik:** ASP.NET Core Identity, hesap kilitleme, güvenli dosya yükleme (uzantı ve içerik imzası kontrolü), link şeması doğrulaması
- **Özel hata ve 404 sayfaları**

## Teknolojiler

- C#, .NET 10, ASP.NET Core MVC
- Entity Framework Core + SQLite
- ASP.NET Core Identity
- View Components, Areas (Admin)
- Tailwind CSS (CDN), Razor
- Azure App Service ile yayınlandı

## Proje Yapısı
PortfolioSite/
├── Areas/Admin/ Yönetim paneli (controller ve görünümler)
├── Controllers/ Site controller’ları (Default, Contact, Language)
├── DAL/ Context ve Entities
├── Helpers/ MarkupHelper, ImageUploader
├── Resources/ TR/EN .resx dosyaları
├── ViewComponents/ Bölüm bileşenleri (Hero, Skill, Project, About, Contact, Footer)
├── ViewModels/
├── Views/
└── wwwroot/

## Yerel Çalıştırma

Gereksinimler: .NET 10 SDK

```bash
git clone https://github.com/yelda-batti0/PortfolioSite.git
cd PortfolioSite
```

Admin kullanıcısı için User Secrets tanımla:

```bash
dotnet user-secrets set "AdminUser:Email" "ornek@ornek.com"
dotnet user-secrets set "AdminUser:Password" "GucluBirSifre!42"
```

Çalıştır:

```bash
dotnet run
```

Veritabanı (`portfolio.db`) ilk açılışta otomatik oluşturulur. Admin paneli: `/Admin`

## Notlar

- `portfolio.db` ve `wwwroot/uploads` güvenlik için repoya dahil edilmemiştir.
- Şifreler ve kişisel bilgiler koda yazılmaz, User Secrets veya ortam değişkenleri ile verilir.

## Lisans

Tüm hakları saklıdır. © Yelda Battı
