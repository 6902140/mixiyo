using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public Image mask;

    public TMP_Text Ratio;
    float originalSize;
    void Awake()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetRatio(int current, int max){
        Ratio.text = current.ToString() + "/" + max.ToString();
    }

    public void SetValue(float value)
    {				      
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}