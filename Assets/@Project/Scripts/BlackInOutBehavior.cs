using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackInOutBehavior : MonoBehaviour
{
    public Image image;
    bool isReady = false;
    [SerializeField] float alpha;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (isReady && Input.anyKey){
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        alpha = 1;

        while (alpha > 0)
        {
            //Debug.Log(Time.time);
            alpha -= Time.deltaTime;
            image.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        isReady = true;
    }

    IEnumerator FadeOut()
    {
        alpha = 0;

        while (alpha < 1)
        {
            //Debug.Log(Time.time);
            alpha += Time.deltaTime;
            image.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0.1f);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
