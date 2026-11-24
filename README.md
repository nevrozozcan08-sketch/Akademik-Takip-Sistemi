# Akademik Takip Sistemi

## Proje hangi problemi çözüyor?

Bölüm sekreterleri ve danışmanlar öğrenci bilgilerini, ders kayıtlarını, sınav notlarını ve danışman görüşlerini çoğu zaman ayrı Excel dosyalarında ve kâğıt üzerinde tutuyor. Bu yüzden bir öğrencinin not durumuna ya da aldığı derslere bakmak zaman alıyor, veriler birbiriyle çelişebiliyor ve ortalama hesaplarında hata yapılabiliyor.

Akademik Takip Sistemi bu bilgileri tek bir masaüstü uygulamasında ve tek bir veritabanında topluyor. Öğrenci kaydı, ders atama, not girişi ve otomatik ortalama hesabı, bölüm ve danışman bilgileri, ders programı ve raporlar aynı yerden yönetiliyor.

## Kimin için geliştirildi?

- **Bölüm sekreterleri / öğrenci işleri personeli:** öğrenci kaydı, ders atama ve not girişi yapar.
- **Akademik danışmanlar:** öğrencilerinin not ortalamalarını ve aldığı dersleri görür, danışman görüşü yazar.

## İş takip panosu

Pano bağlantısı: https://github.com/users/nevrozozcan08-sketch/projects/4

Panoda "Yapılacak", "Devam Ediyor" ve "Tamamlandı" sütunları vardır (GitHub arayüzünde İngilizce olarak Todo = Yapılacak, In Progress = Devam Ediyor, Done = Tamamlandı şeklinde görünür). Her kartta görevin açıklaması ve kabul kriterleri bulunur. Bu dönem geliştirilen iki görev "Tamamlandı" sütunundadır ve ilgili commit'ler kartlara bağlıdır:

- #2 Öğrenci listesinde ad/numara ile arama: commit [c25b750](https://github.com/nevrozozcan08-sketch/Akademik-Takip-Sistemi/commit/c25b750)
- #3 Not girişinde doğrulama ve tutarlı ortalama: commit [c5c70d3](https://github.com/nevrozozcan08-sketch/Akademik-Takip-Sistemi/commit/c5c70d3)

## Kullanılan teknolojiler

- C# Windows Forms (.NET Framework 4.7.2)
- Microsoft SQL Server (veritabanı: `OkulOtomasyon`)

## Projeyi çalıştırma adımları

**Gerekenler:** Windows, Visual Studio (".NET masaüstü geliştirme" iş yükü ile), SQL Server Express ve SQL Server Management Studio (SSMS).

1. Depoyu indirin: `git clone https://github.com/nevrozozcan08-sketch/Akademik-Takip-Sistemi.git` (veya GitHub'da **Code → Download ZIP**).
2. **Veritabanını kurun:** SSMS'i açıp SQL Server'a bağlanın. `veritabanı/OkulOtomasyon.sql` dosyasını açıp **Execute (F5)** ile çalıştırın. Bu işlem `OkulOtomasyon` veritabanını tablolarıyla ve örnek verilerle oluşturur.
3. **Dosya engelini kaldırın (gerekirse):** Proje ZIP olarak indirildiyse Windows dosyaları "internetten geldi" diye işaretler ve Visual Studio derlemez. PowerShell'de proje klasöründe `Get-ChildItem -Recurse | Unblock-File` komutunu çalıştırın.
4. **Bağlantı adresini kendi sunucunuza göre ayarlayın:** Proje şu an `NEVROZ\SQLEXPRESS02` sunucusuna bağlanacak şekilde yazılmıştır. Visual Studio'da **Ctrl+Shift+H** (Tüm dosyalarda değiştir) ile `NEVROZ\SQLEXPRESS02` ifadesini kendi sunucu adınızla değiştirin (örneğin `.\SQLEXPRESS` veya `localhost\SQLEXPRESS`). Sunucu adını SSMS'teki bağlantı penceresinde görebilirsiniz.
5. Depo kökündeki `AkademikTakipSistemi.sln` dosyasını Visual Studio ile açın.
6. **F5** ile projeyi derleyip çalıştırın.
7. Giriş ekranında örnek kullanıcıyla giriş yapın: Kullanıcı adı **nevroz.ozcan**, şifre **1234**.

## Geliştirilen iki özelliği deneme

### 1. Öğrenci listesinde ada veya numaraya göre arama

1. Ana menüden **ÖĞRENCİ İŞLEMLERİ** butonuna tıklayın.
2. Sağ üstteki **"Ara (Ad / Numara)"** kutusuna bir öğrencinin adından birkaç harf yazın.
3. **Beklenen sonuç:** Liste siz yazarken anında süzülür ve yalnızca adı veya numarası yazdığınız metni içeren öğrenciler kalır.
4. Kutuya bir öğrenci numarasının bir kısmını yazın. Numarası eşleşen öğrenci görünür.
5. Kutuyu temizleyin. Tüm öğrenciler yeniden listelenir.

### 2. Not girişinde doğrulama ve tutarlı ortalama hesabı

1. Ana menüden **NOT İŞLEMLERİ** butonuna, açılan ekranda **Not Ekle** butonuna tıklayın.
2. Vize kutusuna `abc` yazıp **Hesapla**'ya basın. **Beklenen sonuç:** "Vize notu sayı olmalıdır." uyarısı çıkar ve kayıt yapılmaz.
3. Final kutusuna `120` yazıp **Hesapla**'ya basın. **Beklenen sonuç:** "Final notu 0 ile 100 arasında olmalıdır." uyarısı çıkar.
4. Vize `40`, Final `70` yazıp **Hesapla**'ya basın. **Beklenen sonuç:** Ortalama **58,00** (40×0,4 + 70×0,6) ve durum **Geçti** (yeşil) görünür.
5. Bir öğrenci ve ders seçip **Kaydet**'e basın, sonra Not Ekle penceresini kapatın. Not listesi kendiliğinden yenilenir ve yeni kaydın ortalaması ekrandaki değerle aynıdır (58). Eskiden kaydetme işlemi ortalamayı (vize+final)/2 ile hesaplıyordu ve 55 kaydediyordu.
