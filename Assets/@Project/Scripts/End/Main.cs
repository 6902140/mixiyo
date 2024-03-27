using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text image;
    static bool startFadeOut = false;
    float alpha;
    public void ToMain()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        alpha = 0;
        // float t = Time.time;
        while (alpha < 1)
        {
            // Debug.Log(Time.deltaTime);
            alpha += Time.deltaTime * 0.8f;
            // Debug.Log(alpha);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        // Debug.Log(Time.time - t);
        SceneManager.LoadScene(0);
    }
}
