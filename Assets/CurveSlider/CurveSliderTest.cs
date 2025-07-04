using UnityEngine;
using CurveSlider;

public class CurveSliderTest : MonoBehaviour
{
    public CurveArcSlider curveSlider;
    
    void Start()
    {
        // Test the component functionality
        if (curveSlider != null)
        {
            Debug.Log("CurveArcSlider component found and working!");
            
            // Test setting arc values
            curveSlider.SetArcValue(0, 0.8f);
            curveSlider.SetArcValue(1, 0.6f);
            curveSlider.SetArcValue(2, 0.4f);
            
            // Test setting level
            curveSlider.SetLevel(42);
            
            // Test getting arc values
            float arc1Value = curveSlider.GetArcValue(0);
            Debug.Log($"Arc 1 value: {arc1Value}");
            
            // Test setting colors
            curveSlider.SetArcColor(0, Color.red);
            curveSlider.SetArcColor(1, Color.green);
            curveSlider.SetArcColor(2, Color.blue);
            
            Debug.Log("All tests completed successfully!");
        }
        else
        {
            Debug.LogError("CurveArcSlider component not found!");
        }
    }
    
    void Update()
    {
        // Demo runtime control
        if (Input.GetKeyDown(KeyCode.Space))
        {
            curveSlider.SetAllArcs(Random.Range(0f, 1f));
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            curveSlider.ResetAllArcs();
        }
    }
}