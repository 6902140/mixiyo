using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator blueAnimator = null;
    public Animator redAnimator = null;
    void Start()
    {
        blueAnimator.Play("Walk");
        redAnimator.Play("Walk");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
