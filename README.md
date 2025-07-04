# CurveSlider

Unity için 3D uzayda kullanılabilen, World Space Canvas tabanlı arc slider komponenti. 3 adet eğri slider ve level gösterimi ile zengin kullanıcı arayüzü deneyimi sunar.

## Özellikler

- **3 Adet Arc Slider**: Birbirinden bağımsız eğri sliderlar
- **World Space Canvas**: 3D uzayda çalışan UI elemanları
- **Inspector Kontrolü**: Tüm ayarlar Inspector'dan yapılabilir
- **Animasyon Sistemi**: Smooth geçişler ve animasyonlar
- **Kolay Kullanım**: Hazır prefab ve örnek sahne
- **Özelleştirilebilir**: Renk, hız, açı ayarları

## Kurulum

1. Bu repository'yi klonlayın
2. `Assets/CurveSlider/` klasörünü Unity projenize kopyalayın
3. `CurveArcSlider.prefab` dosyasını sahnenize ekleyin

## Kullanım

Detaylı kullanım kılavuzu için `Assets/CurveSlider/README.md` dosyasını inceleyiniz.

### Hızlı Başlangıç

```csharp
// Script ile kontrolü
curveSlider.SetSliderValue(0, 0.7f, true);
curveSlider.SetLevel(5);
```

## Dosyalar

- `Assets/CurveSlider/Scripts/CurveArcSlider.cs` - Ana script
- `Assets/CurveSlider/Prefabs/CurveArcSlider.prefab` - Hazır prefab
- `Assets/CurveSlider/Scenes/ExampleScene.unity` - Örnek sahne
- `Assets/CurveSlider/README.md` - Detaylı dokümantasyon

## Lisans

MIT License