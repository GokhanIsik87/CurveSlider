# CurveSlider

CurveSlider, Unity'de World Space Canvas kullanarak 3 adet arc (curve) Image ve bir Level Text içeren, kolayca özelleştirilebilir bir UI komponentidir.

## Özellikler

- **3 Adet Arc Slider**: Her biri bağımsız olarak kontrol edilebilen arc şeklinde sliderlar
- **World Space Canvas**: 3D uzayda kullanılabilen UI elemanları
- **Inspector'dan Kontrol**: Tüm özellikler Inspector'dan kolayca düzenlenebilir
- **Animasyon Desteği**: Smooth animasyonlar ile değer değişimleri
- **Renk Özelleştirme**: Her arc için farklı renk ayarları
- **Level Display**: Dinamik olarak güncellenen level gösterimi

## Kurulum

### 1. Dosyaları Kopyalama

Bu repository'yi indirin veya klonlayın:

```bash
git clone https://github.com/GokhanIsik87/CurveSlider.git
```

### 2. Unity'ye Import Etme

1. Unity projenizi açın
2. `Assets/CurveSlider/` klasörünü Unity projenizin `Assets/` klasörüne kopyalayın
3. Unity otomatik olarak dosyaları import edecektir

### 3. Prefab Kullanımı

1. **Prefab'i Sahneye Ekleme**:
   - `Assets/CurveSlider/Prefabs/CurveArcSlider.prefab` dosyasını Hierarchy'e sürükleyin
   - Prefab otomatik olarak World Space Canvas olarak ayarlanmıştır

2. **Konumlandırma**:
   - Prefab'i 3D uzayda istediğiniz konuma yerleştirin
   - Transform değerlerini ayarlayın

## Kullanım

### Inspector'dan Ayarlar

#### Arc Slider Ayarları
Her arc slider için aşağıdaki ayarlar mevcuttur:

- **Arc Image**: Slider'ın görsel komponenti
- **Current Value**: Mevcut değer (0-1 arası)
- **Max Value**: Maksimum değer (0-1 arası)
- **Arc Color**: Slider'ın rengi
- **Animation Speed**: Animasyon hızı
- **Total Arc Angle**: Toplam arc açısı (0-360 derece)
- **Start Angle**: Başlangıç açısı (-180 ila 180 derece)

#### Level Display Ayarları
- **Level Text**: Text komponenti referansı
- **Level Prefix**: Level yazısının başında gösterilecek metin
- **Current Level**: Mevcut level değeri

#### Global Ayarlar
- **Auto Update**: Otomatik güncelleme açık/kapalı
- **Global Animation Speed**: Tüm slider'lar için genel animasyon hızı

#### Test Ayarları (Sadece Editor'da)
- **Test Value 1, 2, 3**: Editor'da test etmek için kullanılabilir

### Script ile Kontrol

```csharp
using CurveSlider;

public class ExampleUsage : MonoBehaviour
{
    public CurveArcSlider curveSlider;
    
    void Start()
    {
        // Tek bir slider'ın değerini ayarlama
        curveSlider.SetSliderValue(0, 0.7f, true); // İlk slider'ı %70'e animasyonlu ayarla
        
        // Tüm slider'ları birden ayarlama
        float[] values = {0.5f, 0.8f, 0.3f};
        curveSlider.SetAllSliderValues(values, true);
        
        // Level ayarlama
        curveSlider.SetLevel(5);
        
        // Slider değerini okuma
        float value = curveSlider.GetSliderValue(0);
        
        // Rastgele değerler ayarlama (test için)
        curveSlider.SetRandomValues();
        
        // Slider'ları sıfırlama
        curveSlider.ResetSliders();
    }
}
```

### Önemli Metodlar

#### `SetSliderValue(int sliderIndex, float value, bool animate = true)`
Belirtilen indeksteki slider'ın değerini ayarlar.
- `sliderIndex`: Slider indeksi (0-2)
- `value`: Yeni değer (0-1 arası)
- `animate`: Animasyon yapılıp yapılmayacağı

#### `SetAllSliderValues(float[] values, bool animate = true)`
Tüm slider'ların değerlerini bir seferde ayarlar.
- `values`: Değer dizisi
- `animate`: Animasyon yapılıp yapılmayacağı

#### `GetSliderValue(int sliderIndex)`
Belirtilen indeksteki slider'ın mevcut değerini döndürür.

#### `SetLevel(int level)`
Level metnini günceller.

#### `ResetSliders()`
Tüm slider'ları varsayılan değerlerine (0.5) sıfırlar.

#### `SetRandomValues()`
Tüm slider'lara rastgele değerler atar (test için kullanışlı).

## Örnek Sahne

`Assets/CurveSlider/Scenes/ExampleScene.unity` dosyasını açarak CurveSlider'ın nasıl çalıştığını görebilirsiniz.

### Örnek Sahneyi Çalıştırma

1. `ExampleScene.unity` dosyasını açın
2. Play butonuna basın
3. Inspector'da test değerlerini değiştirerek slider'ları kontrol edin
4. Runtime'da değerlerin nasıl animasyonlu olarak değiştiğini gözlemleyin

## Özelleştirme

### Renk Ayarları

Her arc slider için farklı renkler ayarlayabilirsiniz:

```csharp
// Inspector'dan veya script ile
curveSlider.arcSliders[0].arcColor = Color.red;
curveSlider.arcSliders[1].arcColor = Color.green;
curveSlider.arcSliders[2].arcColor = Color.blue;
```

### Animasyon Hızı

Animasyon hızını global olarak veya her slider için ayrı ayrı ayarlayabilirsiniz:

```csharp
// Global hız
curveSlider.globalAnimationSpeed = 3f;

// Bireysel hız
curveSlider.arcSliders[0].animationSpeed = 1f;
```

### Arc Açısı ve Başlangıç Pozisyonu

Her arc'ın görsel özelliklerini ayarlayabilirsiniz:

```csharp
// Arc açısı (270 derece = 3/4 daire)
curveSlider.arcSliders[0].totalArcAngle = 270f;

// Başlangıç açısı (-135 derece = sol üst)
curveSlider.arcSliders[0].startAngle = -135f;
```

## Teknik Detaylar

### Bağımlılıklar

- Unity 2019.4 veya üstü
- Unity UI (uGUI) paketi

### Performans

- Otomatik güncelleme kapalıysa performans daha iyidir
- Animasyonlar Update() döngüsünde çalışır
- Slider değerleri değişmediğinde animasyon otomatik olarak durur

### Dosya Yapısı

```
Assets/CurveSlider/
├── Scripts/
│   └── CurveArcSlider.cs
├── Prefabs/
│   └── CurveArcSlider.prefab
├── Scenes/
│   └── ExampleScene.unity
└── README.md
```

## Sorun Giderme

### Slider'lar Görünmüyor

- Canvas'ın World Space olarak ayarlandığından emin olun
- Kamera pozisyonunu kontrol edin
- Prefab'in Transform değerlerini kontrol edin

### Animasyonlar Çalışmıyor

- `autoUpdate` özelliğinin aktif olduğundan emin olun
- `globalAnimationSpeed` değerinin 0'dan büyük olduğunu kontrol edin

### Inspector'da Değişiklikler Görünmüyor

- Play mode'da değişiklik yapıyorsanız, stop'a bastığınızda değişiklikler kaybolur
- Prefab'i edit mode'da düzenleyin

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
- 3 adet arc slider
- World Space Canvas desteği
- Animasyon sistemi
- Level display sistemi
- Inspector'dan tam kontrol