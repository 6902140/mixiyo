using UnityEngine;

// 控制移动平台的脚本
public class MovePlatform : MonoBehaviour
{
	// 移动平台的移动距离
	public Vector3 m_distance = new Vector3(5, 0, 0);

	// 移动平台的移动速度
	public float m_speed = 0.5f;

	// 开始位置
	private Vector3 m_startPosition;

	// 结束位置
	private Vector3 m_endPosition;

	// 场景开始时调用的函数
	private void Awake()
	{
		// 记录当前位置作为开始位置
		m_startPosition = transform.localPosition;

		// 根据开始位置和移动距离设置结束位置
		m_endPosition = m_startPosition + m_distance;
	}

	// 每帧调用的函数
	private void Update()
	{
		// 计算当前位置
		var t = Mathf.PingPong(Time.time * m_speed, 1);
		var newPosition = Vector3.Lerp(m_startPosition, m_endPosition, t);

		// 更新当前位置
		transform.localPosition = newPosition;
	}
}