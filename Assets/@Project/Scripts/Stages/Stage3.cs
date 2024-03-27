using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    // Start is called before the first frame update
    static Camera cam= null;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCam()
    {
        transform.position = poses[indexes[index]];
        cam.orthographicSize = sizes[indexes[index]];
        index++;
    }

    Vector3 []poses = {new(0.04f, 9.93f, -10f), new(-2.42f,0.58f,-10f),
                        new(11.8f, 6.39f, -10f),   //  red
                        new(-11.48f, 6.02f, -10f)};  // blue
    int []indexes = {0, 3, 2, 3, 2};
    float []sizes = {0.9f, 0.8f, 0.8f, 0.8f};
    int index = 0;
}
