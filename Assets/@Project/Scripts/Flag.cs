using UnityEngine;

// 控制针的脚本
public class Flag : MonoBehaviour
{
	// 当与其他对象发生碰撞时调用的函数
	// 无敌帧时间
	private bool playerOne = true;
    private bool playerTwo = true;
    public AudioClip flagClip;
	private void OnTriggerEnter2D(Collider2D other)
	{
		// 如果与名字中包含"Player"的对象发生碰撞
		if ((playerOne || playerTwo)  && other.name.Contains("Player"))
		{
            if(other.name.Contains("Player1")){
                playerOne = false;
            }else if (other.name.Contains("Player2")){
                playerTwo = false;
            }
			var player = other.GetComponent<Player>();
            var motor = player.GetComponent<PlatformerMotor2D>();
            motor.enableWallJumps = true;
            motor.enableWallSticks = true;
            motor.enableWallSlides = true;
            var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot(flagClip);
            if(!playerOne && !playerTwo)
            {
                Animator animator = GetComponent<Animator>();
                animator.Play("Off");
            }
        }
	}
}