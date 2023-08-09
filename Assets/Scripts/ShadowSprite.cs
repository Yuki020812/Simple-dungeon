using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite;//当前物体的贴图
    private SpriteRenderer playerSprite;//当前player的贴图

    private Color color;

    [Header("时间控制参数")] 
    public float activeTime;//残影显示时间
    public float activeStart;//残影开始显示时间

    [Header("不透明度控制")] 
    private float alpha;
    public float alphaSet;//不透明度初始值
    public float alphaMultiplier;//不透明度变化系数
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(0.5f, 0.5f, 1, alpha);//color(1,1,1,1)表示100&各通道颜色

        thisSprite.color = color;

        if (Time.time >= activeStart + activeTime)
        {
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
    
    
    
}
