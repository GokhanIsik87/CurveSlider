using UnityEngine;
using HealthArcSlider;

/// <summary>
/// Example script showing how to use HealthArcSlider
/// </summary>
public class HealthArcSliderExample : MonoBehaviour
{
    [Header("Health Arc Slider Reference")]
    public HealthArcSlider healthSlider;
    
    [Header("Test Controls")]
    public bool testRandomHealth = false;
    public bool testTakeDamage = false;
    public bool testHeal = false;
    public bool testFullRestore = false;
    
    [Header("Manual Controls")]
    [Range(0f, 1f)]
    public float manualHealthValue = 1f;
    [Range(0f, 100f)]
    public float manualCurrentHP = 100f;
    [Range(0f, 100f)]
    public float manualMaxHP = 100f;
    
    [Header("Damage/Heal Controls")]
    [Range(0f, 1f)]
    public float damageAmount = 0.1f;
    [Range(0f, 1f)]
    public float healAmount = 0.1f;
    
    private float lastManualHealthValue;
    private float lastManualCurrentHP;
    private float lastManualMaxHP;
    
    void Start()
    {
        // Initialize if healthSlider is not assigned
        if (healthSlider == null)
        {
            healthSlider = FindObjectOfType<HealthArcSlider>();
        }
        
        // Store initial values
        lastManualHealthValue = manualHealthValue;
        lastManualCurrentHP = manualCurrentHP;
        lastManualMaxHP = manualMaxHP;
        
        // Example: Set initial values
        if (healthSlider != null)
        {
            healthSlider.SetHealth(manualHealthValue, false);
            Debug.Log("Health Arc Slider initialized with " + (manualHealthValue * 100) + "% health");
        }
    }
    
    void Update()
    {
        if (healthSlider == null) return;
        
        // Handle test controls
        if (testRandomHealth)
        {
            TestRandomHealth();
            testRandomHealth = false;
        }
        
        if (testTakeDamage)
        {
            TestTakeDamage();
            testTakeDamage = false;
        }
        
        if (testHeal)
        {
            TestHeal();
            testHeal = false;
        }
        
        if (testFullRestore)
        {
            TestFullRestore();
            testFullRestore = false;
        }
        
        // Check manual value changes
        CheckManualValueChanges();
    }
    
    void TestRandomHealth()
    {
        if (healthSlider == null) return;
        
        float randomHealth = Random.Range(0f, 1f);
        healthSlider.SetHealth(randomHealth, true);
        Debug.Log("Random health set to: " + (randomHealth * 100) + "%");
    }
    
    void TestTakeDamage()
    {
        if (healthSlider == null) return;
        
        healthSlider.TakeDamage(damageAmount);
        Debug.Log("Took " + (damageAmount * 100) + "% damage");
    }
    
    void TestHeal()
    {
        if (healthSlider == null) return;
        
        healthSlider.Heal(healAmount);
        Debug.Log("Healed " + (healAmount * 100) + "%");
    }
    
    void TestFullRestore()
    {
        if (healthSlider == null) return;
        
        healthSlider.RestoreHealth();
        Debug.Log("Health fully restored");
    }
    
    void CheckManualValueChanges()
    {
        if (healthSlider == null) return;
        
        // Check if manual health value changed
        if (Mathf.Abs(lastManualHealthValue - manualHealthValue) > 0.01f)
        {
            healthSlider.SetHealth(manualHealthValue, true);
            lastManualHealthValue = manualHealthValue;
            Debug.Log("Manual health set to: " + (manualHealthValue * 100) + "%");
        }
        
        // Check if manual HP values changed
        if (Mathf.Abs(lastManualCurrentHP - manualCurrentHP) > 0.1f || 
            Mathf.Abs(lastManualMaxHP - manualMaxHP) > 0.1f)
        {
            healthSlider.SetHealthByValue(manualCurrentHP, manualMaxHP, true);
            lastManualCurrentHP = manualCurrentHP;
            lastManualMaxHP = manualMaxHP;
            Debug.Log("Manual HP set to: " + manualCurrentHP + "/" + manualMaxHP);
        }
    }
    
    /// <summary>
    /// Example method that can be called from UI buttons
    /// </summary>
    public void OnButtonSetHighHealth()
    {
        if (healthSlider == null) return;
        
        healthSlider.SetHealth(0.9f, true);
        Debug.Log("High health set (90%)");
    }
    
    /// <summary>
    /// Example method that can be called from UI buttons
    /// </summary>
    public void OnButtonSetLowHealth()
    {
        if (healthSlider == null) return;
        
        healthSlider.SetHealth(0.2f, true);
        Debug.Log("Low health set (20%)");
    }
    
    /// <summary>
    /// Example method that can be called from UI buttons
    /// </summary>
    public void OnButtonSetMediumHealth()
    {
        if (healthSlider == null) return;
        
        healthSlider.SetHealth(0.5f, true);
        Debug.Log("Medium health set (50%)");
    }
    
    /// <summary>
    /// Example method to demonstrate getting current values
    /// </summary>
    public void LogCurrentValues()
    {
        if (healthSlider == null) return;
        
        float healthRatio = healthSlider.GetHealthRatio();
        float healthValue = healthSlider.GetHealthValue();
        Debug.Log("Current health ratio: " + healthRatio + " (" + (healthRatio * 100) + "%)");
        Debug.Log("Current health value: " + healthValue);
    }
    
    /// <summary>
    /// Simulate combat damage over time
    /// </summary>
    public void StartCombatSimulation()
    {
        if (healthSlider == null) return;
        
        StartCoroutine(CombatSimulation());
    }
    
    private System.Collections.IEnumerator CombatSimulation()
    {
        Debug.Log("Starting combat simulation...");
        
        // Take damage over time
        for (int i = 0; i < 10; i++)
        {
            healthSlider.TakeDamage(0.1f);
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(1f);
        
        // Heal over time
        for (int i = 0; i < 10; i++)
        {
            healthSlider.Heal(0.1f);
            yield return new WaitForSeconds(0.3f);
        }
        
        Debug.Log("Combat simulation ended.");
    }
}