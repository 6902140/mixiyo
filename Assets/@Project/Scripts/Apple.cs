using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    void Start()
    {
        player1=GameObject.Find("Player1");
        player2=GameObject.Find("Player2");
    }

    void Update()
    {
        if(player1.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(player2.GetComponent<Player>().dead)
            Destroy(gameObject);
    }
}
