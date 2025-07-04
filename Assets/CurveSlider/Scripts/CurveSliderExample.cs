using UnityEngine;
using CurveSlider;

/// <summary>
/// Example script showing how to use CurveArcSlider
/// </summary>
public class CurveSliderExample : MonoBehaviour
{
    [Header("CurveSlider Reference")]
    public CurveArcSlider curveSlider;
    
    [Header("Test Controls")]
    public bool testRandomValues = false;
    public bool testResetSliders = false;
    public bool testSetLevel = false;
    public int newLevel = 5;
    
    [Header("Manual Value Controls")]
    [Range(0f, 1f)]
    public float manualValue1 = 0.5f;
    [Range(0f, 1f)]
    public float manualValue2 = 0.5f;
    [Range(0f, 1f)]
    public float manualValue3 = 0.5f;
    
    private float lastManualValue1;
    private float lastManualValue2;
    private float lastManualValue3;
    
    void Start()
    {
        // Initialize if curveSlider is not assigned
        if (curveSlider == null)
        {
            curveSlider = FindObjectOfType<CurveArcSlider>();
        }
        
        // Store initial values
        lastManualValue1 = manualValue1;
        lastManualValue2 = manualValue2;
        lastManualValue3 = manualValue3;
        
        // Example: Set initial values
        DemonstrateBasicUsage();
    }
    
    void Update()
    {
        // Check for test button presses
        if (testRandomValues)
        {
            testRandomValues = false;
            TestRandomValues();
        }
        
        if (testResetSliders)
        {
            testResetSliders = false;
            TestResetSliders();
        }
        
        if (testSetLevel)
        {
            testSetLevel = false;
            TestSetLevel();
        }
        
        // Check for manual value changes
        CheckManualValueChanges();
    }
    
    void DemonstrateBasicUsage()
    {
        if (curveSlider == null) return;
        
        Debug.Log("=== CurveSlider Basic Usage Demo ===");
        
        // Set individual slider values
        curveSlider.SetSliderValue(0, 0.7f, true);
        curveSlider.SetSliderValue(1, 0.4f, true);
        curveSlider.SetSliderValue(2, 0.9f, true);
        
        // Set level
        curveSlider.SetLevel(3);
        
        Debug.Log("Initial values set: Slider1=0.7, Slider2=0.4, Slider3=0.9, Level=3");
    }
    
    void TestRandomValues()
    {
        if (curveSlider == null) return;
        
        curveSlider.SetRandomValues();
        Debug.Log("Random values set for all sliders");
    }
    
    void TestResetSliders()
    {
        if (curveSlider == null) return;
        
        curveSlider.ResetSliders();
        Debug.Log("All sliders reset to default values");
    }
    
    void TestSetLevel()
    {
        if (curveSlider == null) return;
        
        curveSlider.SetLevel(newLevel);
        Debug.Log($"Level set to: {newLevel}");
    }
    
    void CheckManualValueChanges()
    {
        if (curveSlider == null) return;
        
        // Check if manual values changed
        if (Mathf.Abs(lastManualValue1 - manualValue1) > 0.01f)
        {
            curveSlider.SetSliderValue(0, manualValue1, true);
            lastManualValue1 = manualValue1;
        }
        
        if (Mathf.Abs(lastManualValue2 - manualValue2) > 0.01f)
        {
            curveSlider.SetSliderValue(1, manualValue2, true);
            lastManualValue2 = manualValue2;
        }
        
        if (Mathf.Abs(lastManualValue3 - manualValue3) > 0.01f)
        {
            curveSlider.SetSliderValue(2, manualValue3, true);
            lastManualValue3 = manualValue3;
        }
    }
    
    /// <summary>
    /// Example method that can be called from UI buttons
    /// </summary>
    public void OnButtonSetHighValues()
    {
        if (curveSlider == null) return;
        
        float[] highValues = {0.8f, 0.9f, 0.7f};
        curveSlider.SetAllSliderValues(highValues, true);
        Debug.Log("High values set for all sliders");
    }
    
    /// <summary>
    /// Example method that can be called from UI buttons
    /// </summary>
    public void OnButtonSetLowValues()
    {
        if (curveSlider == null) return;
        
        float[] lowValues = {0.2f, 0.3f, 0.1f};
        curveSlider.SetAllSliderValues(lowValues, true);
        Debug.Log("Low values set for all sliders");
    }
    
    /// <summary>
    /// Example method to demonstrate getting current values
    /// </summary>
    public void LogCurrentValues()
    {
        if (curveSlider == null) return;
        
        float val1 = curveSlider.GetSliderValue(0);
        float val2 = curveSlider.GetSliderValue(1);
        float val3 = curveSlider.GetSliderValue(2);
        
        Debug.Log($"Current Values - Slider1: {val1:F2}, Slider2: {val2:F2}, Slider3: {val3:F2}");
    }
}