using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmonitor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
            if(obj.name.Contains("Cherry")){
                obj.GetComponent<Cherry>().player1 = GameObject.Find("Player1");
                obj.GetComponent<Cherry>().player2 = GameObject.Find("Player2");
            }
            if(obj.name.Contains("Melon")){
                obj.GetComponent<Melon>().player1 = GameObject.Find("Player1");
                obj.GetComponent<Melon>().player2 = GameObject.Find("Player2");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
            if(obj.name.Contains("Cherry")){
                obj.GetComponent<Cherry>().Reset();
            }
            if(obj.name.Contains("Melon")){
                obj.GetComponent<Melon>().Reset();
            }
        }
    }
}
