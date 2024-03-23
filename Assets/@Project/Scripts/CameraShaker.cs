using System.Collections;
using UnityEngine;

// 摄像机震动脚本
public class CameraShaker : MonoBehaviour
{
    // 震动持续时间（秒）
    public float m_duration = 0.25f;

    // 震动强度
    public float m_magnitude = 0.1f;

    // 触发摄像机震动
    public void Shake()
    {
        StartCoroutine(DoShake());
    }

    // 通过协程实现摄像机震动的处理函数
    private IEnumerator DoShake()
    {
        // 记录摄像机的位置
        var pos = transform.localPosition;

        // 从开始震动到现在的经过时间
        var elapsed = 0f;

        // 在震动持续时间内
        while (elapsed < m_duration)
        {
            // 通过随机值使摄像机位置产生震动
            var x = pos.x + Random.Range(-1f, 1f) * m_magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * m_magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            // 更新经过时间
            elapsed += Time.deltaTime;

            // 暂停当前帧的处理
            yield return null;
        }

        // 震动结束后将摄像机位置重置为初始位置
        transform.localPosition = pos;
    }
}