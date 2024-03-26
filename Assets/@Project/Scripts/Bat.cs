using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    GameObject player;
    Vector3 direction;
    float speed=3f;
    float init_time;
    void Start()
    {
        player1=GameObject.Find("Player1");
        player2=GameObject.Find("Player2");
        if(Random.value>0.5)
            player=player1;
        else
            player=player2;
        init_time=Time.time;
    }

    void Update()
    {
        if(player1.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(player2.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(Vector3.Distance(player1.transform.position,transform.position)<1.3f)
            player1.GetComponent<Player>().Hit();
        if(Vector3.Distance(player2.transform.position,transform.position)<1.3f)
            player2.GetComponent<Player>().Hit();
        direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if(direction.x>=0f)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
        if(Time.time-init_time>15f)
            Destroy(gameObject);
    }
}
