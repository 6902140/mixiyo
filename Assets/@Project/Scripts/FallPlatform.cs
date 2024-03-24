using UnityEngine;

// 控制下落平台的脚本
public class FallPlatform : MonoBehaviour
{
    // 下落速度
    public float m_speed = 0.3f;

    // 玩家是否接触到上方
    private bool m_isHit;

    // 场景开始时调用的函数
    private void Awake()
    {
        // 获取自身的 MovingPlatformMotor2D 组件
        var motor = GetComponent<MovingPlatformMotor2D>();

        // 注册当玩家接触到平台时调用的事件函数
        motor.onPlatformerMotorContact += OnContact;
    }

    // 当玩家接触到平台时调用的函数
    private void OnContact(PlatformerMotor2D player)
    {
        // 如果玩家正在下落
        if (player.IsFalling())
        {
            // 将玩家标记为接触到上方
            m_isHit = true;
        }
    }

    // 每帧调用的函数
    private void Update()
    {
        // 如果玩家接触到上方
        if (m_isHit)
        {
            // 获取自身的 MovingPlatformMotor2D 组件
            var motor = GetComponent<MovingPlatformMotor2D>();

            // 开始下落
            motor.velocity = Physics2D.gravity * m_speed;
        }
    }
}