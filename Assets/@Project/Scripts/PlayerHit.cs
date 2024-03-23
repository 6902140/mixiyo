using UnityEngine;

// 控制玩家受伤动画的脚本
public class PlayerHit : MonoBehaviour
{
	// 受伤动画的移动速度
	public Vector3 m_velocity = new Vector3(0, 15, 0);

	// 受伤动画受到的重力强度
	public float m_gravity = 30;

	// 每帧调用的函数
	private void Update()
	{
		// 移动受伤动画
		transform.localPosition += m_velocity * Time.deltaTime;

		// 应用重力，使其逐渐下落
		m_velocity.y -= m_gravity * Time.deltaTime;
	}
}