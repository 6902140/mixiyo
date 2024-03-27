using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FigureCam : MonoBehaviour
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

    Vector3 []poses = {new(11.7f, -1.26f, -10f), new(-2.42f,0.58f,-10f),
                        new(5.25f, -3.73f, -10f),   //  red
                        new(3.7f, -4.26f, -10f)};  // blue
    int []indexes = {0,1,2,3,0, 3, 0};
    float []sizes = {0.9f, 0.8f, 0.8f, 0.8f};
    int index = 0;
}
