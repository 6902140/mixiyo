using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door1, door2, door3;
    public AudioClip flagClip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            if(door1 != null){
                door1.GetComponent<Door>().Open();
            }
            if(door2 != null){
                door2.GetComponent<Door>().Open();
            }
            if(door3 != null){
                door3.GetComponent<Door>().Open();
            }
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(flagClip);
            Destroy(gameObject);
        }
    }
}
