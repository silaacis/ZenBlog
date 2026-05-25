# 📚 ZenBlog

Modern ve şık bir blog platformu. Yazılarınızı paylaşın, okuyucularınıza ulaşın ve içeriğinizi güvenli bir şekilde yönetin. Clean Architecture ilkelerine göre geliştirilmiş, hem masaüstü hem de mobil cihazlarda sorunsuz çalışan bir tam uygulamadır.

## ✨ Proje Hakkında

ZenBlog, full-stack bir blog platformu olarak tasarlanmıştır. Minimalist ve kullanıcı dostu arayüzü sayesinde okuyucular blog yazılarını rahatça keşfedebilirler. Admin paneli ise blog yazarlarına içerik yönetimi için güçlü araçlar sunar.

### 👥 Kullanıcılar Ne Yapabilir?
- 📖 Blog yazılarını rahatça okuyabilir
- 🏷️ Kategorilere göre ilgi alanlarına uygun yazıları filtreleyebilir
- 👨‍💻 Yazarlar hakkında bilgi alabilir
- ⭐ Öne çıkan yazıları slider ile görüntüleyebilir

### 🔐 Admin Paneli
- ✍️ Yeni blog yazıları ekleyebilir
- ✏️ Mevcut yazıları düzenleyebilir
- 🗑️ Yazıları silebilir
- 📂 Kategorileri yönetebilir
- 🔒 Güvenli login sistemi ile hesap koruması

## 🛠️ Teknoloji Stack'i

**Frontend** (Arayüz):
- Angular - Modern web framework
- TypeScript - Tip güvenliği sağlayan dil
- HTML / CSS - Sayfa yapısı ve stillemesi
- Bootstrap - Responsive tasarım kütüphanesi

**Backend** (Sunucu Tarafı):
- ASP.NET Core Web API - Güçlü ve hızlı API geliştirme
- C# - Modern ve tip güvenli programlama dili
- Entity Framework Core - Veritabanı yönetimi

**Güvenlik**:
- JWT Authentication - Token tabanlı güvenli giriş sistemi
- Authorization - Kullanıcı yetkilendirmesi

**Mimari**:
- Clean Architecture - Temiz ve bakım yapılabilir kod yapısı
- RESTful API - Standart API tasarımı

## 🚀 Hızlı Başlangıç

### Gereksinimler

Başlamadan önce bilgisayarınızda yüklü olması gerekenler:
- **.NET SDK** (v8 veya üzeri) - Backend çalıştırmak için
- **Node.js** (v18 veya üzeri) - Frontend bağımlılıkları
- **npm** (Node Package Manager) - Paket yöneticisi
- **Angular CLI** - Angular uygulaması çalıştırmak için

### Adım Adım Kurulum

#### 1️⃣ Projeyi Bilgisayarınıza İndirin

```bash
git clone https://github.com/silaacis/ZenBlog
cd ZenBlog
```

#### 2️⃣ Backend Kurulumu (ASP.NET Core)

```bash
# Backend klasörüne gidin
cd ZenBlogServer

# Bağımlılıkları geri yükleyin
dotnet restore

# Backend sunucusunu başlatın
dotnet run
```

✅ Backend başarıyla çalışıyorsa şu mesajı göreceksiniz:
```
Backend çalışıyor: http://localhost:5000
```

#### 3️⃣ Frontend Kurulumu (Angular)

Yeni bir terminal penceresi açıp:

```bash
# Ana proje klasörüne geri dönün
cd ..

# Frontend klasörüne gidin
cd ZenBlogClient

# Gerekli npm paketlerini yükleyin
npm install

# Frontend geliştirme sunucusunu başlatın
ng serve
```

✅ Frontend başarıyla çalışıyorsa şu mesajı göreceksiniz:
```
Frontend çalışıyor: http://localhost:4200
```

### 🌐 Uygulamaya Erişim

Kurulum tamamlandıktan sonra:

- **Ana Sayfa**: http://localhost:4200
  - Blog yazılarını okuyabilir
  - Kategorilere göre filtreleyebilirsiniz

- **Admin Paneli**: http://localhost:4200/admin
  - Kullanıcı adı ve şifre ile giriş yapın
  - Blog ve kategori yönetimine erişin

- **Backend API**: http://localhost:5000
  - Tüm API endpoint'lerine buradan ulaşabilirsiniz

---

## 📁 Proje Yapısı

```
ZenBlog/
├── ZenBlogServer/          # Backend (ASP.NET Core)
│   ├── Controllers/        # API uç noktaları
│   ├── Models/             # Veri modelleri
│   ├── Services/           # İş mantığı
│   └── appsettings.json    # Ayarlar
│
├── ZenBlogClient/          # Frontend (Angular)
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/ # Sayfa bileşenleri
│   │   │   ├── services/   # API çağrıları
│   │   │   └── models/     # Veri modelleri
│   │   └── assets/         # Görseller
│   └── package.json        # Bağımlılıklar
│
└── README.md               # Bu dosya
```

---

## 🔐 Güvenlik Özellikleri

- 🔒 **JWT Token Tabanlı Giriş** - Güvenli oturum yönetimi
- 🛡️ **Role-Based Authorization** - Rol bazlı yetkilendirme
- 🔑 **Şifrele Koruma** - Şifreler güvenli şekilde saklanır
- ✅ **CORS Ayarları** - Frontend-Backend iletişimi güvenli
