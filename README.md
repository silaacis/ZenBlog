# ZenBlog

**ZenBlog**, ASP.NET Core Web API ve Angular kullanılarak geliştirilmiş modern bir full-stack blog platformudur. Kullanıcıların blog yazılarını görüntüleyebildiği, admin paneli üzerinden içerik yönetiminin yapılabildiği bir sistemdir.

---

## 📋 Proje Hakkında

ZenBlog, sade ve kullanıcı dostu arayüzü ile blog içeriklerinin kolayca keşfedilmesini sağlar.  
Frontend ve backend ayrı katmanlar halinde geliştirilmiş olup modern web geliştirme prensiplerine uygun şekilde tasarlanmıştır.

Uygulamada kullanıcılar:
- Blog yazılarını listeleyebilir  
- Kategorilere göre filtreleyebilir  
- Blog detaylarını görüntüleyebilir  

Admin kullanıcılar ise:
- Blog ve kategori yönetimi yapabilir  
- Sisteme yeni içerikler ekleyebilir  

---

## 🚀 Özellikler

### 📰 Kullanıcı Tarafı
- Blog listeleme  
- Kategori bazlı filtreleme  
- Blog detay sayfası  
- Yazar bilgisi gösterimi  
- Öne çıkan bloglar (slider)  
- Responsive tasarım  

### 🔐 Admin Paneli & Authentication
- Token tabanlı authentication (JWT)  
- Güvenli kullanıcı girişi  
- Yetkilendirme (Authorization)  
- Admin paneli  
- Blog yönetimi (CRUD)
  - Blog ekleme  
  - Blog güncelleme  
  - Blog silme  
- Kategori yönetimi  

---

## 🛠️ Kullanılan Teknolojiler

### 🔹 Frontend
- Angular  
- TypeScript  
- HTML / CSS  
- Bootstrap  

### 🔹 Backend
- ASP.NET Core Web API  
- C#  
- Entity Framework Core  
- JWT Authentication & Authorization  

### 🔹 Mimari
- Clean Architecture  
- RESTful API  

---

## ⚙️ Kurulum



```bash
Backend
cd ZenBlogServer
dotnet restore
dotnet run


Frontend
cd ZenBlogClient
npm install
ng serve

Uygulama

Frontend:
👉 http://localhost:4200

Backend:
👉 http://localhost:5000 (veya proje ayarına göre)
