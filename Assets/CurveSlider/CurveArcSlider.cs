using UnityEngine;
using UnityEngine.UI;

namespace CurveSlider
{
    [System.Serializable]
    public class ArcSettings
    {
        [Header("Arc Configuration")]
        public Image arcImage;
        [Range(0f, 1f)]
        public float fillAmount = 0.5f;
        [Range(0f, 360f)]
        public float arcAngle = 120f;
        public Color arcColor = Color.white;
        
        [Header("Animation")]
        public bool animateChanges = true;
        public float animationDuration = 0.3f;
    }

    public class CurveArcSlider : MonoBehaviour
    {
        [Header("Arc Sliders")]
        public ArcSettings[] arcSliders = new ArcSettings[3];
        
        [Header("Level Display")]
        public Text levelText;
        [Range(1, 100)]
        public int currentLevel = 1;
        
        [Header("Canvas Settings")]
        public Canvas worldCanvas;
        public float canvasScale = 1f;
        
        [Header("Runtime Controls")]
        [Range(0f, 1f)]
        public float arc1Value = 0.5f;
        [Range(0f, 1f)]
        public float arc2Value = 0.5f;
        [Range(0f, 1f)]
        public float arc3Value = 0.5f;
        
        private void Start()
        {
            InitializeArcs();
            UpdateLevelDisplay();
        }
        
        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                UpdateArcValues();
                UpdateLevelDisplay();
            }
        }
        
        private void InitializeArcs()
        {
            if (worldCanvas != null)
            {
                worldCanvas.transform.localScale = Vector3.one * canvasScale;
            }
            
            for (int i = 0; i < arcSliders.Length; i++)
            {
                if (arcSliders[i].arcImage != null)
                {
                    arcSliders[i].arcImage.fillAmount = arcSliders[i].fillAmount;
                    arcSliders[i].arcImage.color = arcSliders[i].arcColor;
                }
            }
        }
        
        private void UpdateArcValues()
        {
            if (arcSliders.Length >= 3)
            {
                SetArcValue(0, arc1Value);
                SetArcValue(1, arc2Value);
                SetArcValue(2, arc3Value);
            }
        }
        
        public void SetArcValue(int arcIndex, float value)
        {
            if (arcIndex >= 0 && arcIndex < arcSliders.Length && arcSliders[arcIndex].arcImage != null)
            {
                value = Mathf.Clamp01(value);
                arcSliders[arcIndex].fillAmount = value;
                
                if (arcSliders[arcIndex].animateChanges && Application.isPlaying)
                {
                    StartCoroutine(AnimateArcValue(arcIndex, value));
                }
                else
                {
                    arcSliders[arcIndex].arcImage.fillAmount = value;
                }
            }
        }
        
        private System.Collections.IEnumerator AnimateArcValue(int arcIndex, float targetValue)
        {
            float startValue = arcSliders[arcIndex].arcImage.fillAmount;
            float elapsed = 0f;
            
            while (elapsed < arcSliders[arcIndex].animationDuration)
            {
                elapsed += Time.deltaTime;
                float normalizedTime = elapsed / arcSliders[arcIndex].animationDuration;
                float currentValue = Mathf.Lerp(startValue, targetValue, normalizedTime);
                arcSliders[arcIndex].arcImage.fillAmount = currentValue;
                yield return null;
            }
            
            arcSliders[arcIndex].arcImage.fillAmount = targetValue;
        }
        
        public void SetLevel(int level)
        {
            currentLevel = Mathf.Clamp(level, 1, 100);
            UpdateLevelDisplay();
        }
        
        private void UpdateLevelDisplay()
        {
            if (levelText != null)
            {
                levelText.text = "Level " + currentLevel.ToString();
            }
        }
        
        public void SetArcColor(int arcIndex, Color color)
        {
            if (arcIndex >= 0 && arcIndex < arcSliders.Length && arcSliders[arcIndex].arcImage != null)
            {
                arcSliders[arcIndex].arcColor = color;
                arcSliders[arcIndex].arcImage.color = color;
            }
        }
        
        public float GetArcValue(int arcIndex)
        {
            if (arcIndex >= 0 && arcIndex < arcSliders.Length)
            {
                return arcSliders[arcIndex].fillAmount;
            }
            return 0f;
        }
        
        public void ResetAllArcs()
        {
            for (int i = 0; i < arcSliders.Length; i++)
            {
                SetArcValue(i, 0f);
            }
        }
        
        public void SetAllArcs(float value)
        {
            for (int i = 0; i < arcSliders.Length; i++)
            {
                SetArcValue(i, value);
            }
        }
    }
}