# Health Arc Slider

Unity'de Health Arc Slider, oyunlarda sağlık barları için özelleştirilmiş bir UI komponentidir. Arc şeklinde gradient dolum, frame, ve ortada HP yazısı ile modern bir görünüm sağlar.

## Özellikler

- **Arc Şekilli Health Bar**: Gradientli arc şeklinde sağlık barı
- **Vertical Fill**: Dikey dolum desteği
- **Frame Desteği**: Çerçeve sprite'ı ile profesyonel görünüm
- **HP Text**: Ortada HP yazısı ve değer gösterimi
- **Gradient Renkler**: Sağlık durumuna göre renk değişimi (yeşil->kırmızı)
- **Animasyonlu**: Smooth geçişler ve animasyonlar
- **Inspector Kontrolü**: Tüm özellikler Inspector'dan kolayca düzenlenebilir

## Kurulum

### 1. Dosyaları Kopyalama

Bu paket şu dosyaları içerir:

```
Assets/HealthArcSlider/
├── Scripts/
│   └── HealthArcSlider.cs
├── Sprites/
│   ├── arc_bar_gradient.png
│   └── frame.png
├── Prefabs/
│   └── HealthArcSlider.prefab
├── Scenes/
│   └── ExampleScene.unity
└── README.md
```

### 2. Unity'ye Import Etme

1. Unity projenizi açın
2. `Assets/HealthArcSlider/` klasörünü Unity projenizin `Assets/` klasörüne kopyalayın
3. Unity otomatik olarak dosyaları import edecektir

### 3. Prefab Kullanımı

1. **Prefab'i Sahneye Ekleme**:
   - `Assets/HealthArcSlider/Prefabs/HealthArcSlider.prefab` dosyasını Hierarchy'e sürükleyin
   - Prefab otomatik olarak World Space Canvas olarak ayarlanmıştır

2. **Konumlandırma**:
   - Prefab'i 3D uzayda istediğiniz konuma yerleştirin
   - Transform değerlerini ayarlayın

## Kullanım

### Inspector'dan Ayarlar

#### Health Bar Components
- **Arc Bar**: Sağlık barının görsel komponenti
- **Frame**: Çerçeve görsel komponenti
- **HP Text**: HP yazısı text komponenti
- **Mask Transform**: Maskeleme için kullanılan transform

#### Health Settings
- **Current Health**: Mevcut sağlık değeri (0-1 arası)
- **Max Health**: Maksimum sağlık değeri
- **Use Vertical Fill**: Dikey dolum kullanılıp kullanılmayacağı

#### Visual Settings
- **Healthy Color**: Sağlıklı durumda renk (yeşil)
- **Low Health Color**: Düşük sağlıkta renk (kırmızı)
- **Use Gradient Colors**: Gradient renk kullanılıp kullanılmayacağı
- **Animation Speed**: Animasyon hızı

#### Text Settings
- **HP Text Format**: HP yazısı formatı
- **Show Numeric Value**: Sayısal değer gösterilip gösterilmeyeceği
- **Show Percentage**: Yüzde gösterilip gösterilmeyeceği

#### Arc Settings
- **Total Arc Angle**: Toplam arc açısı (0-360 derece)
- **Start Angle**: Başlangıç açısı (-180 ila 180 derece)

### Script ile Kontrol

```csharp
using HealthArcSlider;

public class ExampleUsage : MonoBehaviour
{
    public HealthArcSlider healthSlider;
    
    void Start()
    {
        // Sağlık değerini ayarlama (0-1 arası)
        healthSlider.SetHealth(0.7f, true); // %70 sağlık, animasyonlu
        
        // HP değerleri ile ayarlama
        healthSlider.SetHealthByValue(70f, 100f, true); // 70/100 HP
        
        // Damage verme
        healthSlider.TakeDamage(0.2f); // %20 damage
        
        // Heal etme
        healthSlider.Heal(0.1f); // %10 heal
        
        // Tam sağlık
        healthSlider.RestoreHealth();
        
        // Mevcut sağlık değerini okuma
        float currentHealth = healthSlider.GetHealthRatio(); // 0-1 arası
        float currentHP = healthSlider.GetHealthValue(); // HP değeri
        
        // Rastgele sağlık değeri (test için)
        healthSlider.SetRandomHealth();
    }
}
```

### Önemli Metodlar

#### `SetHealth(float healthValue, bool animate = true)`
Sağlık değerini ayarlar (0-1 arası).
- `healthValue`: Sağlık oranı (0-1 arası)
- `animate`: Animasyon yapılıp yapılmayacağı

