using System.Numerics;
using UnityEngine;

// 控制背景的脚本
public class Background : MonoBehaviour
{
    // 背景滚动的速度
    public UnityEngine.Vector2 m_speed;

    private UnityEngine.Vector2 m_speed_fast = new UnityEngine.Vector2(0, 2.0f);

    private UnityEngine.Vector2 m_speed_slow = new UnityEngine.Vector2(0, 0.5f);

    // 每帧调用的函数
    private void Update()
    {
        if( Input.GetKey(KeyCode.W)||
            Input.GetKey(KeyCode.A)||
            Input.GetKey(KeyCode.S)||
            Input.GetKey(KeyCode.D)||
            Input.GetKey(KeyCode.UpArrow)||
            Input.GetKey(KeyCode.DownArrow)||
            Input.GetKey(KeyCode.LeftArrow)||
            Input.GetKey(KeyCode.RightArrow)
            ){
            m_speed = m_speed_fast;
        }
        else{
            m_speed = m_speed_slow;
        }
        // 获取背景的精灵渲染器组件
        var spriteRenderer = GetComponent<SpriteRenderer>();

        // 获取显示背景纹理的材质
        var material = spriteRenderer.material;

        // 滚动背景的纹理
        material.mainTextureOffset += m_speed * Time.deltaTime;
    }
}