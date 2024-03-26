using UnityEngine;
using UnityEngine.SceneManagement;

// 控制目标的脚本
public class Goal : MonoBehaviour
{
	// 目标完成时播放的音效
	public AudioClip m_goalClip;

	// 是否完成目标
	private bool m_isGoal;

	private static int m_goalCount = 2;

	// 当与其他对象发生碰撞时调用的函数
	private void OnTriggerEnter2D(Collider2D other)
	{
		// 如果尚未完成目标
		if (!m_isGoal)
		{
			// 如果与名称包含"Player"的对象发生碰撞
			if (other.name.Contains("Player"))
			{
				// 在场景中查找 CameraShaker 脚本
				var cameraShake = FindObjectOfType<CameraShaker>();

				// 使用 CameraShaker 震动相机
				cameraShake.Shake();

				// 记录已完成目标，以防止重复触发
				m_isGoal = true;

				// 获取目标的动画组件
				var animator = GetComponent<Animator>();

				// 播放目标完成时的动画
				animator.Play("Pressed");

				// 播放目标完成时的音效
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot(m_goalClip);

				m_goalCount--;

				if(m_goalCount == 0)
				{
					// 加载下一个场景
					SceneManager.LoadScene("Stage2");
				}
			}
		}
	}
}