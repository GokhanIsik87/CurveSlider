# CurveSlider

Unity için hazırlanmış özelleştirilebilir arc (curve) slider component'i. World Space Canvas ile çalışır ve inspector üzerinden kolayca kontrol edilebilir.

## Özellikler

- **3 Arc Slider**: Her biri ayrı ayrı kontrol edilebilen 3 adet arc image
- **Level Text**: Seviye göstergesi
- **Inspector Kontrolü**: Tüm parametreler inspector üzerinden ayarlanabilir
- **Animasyonlu Geçişler**: Yumuşak geçiş animasyonları
- **World Space Canvas**: 3D dünyada kullanıma uygun
- **Özelleştirilebilir Renkler**: Her arc için farklı renk ayarı
- **Runtime Kontrolü**: Oyun sırasında değerler değiştirilebilir

## Kurulum

1. **Unity Projenize İmport Edin**:
   - `Assets/CurveSlider/` klasörünü Unity projenizin Assets klasörüne kopyalayın
   - Unity Editor'da Assets menüsünden "Refresh" yapın

2. **Prefab'ı Sahneye Ekleyin**:
   - Project penceresinden `Assets/CurveSlider/CurveArcSlider.prefab` dosyasını bulun
   - Prefab'ı Hierarchy penceresine sürükleyin
   - Veya GameObject > UI > CurveArcSlider menüsünden ekleyin

## Kullanım

### Inspector Ayarları

**Arc Sliders**:
- `Arc Image`: Her arc için UI Image component'i
- `Fill Amount`: Arc'ın doluluk oranı (0-1)
- `Arc Angle`: Arc'ın açısı (0-360 derece)
- `Arc Color`: Arc'ın rengi
- `Animate Changes`: Değişikliklerin animasyonlu olması
- `Animation Duration`: Animasyon süresi

**Level Display**:
- `Level Text`: Seviye göstergesi Text component'i
- `Current Level`: Mevcut seviye (1-100)

**Canvas Settings**:
- `World Canvas`: World Space Canvas component'i
- `Canvas Scale`: Canvas'ın büyüklük oranı

**Runtime Controls**:
- `Arc1 Value`, `Arc2 Value`, `Arc3 Value`: Her arc için runtime değerler (0-1)

### Script Kullanımı

```csharp
using CurveSlider;

public class ExampleController : MonoBehaviour
{
    public CurveArcSlider curveSlider;
    
    void Start()
    {
        // Belirli bir arc'ın değerini ayarla
        curveSlider.SetArcValue(0, 0.8f); // İlk arc'ı %80 doldur
        
        // Seviye ayarla
        curveSlider.SetLevel(25);
        
        // Arc rengini değiştir
        curveSlider.SetArcColor(1, Color.red);
        
        // Tüm arc'ları aynı değere ayarla
        curveSlider.SetAllArcs(0.5f);
        
        // Tüm arc'ları sıfırla
        curveSlider.ResetAllArcs();
    }
}
```

### Metodlar

- `SetArcValue(int arcIndex, float value)`: Belirli bir arc'ın değerini ayarlar
- `GetArcValue(int arcIndex)`: Belirli bir arc'ın değerini döndürür
- `SetLevel(int level)`: Seviye değerini ayarlar
- `SetArcColor(int arcIndex, Color color)`: Belirli bir arc'ın rengini ayarlar
- `SetAllArcs(float value)`: Tüm arc'ları aynı değere ayarlar
- `ResetAllArcs()`: Tüm arc'ları sıfırlar

## Örnek Sahne

`ExampleScene.unity` dosyası, component'in nasıl kullanılacağını gösteren örnek bir sahne içerir. Bu sahnede:

- CurveArcSlider prefab'ı ayarlanmış halde bulunur
- Farklı arc değerleri ve renkleri örneklenmiştir
- Inspector üzerinden tüm ayarlar test edilebilir

## Teknik Detaylar

### Gereksinimler
- Unity 2019.4 LTS veya üzeri
- Unity UI (uGUI) package'ı

### Dosya Yapısı
```
Assets/CurveSlider/
├── CurveArcSlider.cs          # Ana script
├── CurveArcSlider.prefab      # Hazır prefab
├── ExampleScene.unity         # Örnek sahne
└── README.md                  # Bu dosya
```

### Performans Notları
- Animasyonlar Coroutine kullanır, çok sayıda arc için performans göz önünde bulundurulmalı
- World Space Canvas kullanıldığı için 3D performansı etkileyebilir
- Prefab binary formatında saklanır

## Sorun Giderme

**Arc'lar görünmüyor**:
- Canvas'ın World Space modunda olduğundan emin olun
- Camera'nın Canvas'ı görebildiğinden emin olun
- Arc Image'ların Fill Amount değerinin 0'dan büyük olduğunu kontrol edin

**Animasyonlar çalışmıyor**:
- Animate Changes seçeneğinin aktif olduğundan emin olun
- Animation Duration değerinin 0'dan büyük olduğunu kontrol edin

**Inspector'da değişiklikler uygulanmıyor**:
- Play modunda OnValidate() çalıştığından emin olun
- Script'in component olarak eklendiğinden emin olun

## Lisans

Bu proje MIT lisansı altında dağıtılmaktadır.

## Katkıda Bulunma

Hata bildirimleri ve öneriler için GitHub Issues kullanabilirsiniz.