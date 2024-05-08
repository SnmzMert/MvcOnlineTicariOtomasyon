
---

**MVC Online Ticari Otomasyon**

Firmanın müşterilerine satışı kolaylaştıran bir otomasyon web uygulaması.



Login Ekranı Bu şekilde: 

![Login](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/c8a14f19-da8f-4e6c-ad7a-9c487e2afebd)

Cariler ve Personeller buradan giriş yapabiliyorlar. Yeni Cari buradan kayıt olabiliyor. 

Personel Giriş yaptığında karşılaştığı ekran;

![İstatistik](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/9756af7c-f9b1-4e97-a76d-9771f0656f90)

Burda istatistikleri görebiliyor. 

Uygulama üzerinden  Satış oluşturulabiliyor , Fatura Kesiliyor, Cari Takibi yapılabiliyor, Personel Takibi Yapılabiliniyor.

Satışlar Kısmı: 

![Satış Admin ](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/04f6fbe1-5b07-42de-b943-a39a44d7eebd)  
Burada Satış Kayıtlarını görebiliyoruz , Promosyonlu satış ve Normla Satış olarak iki türlü satış var. 

Satış Kaydı:  
Burada Satışlarımızı Kontrol Edebiliyoruz.
![Satış KAYDI](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/67feb445-7fc4-4fc0-ae46-354afa0ec99a)

Normal Satış: İlk olarak normal satıştan bahsediyorum çünkü promosyonlu satışta bir kaç farklı parametrede devereye giriyor:)

![Bakiye Kritik](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/01112621-2146-4443-8356-8145c05e77e7)

Burada Carimizi seçiyoruz ve Carinin Bakiye durumunu görebiliyoruz, Eğer carinin bakiyesi belirlediğimizin değerin altındaysa(10.000 olarak belirledim) bize uyarı veriyor ve ekle butonumuz pasif hale geliyor yani Satış Yapamıyoruz. 

![Satış İşlem](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/7afb253c-2a68-49d8-8f0d-392dc7ca6a04) 

 Burada biraz uğraştım:)  Eğer Carimiz limiti varsa satış için bir engel yok. Şimdi ürünümüzü seçelim, Cari bir satışta birden fazla ürün olmak istiyor ve onları tek bir fatura olarak almak istiyor. Bunu rahatlıkla yapabiliyoruz.  
 Ürünü seçtiğimzde fiyatı ajax sorgusuyla fiyatı alıyorum. Satış yapılmak istenen miktarı yazınca Toplam Fiyat kısmımız otomatik güncelleniyor, SATIŞ FİYATI * MİKTAR sonucu Toplam Fiyatta yazıyor.   Ekle butonuna tıklayınca bu ürünü altta bir tablo oluşturup içine ekliyor, daha sonra en altta Satış yap butonumuz aktif hale geliyor, İstersen bir ürün satışı yapabilirsin, eğer başka üründe satılmak istenirse, aynı şekilde ürün seçimi yapılır ve ekle butonuna tıklanır, bu şekilde ikinci üründe tabloya eklenir, Eğere yanlışlıkla dropdowndandan cari değiştirilrese Tablo otomatik olarak sıfırlanır.
Personel Bilgisibi session üzerinden alıp  bilgilerini tabloya yazıyorum. Hangi personel satışı yapmışsa o yazılıyor.  Satış yapa tıklanınca Bunları satışını Gerçekleştiriyoruz. En üstteki Satış Numarası kısmını da şu şekil yaptık; 

![SerialNumber](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/6c480299-27c0-44a9-bffb-839647ea0878)

Bu satışın Faturalandırılması Gerekli. Bunu Fatura sayfasından yapabiliyoruz. 
![Faturalar](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/af222b3d-62b7-4387-98c0-f9aefa7aa510)

Bu ekranda oluşturulmuş faturaları görebiliyoruz, Yeni Fatura ekle kısmından yeni fatura oluşturuyouz. 

![Fatura Oluştur seçme](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/34ac722e-e1ae-4c4f-a9f4-0638b2134400)

Şimdi Burada en son yaptığımız satışın faturasını oluşturualım.  Mert Lojistiğie 3 Kalem ürün satılmıştı. 


![Faturayı OLuşturd](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/591e5495-8d14-4741-a74c-b74a3f2242d5)

Burada Açıklama, Vergi Dairesi ve Fatura Tarihini yazıyoruz ve Fatura oluştur diyoruz. 


Fatura detay ekranında oluşturulan faturalarımızın detaylarını görebiliyoruz.
![Fatura Detay](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/ac9ab180-4346-4971-b32e-3a3759cb9fdb)


Hızlıca Promosyonlu Satış ekranına dönelim.  

Bunun için önce Ürün puan tanımını yapmalıyız. 

![Puan tanımlama](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/ec8a56c3-c34d-41e1-95fc-5e505ae751d9)

Burada yaptığımız tanımlamayı Promosyonlu satış kısmında kullanacağız. 


Şimdi de Promosyonlu ürünümüzü belirleyip Gerekli puanı tanımlıyoruz. 

![Promosyon ](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/03e5c5a9-0283-4bbd-8fa5-e2b55e5a11ff)


Evet Promosyonlu satış için Her şeyimiz hazır. 
Burada siparişteki ürünlerimizin toplam puanı Promosyon puanınına eşit veya katıysa ona göre ürün faturada 0 tl olarak eklenmiş oluyor 

![Promosyonlu Satış](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/32fe1b68-75e2-424a-a73b-cd47323e5ad9)



Hızlı Bakış kısmındanda Ürünlerimizi, Ürünlerimizin Stoklarını, Carileri, Personelleri. Nerdeyse tüm Herşeyi Görebildiğimiz bir ekran
![Hızlı Tablolar](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/51e8a7f3-0f4e-4b40-bf2c-c620b6a64732)


Yaznını Uzadığının Farkındayım O Yüzden son olarakta Personel ekranını paylaşıp bitiyorum.



![Personeller](https://github.com/SnmzMert/MvcOnlineTicariOtomasyon/assets/109958428/e260268e-fee5-4bdb-828b-f0b31e2cf0cb)


Umarım Projeyi beğenmişsinizdir. Eğitim Projelerinde sadece anlatılanları geçirmek dışında kendim bir şeyler katmayı seviyorum. Eğitimin dışınada çıksam bu şekilde daha çok bilgi ediniyorum. 

Murat Yücedağ ve Erhan Gündüze sevgilerimle. 
