using UnityEngine;
using UnityEngine.SceneManagement;

// 负责控制玩家的脚本
public class Player : MonoBehaviour
{
	// 玩家受伤动画的预制体
	public GameObject m_playerHitPrefab;

	// 跳跃时播放的音效
	public AudioClip m_jumpClip;

	// 受伤时播放的音效
	public AudioClip m_hitClip;

	public string HORIZONTAL;
	public string VERTICAL;
	public string JUMP;
	public string DASH;

	// 是否跳过跳跃音效
	public bool IsSkipJumpSe;

	// 玩家受伤时调用的函数
	public void Dead()
	{
		// 将玩家对象设置为不可见
		// 如果使用Destroy函数直接删除玩家对象
		// 将无法调用OnRetry函数
		// 因此使用SetActive函数将其设置为不可见
		gameObject.SetActive(false);

		// 在场景中查找 CameraShaker 脚本
		var cameraShake = FindObjectOfType<CameraShaker>();

		// 使用 CameraShaker 震动相机
		cameraShake.Shake();

		// 2秒后重新开始游戏
		Invoke("OnRetry", 2);

		// 生成玩家受伤动画的对象
		Instantiate(
			m_playerHitPrefab,
			transform.position,
			Quaternion.identity
		);

		// 播放受伤音效
		var audioSource = FindObjectOfType<AudioSource>();
		audioSource.PlayOneShot(m_hitClip);
	}

	// 在重新开始游戏时调用的函数
	private void OnRetry()
	{
		// 重新加载当前场景以重新开始游戏
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// 在场景开始时调用的函数
	private void Awake()
	{
		// 获取控制玩家移动的组件
		var motor = GetComponent<PlatformerMotor2D>();

		// 注册跳跃事件的函数
		motor.onJump += OnJump;
		string name_ = transform.name;
		HORIZONTAL = PC2D.Input.HORIZONTAL + name[name.Length - 1];
		VERTICAL = PC2D.Input.VERTICAL + name[name.Length - 1];
		JUMP = PC2D.Input.JUMP + name[name.Length - 1];
		DASH = PC2D.Input.DASH + name[name.Length - 1];
	}

	// 当跳跃时调用的函数
	private void OnJump()
	{
		// 如果跳过跳跃音效
		if (IsSkipJumpSe)
		{
			// 不播放跳跃音效
			IsSkipJumpSe = false;
		}
		// 如果不跳过跳跃音效
		else
		{
			// 播放跳跃音效
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot(m_jumpClip);
		}
	}
}