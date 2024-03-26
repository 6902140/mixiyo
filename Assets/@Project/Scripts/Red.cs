using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire1, fire2;
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
            fire1.GetComponent<Fire>().Off();
            fire2.GetComponent<Fire>().Off();
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(flagClip);
            Destroy(gameObject);
        }
    }
}
