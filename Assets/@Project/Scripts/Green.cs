using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1, player2;
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
            Vector3 pos = player1.transform.position;
            player1.transform.position = player2.transform.position;
            player2.transform.position = pos;
            Destroy(gameObject);
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(flagClip);
        }
    }
}
