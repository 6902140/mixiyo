using UnityEngine;

// 控制弹簧的脚本
public class Trampoline : MonoBehaviour
{
	// 让玩家跳跃的高度
	public float m_jumpHeight = 10;

	// 当与其他对象发生碰撞时调用的函数
	private void OnTriggerEnter2D(Collider2D other)
	{
		// 如果与名字中包含"Player"的对象发生碰撞
		if (other.name.Contains("Player"))
		{
			// 获取控制玩家移动的组件
			var motor = other.GetComponent<PlatformerMotor2D>();

			// 强制玩家跳跃
			motor.ForceJump(m_jumpHeight);

			// 获取弹簧的动画控制器
			var animator = GetComponent<Animator>();

			// 播放跳跃动画
			animator.Play("Jump");
		}
	}
}