#### `SetHealthByValue(float currentHP, float maxHP, bool animate = true)`
HP değerleri ile sağlık ayarlar.
- `currentHP`: Mevcut HP
- `maxHP`: Maksimum HP
- `animate`: Animasyon yapılıp yapılmayacağı

#### `TakeDamage(float damageAmount)`
Damage verme.
- `damageAmount`: Damage miktarı (0-1 arası)

#### `Heal(float healAmount)`
Heal etme.
- `healAmount`: Heal miktarı (0-1 arası)

#### `RestoreHealth()`
Sağlığı tam doldurmak.

#### `GetHealthRatio()`
Mevcut sağlık oranını döndürür (0-1 arası).

#### `GetHealthValue()`
Mevcut HP değerini döndürür.

#### `SetRandomHealth()`
Rastgele sağlık değeri ayarlar (test için).

## Örnek Sahne

`Assets/HealthArcSlider/Scenes/ExampleScene.unity` dosyasını açarak Health Arc Slider'ın nasıl çalıştığını görebilirsiniz.

### Örnek Sahneyi Çalıştırma

1. `ExampleScene.unity` dosyasını açın
2. Play butonuna basın
3. Inspector'da test değerlerini değiştirerek sağlık barını kontrol edin
4. Runtime'da değerlerin nasıl animasyonlu olarak değiştiğini gözlemleyin

## Özelleştirme

### Sprite Değiştirme

Kendi sprite'larınızı kullanmak için:

1. `arc_bar_gradient.png` ve `frame.png` dosyalarını kendi sprite'larınız ile değiştirin
2. Sprite'ların import ayarlarını "Sprite (2D and UI)" olarak ayarlayın
3. Prefab'taki Image componentlerinde sprite referanslarını güncelleyin

### Renk Ayarları

```csharp
// Inspector'dan veya script ile
healthSlider.healthyColor = Color.green;
healthSlider.lowHealthColor = Color.red;
healthSlider.useGradientColors = true;
```

### Animasyon Hızı

```csharp
// Animasyon hızını ayarlama
healthSlider.animationSpeed = 3f;
```

### Text Formatı

```csharp
// HP text formatını ayarlama
healthSlider.hpTextFormat = "HEALTH";
healthSlider.showNumericValue = true;
healthSlider.showPercentage = false;
```

## Teknik Detaylar

### Bağımlılıklar

- Unity 2019.4 veya üstü
- Unity UI (uGUI) paketi

### Performans

- Animasyonlar Update() döngüsünde çalışır
- Sağlık değeri değişmediğinde animasyon otomatik olarak durur
- Gradient renk hesaplamaları optimize edilmiştir

### Dosya Yapısı

```
Assets/HealthArcSlider/
├── Scripts/
│   └── HealthArcSlider.cs           # Ana script
├── Sprites/
│   ├── arc_bar_gradient.png         # Gradient arc sprite
│   └── frame.png                    # Frame sprite
├── Prefabs/
│   └── HealthArcSlider.prefab       # Hazır prefab
├── Scenes/
│   └── ExampleScene.unity           # Demo sahne
└── README.md                        # Bu dosya
```

## Sorun Giderme

### Sağlık Barı Görünmüyor

- Canvas'ın World Space olarak ayarlandığından emin olun
- Kamera pozisyonunu kontrol edin
- Prefab'in Transform değerlerini kontrol edin
- Sprite'ların doğru import edildiğinden emin olun

### Animasyonlar Çalışmıyor

- `animationSpeed` değerinin 0'dan büyük olduğunu kontrol edin
- Component'in aktif olduğundan emin olun

### Text Görünmüyor

- HP Text component'inin assign edildiğinden emin olun
- Font'un doğru ayarlandığından emin olun
- Text renginin görünür olduğunu kontrol edin

### Sprite'lar Yanlış Görünüyor

- Sprite'ların "Sprite (2D and UI)" olarak import edildiğinden emin olun
- Image component'inin "Image Type" ayarını kontrol edin (Filled için "Filled")
- Fill Method ayarını kontrol edin (Radial 360 önerilir)

## Lisans

MIT License

## Katkı

Bu projeye katkıda bulunmak istiyorsanız:

1. Bu repository'yi fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/YeniOzellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/YeniOzellik`)
5. Pull Request oluşturun

## İletişim

Herhangi bir sorunuz veya öneriniz varsa GitHub Issues kısmından ulaşabilirsiniz.

## Sürüm Geçmişi

### v1.0.0
- İlk sürüm
- Health Arc Slider komponenti
- Gradient sprite desteği
- Frame sprite desteği
- HP text gösterimi
- Vertical fill desteği
- Animasyon sistemi
- Inspector'dan tam kontrol
- Örnek sahne ve dokumentasyon