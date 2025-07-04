using UnityEngine;
using UnityEngine.UI;

namespace HealthArcSlider
{
    /// <summary>
    /// Health Arc Slider component for Unity UI.
    /// Displays a health bar with arc shape, gradient fill, frame, and HP text.
    /// </summary>
    public class HealthArcSlider : MonoBehaviour
    {
        [Header("Health Bar Components")]
        [SerializeField] private Image arcBar;
        [SerializeField] private Image frame;
        [SerializeField] private Text hpText;
        [SerializeField] private RectTransform maskTransform;
        
        [Header("Health Settings")]
        [SerializeField, Range(0f, 1f)] private float currentHealth = 1f;
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private bool useVerticalFill = true;
        
        [Header("Visual Settings")]
        [SerializeField] private Color healthyColor = Color.green;
        [SerializeField] private Color lowHealthColor = Color.red;
        [SerializeField] private bool useGradientColors = true;
        [SerializeField] private float animationSpeed = 3f;
        
        [Header("Text Settings")]
        [SerializeField] private string hpTextFormat = "HP";
        [SerializeField] private bool showNumericValue = true;
        [SerializeField] private bool showPercentage = false;
        
        [Header("Arc Settings")]
        [Range(0f, 360f)]
        [SerializeField] private float totalArcAngle = 270f;
        [Range(-180f, 180f)]
        [SerializeField] private float startAngle = -135f;
        
        [Header("Test Settings (Editor Only)")]
        [SerializeField, Range(0f, 1f)] private float testHealthValue = 1f;
        
        private float targetHealth;
        private float currentHealthValue;
        private bool isAnimating = false;
        
        private void Start()
        {
            InitializeHealthBar();
        }
        
        private void Update()
        {
            #if UNITY_EDITOR
            // Test functionality in editor
            if (Application.isPlaying && !Mathf.Approximately(testHealthValue, currentHealth))
            {
                SetHealth(testHealthValue, true);
            }
            #endif
            
            // Handle animation
            if (isAnimating)
            {
                UpdateAnimation();
            }
        }
        
        /// <summary>
        /// Initialize the health bar with current settings
        /// </summary>
        private void InitializeHealthBar()
        {
            currentHealthValue = currentHealth;
            targetHealth = currentHealth;
            UpdateHealthBar();
            UpdateHPText();
        }
        
        /// <summary>
        /// Set the health value (0-1 range)
        /// </summary>
        /// <param name="healthValue">Health value between 0 and 1</param>
        /// <param name="animate">Whether to animate the change</param>
        public void SetHealth(float healthValue, bool animate = true)
        {
            float clampedValue = Mathf.Clamp01(healthValue);
            targetHealth = clampedValue;
            
            if (!animate)
            {
                currentHealthValue = targetHealth;
                currentHealth = targetHealth;
                UpdateHealthBar();
                UpdateHPText();
            }
            else
            {
                isAnimating = true;
            }
        }
        
        /// <summary>
        /// Set health using actual HP values
        /// </summary>
        /// <param name="currentHP">Current HP value</param>
        /// <param name="maxHP">Maximum HP value</param>
        /// <param name="animate">Whether to animate the change</param>
        public void SetHealthByValue(float currentHP, float maxHP, bool animate = true)
        {
            if (maxHP <= 0) return;
            
            maxHealth = maxHP;
            float healthRatio = currentHP / maxHP;
            SetHealth(healthRatio, animate);
        }
        
        /// <summary>
        /// Get current health value (0-1)
        /// </summary>
        /// <returns>Current health ratio</returns>
        public float GetHealthRatio()
        {
            return currentHealthValue;
        }
        
        /// <summary>
        /// Get current health as HP value
        /// </summary>
        /// <returns>Current HP value</returns>
        public float GetHealthValue()
        {
            return currentHealthValue * maxHealth;
        }
        
        /// <summary>
        /// Update animation frame
        /// </summary>
        private void UpdateAnimation()
        {
            if (Mathf.Abs(currentHealthValue - targetHealth) > 0.01f)
            {
                currentHealthValue = Mathf.Lerp(currentHealthValue, targetHealth, Time.deltaTime * animationSpeed);
                currentHealth = currentHealthValue;
                UpdateHealthBar();
                UpdateHPText();
            }
            else
            {
                currentHealthValue = targetHealth;
                currentHealth = targetHealth;
                UpdateHealthBar();
                UpdateHPText();
                isAnimating = false;
            }
        }
        
        /// <summary>
        /// Update the visual health bar
        /// </summary>
        private void UpdateHealthBar()
        {
            if (arcBar == null) return;
            
            // Set fill amount based on health
            if (useVerticalFill)
            {
                arcBar.fillAmount = currentHealthValue;
            }
            else
            {
                arcBar.fillAmount = currentHealthValue;
            }
            
            // Update color based on health if gradient colors are enabled
            if (useGradientColors)
            {
                Color currentColor = Color.Lerp(lowHealthColor, healthyColor, currentHealthValue);
                arcBar.color = currentColor;
            }
        }
        
        /// <summary>
        /// Update the HP text display
        /// </summary>
        private void UpdateHPText()
        {
            if (hpText == null) return;
            
            string displayText = hpTextFormat;
            
            if (showNumericValue)
            {
                float currentHP = currentHealthValue * maxHealth;
                displayText += $"\n{currentHP:F0}/{maxHealth:F0}";
            }
            
            if (showPercentage)
            {
                float percentage = currentHealthValue * 100f;
                displayText += $"\n{percentage:F0}%";
            }
            
            hpText.text = displayText;
        }
        
        /// <summary>
        /// Restore health to full
        /// </summary>
        public void RestoreHealth()
        {
            SetHealth(1f, true);
        }
        
        /// <summary>
        /// Damage the health bar
        /// </summary>
        /// <param name="damageAmount">Damage amount (0-1)</param>
        public void TakeDamage(float damageAmount)
        {
            float newHealth = Mathf.Max(0f, currentHealthValue - damageAmount);
            SetHealth(newHealth, true);
        }
        
        /// <summary>
        /// Heal the health bar
        /// </summary>
        /// <param name="healAmount">Heal amount (0-1)</param>
        public void Heal(float healAmount)
        {
            float newHealth = Mathf.Min(1f, currentHealthValue + healAmount);
            SetHealth(newHealth, true);
        }
        
        /// <summary>
        /// Set random health value (for testing)
        /// </summary>
        public void SetRandomHealth()
        {
            SetHealth(Random.Range(0f, 1f), true);
        }
    }
}