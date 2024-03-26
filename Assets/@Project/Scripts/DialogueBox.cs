using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Text text;
    public float maxAlpha = 217f;
    float alpha;
    void Start()
    {

    }

    void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeIn()
    {
        alpha = 0;

        while (alpha < maxAlpha)
        {
            //Debug.Log(Time.time);
            alpha += Time.deltaTime;
            //Debug.Log(alpha);
            image.color = new Color(255, 255, 255, alpha);

            Color textColor = text.color;
            textColor.a = alpha;
            text.color = textColor;


            yield return null;
        }
        // Debug.Log(Time.time);
    }
}
