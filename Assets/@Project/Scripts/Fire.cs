using UnityEngine;

// 控制针的脚本
public class Fire : MonoBehaviour
{
	// 当与其他对象发生碰撞时调用的函数
	// 无敌帧时间
	private float invincibleTime = 0.7f;
	private float lastHitTime = 0.0f;
	private void OnTriggerStay2D(Collider2D other)
	{
		// 如果与名字中包含"Player"的对象发生碰撞
		if (other.name.Contains("Player"))
		{
			// 获取玩家上的Player脚本
			if(Time.time - lastHitTime < invincibleTime)
			{
				return;
			}
			var player = other.GetComponent<Player>();

			// 调用玩家的死亡函数
			player.Dead();
			lastHitTime = Time.time;
		}
	}
}