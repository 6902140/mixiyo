using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        
        // make sure the scene before and after the loop are the same!
        if (pos.x < -60f){
            pos.x = 30f;
        }

        transform.position = pos;
    }
}
