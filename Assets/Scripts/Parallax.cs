using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cameraTransform; // 相机的transform组件
    public Vector2 parallaxEffectMultiplier; //控制视差效果的乘数参数(简而言之可以通过设置背景不同层次的不同移动速度实现背景的层次感和真实感) 
    private Vector3 lastCameraPosition; // 用来保存相机的上一个位置

    private float textureUnitSizeX; // 素材图片的宽度和unity一个单位所占像素的比例(简而言之就是这个素材放在场景中占几个格子)

    [SerializeField]private float LightPositionX = 5.5f; // 场景中灯光的偏移位置
    //移动速度倍率
    // public float moverateX, moverateY;
    //获取初始位置
    //private float startpointX, startpointY;
    private void Start()
    {
        cameraTransform = Camera.main.transform; // 获取相机的transform组件
        lastCameraPosition = cameraTransform.position; // 相机的当前位置赋值给上一个位置
        Sprite sprite = GetComponent<SpriteRenderer>().sprite; //获取素材的sprite属性
        Texture2D texture = sprite.texture; // 取得素材texture属性
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit; // 计算素材和单位像素的比例
        //startpointX = transform.position.x;
        //startpointY = transform.position.y;
    }

    private void FixedUpdate()
    {
        //背景的移动
        //transform.position = new Vector3(startpointX + cameraTransform.position.x * moverateX, startpointY + cameraTransform.position.y * moverateY, transform.position.z);
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition; // 计算相机位置和上一个位置的差值,以便于后续图片位移的位置不会产生偏移
        transform.position += new Vector3(deltaMovement.x*parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y); // 物体随着相机移动
        lastCameraPosition = cameraTransform.position; // 相机的当前位置为上一个位置

        LightPositionX = cameraTransform.position.x - transform.position.x > 0 ? Mathf.Abs(LightPositionX):-Mathf.Abs(LightPositionX); // 这里是判断角色的走向 便于灯光移动到角色的前方
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) // 如果相机和当前背景(或物体)的差值大于它素材的比值, 会将它本身向相机移动,以达到无限循环的背景效果.
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;  //计算偏移量
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX + LightPositionX, transform.position.y,transform.position.z);
        }
        
    }
}
