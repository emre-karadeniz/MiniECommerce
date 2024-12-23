# MiniECommerce

## Proje Kurulumu
- appsettings.json dosyasından ConnectionString bilgisayarınıza göre ayarlanmalıdır.
- Proje çalıştırıldığında veritabanı ve örnek veriler otomatik olarak oluşmaktadır.
- Script dosyası bu reponun içerisindedir: *MiniECommerceDbScript.sql*

## Test Kullanıcıları
Proje içerisinde aşağıdaki test kullanıcıları tanımlıdır. Bu kullanıcılar ile API'yi test edebilirsiniz.

| Yetki   | Kullanıcı Adı | Şifre  |
|---------|---------------|--------|
| User    | test          | 123456 |
| Admin   | admin         | 123456 |

## API Endpointleri

| Endpoint                                | Erişim       | Açıklama                          |
|-----------------------------------------|--------------|------------------------------------|
| POST /api/Authentication/Register     | Herkes       | Yeni kullanıcı kaydı oluşturur.   |
| POST /api/Authentication/Login        | Herkes       | Kullanıcı girişi yapar.           |
| POST /api/Baskets/CreateBasketItem    | Kullanıcı    | Sepete ürün ekler.                |
| PATCH /api/Baskets/UpdateBasketItemQuantity | Kullanıcı | Sepetteki ürün miktarını günceller. |
| DELETE /api/Baskets/ClearBasket       | Kullanıcı    | Sepeti temizler.                  |
| GET /api/Baskets/GetBasketItems       | Kullanıcı    | Sepet içeriklerini getirir.       |
| POST /api/Orders/CreateOrder          | Kullanıcı    | Yeni sipariş oluşturur.           |
| PATCH /api/Orders/CancelOrder         | Kullanıcı    | Siparişi iptal eder.              |
| PATCH /api/Orders/AdminCancelOrder    | Yönetici     | Siparişi iptal eder. |
| PATCH /api/Orders/AdminApproveOrder   | Yönetici     | Siparişi onaylar. |
| GET /api/Orders/GetAdminOrders        | Yönetici     | Tüm siparişleri listeler.         |
| GET /api/Orders/GetAdminOrderWithItems| Yönetici     | Sipariş bilgilerini ve detaylarını getirir.|
| GET /api/Orders/GetUserOrders         | Kullanıcı    | Kullanıcı siparişlerini listeler. |
| GET /api/Orders/GetUserOrderWithItems | Kullanıcı    | Kullanıcı sipariş bilgilerini ve detayını getirir. |
| POST /api/Products/CreateProduct      | Yönetici     | Yeni ürün ekler.                  |
| PUT /api/Products/UpdateProduct       | Yönetici     | Mevcut ürünü günceller.           |
| PATCH /api/Products/UpdateProductStock| Yönetici     | Ürün stok bilgisini günceller.  |
| DELETE /api/Products/DeleteProduct    | Yönetici     | Ürünü siler.                      |
| GET /api/Products/GetProducts         | Herkes       | Ürün listesini getirir.           |
| GET /api/Products/GetProductById      | Herkes       | Belirli bir ürünü getirir.        |
