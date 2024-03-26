using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("Off");
        Invoke("destroy", 0.5f);
    }

    void destroy(){
        Destroy(gameObject);
    }
}
