using UnityEngine;

// 控制针的脚本
public class Fire : MonoBehaviour
{
	// 当与其他对象发生碰撞时调用的函数
	// 无敌帧时间
	private bool fireOn = true;
	private void OnTriggerEnter2D(Collider2D other)
	{
		// 如果与名字中包含"Player"的对象发生碰撞
		if (fireOn && other.name.Contains("Player"))
		{
			fireOn = false;
			Animator animator = GetComponent<Animator>();
			animator.Play("Off");
			var player = other.GetComponent<Player>();
			player.Dead();
		}
	}
}