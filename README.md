# MiniECommerce

* appsettings.json dosyasından ConnectionString bilgisayarınıza göre ayarlanmalıdır.
* Proje çalıştırıldığında veritabanı ve örnek veriler otomatik olarak oluşmaktadır.
* Script dosyası bu reponun içerisindedir. (MiniECommerceDbScript.sql)
* Test kullanıcı bilgileri aşağıdaki gibidir. Bu kullanıcılar ile test edebilirsiniz.

Yetki: User

Kullanıcı Adı: test

Şifre: 123456

--------------------------

Yetki: Admin

Kullanıcı Adı: admin

Şifre: 123456

---------------------------

YETKİLERE GÖRE ENDPOINTLER

* /api/Authentication/Register -> Herkes erişebilir. Kullanıcı kaydetme işleminde "user" ve "admin" yetkisi seçilebilir. Ekstra kaydet metodu yazmamak için basit bir yöntemle bunu yaptım.

* /api/Authentication/Login -> Herkes erişebilir. Kullanıcı girişi için.


* /api/Products/CreateProduct-> Admin erişebilir. Ürün kaydetme işlemi yapılmaktadır.

* /api/Products/UpdateProduct -> Admin erişebilir. Ürün güncelleme işlemi yapılmaktadır.

* /api/Products/UpdateProductStock -> Admin erişebilir. Ürünün sadece stok bilgisini günceller.

* /api/Products/DeleteProduct -> Admin erişebilir. Ürün silme işlemi yapılmaktadır.

* /api/Products/GetProducts -> Herkes erişebilir. Tüm ürünleri listeler.

* /api/Products/GetProductById -> Herkes erişebilir. Verilen ürün Id için detay bilgisi getirilir.


* /api/Baskets/CreateBasketItem -> User erişebilir. Ürün Id ve adetine göre sepete ekleme yapar. Sepet yok ise oluşturur varsa üzerine ekleme yapar.

* /api/Baskets/UpdateBasketItemQuantity -> User erişebilir. Sepetin içinde bulunan kayıt için adetini arttırma yada eksiltme yapar. (BasketItem)

* /api/Baskets/ClearBasket -> User erişebilir. Kullanıcının bulunan aktif sepetini temizler.

* /api/Baskets/GetBasketItems -> User erişebilir. Sepetin içindeki kayıtları getirir. (BasketItem)


* /api/Orders/CreateOrder -> User erişebilir. Kullanıcının aktif sepeti için sipariş oluşturur.

* /api/Orders/CancelOrder -> User erişebilir. Kullanıcının oluşturduğu siparişi iptal eder.

* /api/Orders/GetUserOrders -> User erişebilir. Kullanıcının siparişlerini listeler.

* /api/Orders/GetUserOrderWithItems -> User erişebilir. Siparişin detaylarını listeler.

* /api/Orders/AdminCancelOrder -> Admin erişebilir. Oluşturulmuş bir siparişi iptal eder.

* /api/Orders/AdminApproveOrder -> Admin erişebilir. Oluşturulmuş siparişi onaylar.

* /api/Orders/GetAdminOrders -> Admin erişebilir. Siparişleri listeler.

* /api/Orders/GetAdminOrderWithItems -> Admin erişebilir. Herhangi bir siparişin detaylarını listeler.
