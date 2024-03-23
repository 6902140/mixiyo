using UnityEngine;

// 控制目标的脚本
public class Goal : MonoBehaviour
{
	// 目标完成时播放的音效
	public AudioClip m_goalClip;

	// 是否完成目标
	private bool m_isGoal;

	// 他のオブジェクトと当たった時に呼び出される関数
	private void OnTriggerEnter2D(Collider2D other)
	{
		// まだゴールしておらず
		if (!m_isGoal)
		{
			// 名前に「Player」が含まれるオブジェクトと当たったら
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
			}
		}
	}
}