using UnityEngine.UI;
using UnityEngine; 
public class HealthBar : MonoBehaviour
{
    public Image mask;
    float originalSize;
    void Awake()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {				      
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}