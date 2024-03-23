using PC2D;
using UnityEngine;

// 控制敌人的脚本
public class Enemy : MonoBehaviour
{
	// 被击中的动画预制体
	public GameObject m_hitPrefab;

	// 被击中时播放的音效
	public AudioClip m_hitClip;

	// 控制敌人移动的组件
	private PlatformerMotor2D m_motor;

	// 显示敌人精灵的组件
	private SpriteRenderer m_renderer;

	// 管理敌人碰撞的组件
	private BoxCollider2D m_collider;

	// 场景开始时调用的函数
	private void Awake()
	{
		// 获取控制敌人移动的组件
		m_motor = GetComponent<PlatformerMotor2D>();

		// 最开始向左移动
		m_motor.normalizedXMovement = -1;

		// 获取显示敌人精灵的组件
		m_renderer = GetComponent<SpriteRenderer>();

		// 初始时将图像朝向设为左侧
		m_renderer.flipX = false;

		// 获取管理敌人碰撞的组件
		m_collider = GetComponent<BoxCollider2D>();
	}

	// 每帧调用的函数
	private void Update()
	{
		// 获取当前前进方向
		var dir = m_motor.normalizedXMovement > 0
			? Vector3.right
			: Vector3.left;

		// 检查前进方向是否有瓷砖地图
		var offset = m_collider.size.y * 0.5f;
		var hit = Physics2D.Raycast(
			transform.position - new Vector3(0, offset, 0),
			dir,
			m_collider.size.x * 0.55f,
			Globals.ENV_MASK
		);

		// 如果前进方向有瓷砖地图
		if (hit.collider != null)
		{
			// 反转移动方向
			m_motor.normalizedXMovement = -m_motor.normalizedXMovement;

			// 反转图像朝向
			m_renderer.flipX = !m_renderer.flipX;
		}
	}

	// 当与其他对象发生碰撞时调用的函数
	private void OnTriggerEnter2D(Collider2D other)
	{
		// 如果与名称包含"Player"的对象发生碰撞
		if (other.name.Contains("Player"))
		{
			// 获取控制玩家移动的组件
			var motor = other.GetComponent<PlatformerMotor2D>();

			// 如果玩家正在下落
			if (motor.IsFalling())
			{
				// 销毁敌人
				Destroy(gameObject);

				// 强制玩家跳跃
				motor.ForceJump();

				// 在场景中查找 CameraShaker 脚本
				var cameraShake = FindObjectOfType<CameraShaker>();

				// 使用 CameraShaker 震动摄像机
				cameraShake.Shake();

				// 生成被击中的动画对象
				Instantiate(m_hitPrefab, transform.position, Quaternion.identity);

				// 播放被击中音效
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot(m_hitClip);

				// 禁止播放玩家跳跃音效
				var player = other.GetComponent<Player>();
				player.IsSkipJumpSe = true;
			}
			// 如果玩家不处于下落状态
			else
			{
				// 获取玩家的 Player 脚本
				var player = other.GetComponent<Player>();

				// 调用玩家的死亡函数
				player.Dead();
			}
		}
	}
}