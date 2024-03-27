using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    Text text = null;
    float alpha;
    void Start()
    {
        text = GetComponent<Text>();
        
    }

    void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        alpha = 0;
        // float t = Time.time;
        while (alpha < 1)
        {
            // Debug.Log(Time.deltaTime);
            alpha += Time.deltaTime * 1f;
            // Debug.Log(alpha);
            text.color = new Color(255, 255, 255, alpha);
            yield return null;
        }
    }
}
