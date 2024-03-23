using UnityEngine;

// 控制背景的脚本
public class Background : MonoBehaviour
{
    // 背景滚动的速度
    public Vector2 m_speed;

    // 每帧调用的函数
    private void Update()
    {
        // 获取背景的精灵渲染器组件
        var spriteRenderer = GetComponent<SpriteRenderer>();

        // 获取显示背景纹理的材质
        var material = spriteRenderer.material;

        // 滚动背景的纹理
        material.mainTextureOffset += m_speed * Time.deltaTime;
    }
}