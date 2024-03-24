using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    GameObject player;
    Vector3 direction;
    float speed=5f;
    float init_time;
    void Start()
    {
        player=GameObject.Find("Player");
        init_time=Time.time;
    }

    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if(direction.x>=0f)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
        if(Time.time-init_time>30f)
            Destroy(gameObject);
    }
}
