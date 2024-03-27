using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialugueText : MonoBehaviour
{
    public TextAsset textFile;
    public int index;
    public float textSpeed = 0.2f;
    List<string> textList = new List<string>();
    public Text textLabel;

    // Start is called before the first frame update
    void Start()
    {
        GettextFormFile(textFile);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextText()
    {
        // Debug.Log("Next Text");
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        string name = "";
        switch (textList[index].Trim())
        {
            case "NTR":
                name = "牛头人";
                break;
            case "V":
                name = "村民";
                break;
            case "R":
                name = "小红";
                break;
            case "B":
                name = "小蓝";
                break;
        }
        index++;
        textLabel.text = name + "\n\n";

        // Debug.Log(textList[index]);

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            // Debug.Log(textLabel.text);
            // Debug.Log(textList[index][i]);

            yield return new WaitForSeconds(textSpeed);
        }

        // Debug.Log(textLabel.text);

        index++;
    }

    void GettextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
            // Debug.Log(line);
        }
    }
}
