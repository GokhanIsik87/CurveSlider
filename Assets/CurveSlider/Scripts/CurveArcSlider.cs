using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CurveSlider
{
    [System.Serializable]
    public class ArcSliderData
    {
        [Header("Arc Settings")]
        public Image arcImage;
        [Range(0f, 1f)]
        public float currentValue = 0.5f;
        [Range(0f, 1f)]
        public float maxValue = 1f;
        public Color arcColor = Color.white;
        public float animationSpeed = 2f;
        
        [Header("Arc Visual Properties")]
        [Range(0f, 360f)]
        public float totalArcAngle = 270f;
        [Range(-180f, 180f)]
        public float startAngle = -135f;
        
        private float targetValue;
        private bool isAnimating = false;
        
        public void Initialize()
        {
            targetValue = currentValue;
            UpdateArcVisual();
        }
        
        public void SetValue(float value, bool animate = true)
        {
            targetValue = Mathf.Clamp01(value);
            if (!animate)
            {
                currentValue = targetValue;
                UpdateArcVisual();
            }
        }
        
        public void UpdateAnimation()
        {
            if (Mathf.Abs(currentValue - targetValue) > 0.01f)
            {
                currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * animationSpeed);
                UpdateArcVisual();
                isAnimating = true;
            }
            else if (isAnimating)
            {
                currentValue = targetValue;
                UpdateArcVisual();
                isAnimating = false;
            }
        }
        
        private void UpdateArcVisual()
        {
            if (arcImage != null)
            {
                arcImage.color = arcColor;
                arcImage.fillAmount = currentValue / maxValue;
            }
        }
    }
    
    public class CurveArcSlider : MonoBehaviour
    {
        [Header("Slider Configuration")]
        public ArcSliderData[] arcSliders = new ArcSliderData[3];
        
        [Header("Level Display")]
        public Text levelText;
        public string levelPrefix = "Level ";
        public int currentLevel = 1;
        
        [Header("Global Settings")]
        public bool autoUpdate = true;
        public float globalAnimationSpeed = 2f;
        
        [Header("Test Values (Editor Only)")]
        [SerializeField, Range(0f, 1f)]
        private float testValue1 = 0.5f;
        [SerializeField, Range(0f, 1f)]
        private float testValue2 = 0.3f;
        [SerializeField, Range(0f, 1f)]
        private float testValue3 = 0.8f;
        
        private void Start()
        {
            InitializeSliders();
            UpdateLevelText();
        }
        
        private void Update()
        {
            if (autoUpdate)
            {
                UpdateSliderAnimations();
            }
            
            #if UNITY_EDITOR
            // Test values in editor
            if (Application.isPlaying)
            {
                SetSliderValue(0, testValue1);
                SetSliderValue(1, testValue2);
                SetSliderValue(2, testValue3);
            }
            #endif
        }
        
        private void InitializeSliders()
        {
            for (int i = 0; i < arcSliders.Length; i++)
            {
                if (arcSliders[i] != null)
                {
                    arcSliders[i].animationSpeed = globalAnimationSpeed;
                    arcSliders[i].Initialize();
                }
            }
        }
        
        private void UpdateSliderAnimations()
        {
            for (int i = 0; i < arcSliders.Length; i++)
            {
                if (arcSliders[i] != null)
                {
                    arcSliders[i].UpdateAnimation();
                }
            }
        }
        
        /// <summary>
        /// Set the value of a specific slider
        /// </summary>
        /// <param name="sliderIndex">Index of the slider (0-2)</param>
        /// <param name="value">Value between 0 and 1</param>
        /// <param name="animate">Whether to animate the change</param>
        public void SetSliderValue(int sliderIndex, float value, bool animate = true)
        {
            if (sliderIndex >= 0 && sliderIndex < arcSliders.Length && arcSliders[sliderIndex] != null)
            {
                arcSliders[sliderIndex].SetValue(value, animate);
            }
        }
        
        /// <summary>
        /// Set all slider values at once
        /// </summary>
        /// <param name="values">Array of values between 0 and 1</param>
        /// <param name="animate">Whether to animate the changes</param>
        public void SetAllSliderValues(float[] values, bool animate = true)
        {
            for (int i = 0; i < Mathf.Min(values.Length, arcSliders.Length); i++)
            {
                SetSliderValue(i, values[i], animate);
            }
        }
        
        /// <summary>
        /// Get the current value of a specific slider
        /// </summary>
        /// <param name="sliderIndex">Index of the slider (0-2)</param>
        /// <returns>Current value between 0 and 1</returns>
        public float GetSliderValue(int sliderIndex)
        {
            if (sliderIndex >= 0 && sliderIndex < arcSliders.Length && arcSliders[sliderIndex] != null)
            {
                return arcSliders[sliderIndex].currentValue;
            }
            return 0f;
        }
        
        /// <summary>
        /// Set the current level and update the display
        /// </summary>
        /// <param name="level">The level to display</param>
        public void SetLevel(int level)
        {
            currentLevel = level;
            UpdateLevelText();
        }
        
        private void UpdateLevelText()
        {
            if (levelText != null)
            {
                levelText.text = levelPrefix + currentLevel.ToString();
            }
        }
        
        /// <summary>
        /// Reset all sliders to their initial values
        /// </summary>
        public void ResetSliders()
        {
            for (int i = 0; i < arcSliders.Length; i++)
            {
                if (arcSliders[i] != null)
                {
                    arcSliders[i].SetValue(0.5f, true);
                }
            }
        }
        
        /// <summary>
        /// Set random values for all sliders (useful for testing)
        /// </summary>
        public void SetRandomValues()
        {
            for (int i = 0; i < arcSliders.Length; i++)
            {
                if (arcSliders[i] != null)
                {
                    arcSliders[i].SetValue(Random.Range(0f, 1f), true);
                }
            }
        }
    }
}