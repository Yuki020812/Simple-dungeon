using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cameraTransform; // �����transform���
    public Vector2 parallaxEffectMultiplier; //�����Ӳ�Ч���ĳ�������(�����֮����ͨ�����ñ�����ͬ��εĲ�ͬ�ƶ��ٶ�ʵ�ֱ����Ĳ�θк���ʵ��) 
    private Vector3 lastCameraPosition; // ���������������һ��λ��

    private float textureUnitSizeX; // �ز�ͼƬ�Ŀ�Ⱥ�unityһ����λ��ռ���صı���(�����֮��������زķ��ڳ�����ռ��������)

    [SerializeField]private float LightPositionX = 5.5f; // �����еƹ��ƫ��λ��
    //�ƶ��ٶȱ���
    // public float moverateX, moverateY;
    //��ȡ��ʼλ��
    //private float startpointX, startpointY;
    private void Start()
    {
        cameraTransform = Camera.main.transform; // ��ȡ�����transform���
        lastCameraPosition = cameraTransform.position; // ����ĵ�ǰλ�ø�ֵ����һ��λ��
        Sprite sprite = GetComponent<SpriteRenderer>().sprite; //��ȡ�زĵ�sprite����
        Texture2D texture = sprite.texture; // ȡ���ز�texture����
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit; // �����زĺ͵�λ���صı���
        //startpointX = transform.position.x;
        //startpointY = transform.position.y;
    }

    private void FixedUpdate()
    {
        //�������ƶ�
        //transform.position = new Vector3(startpointX + cameraTransform.position.x * moverateX, startpointY + cameraTransform.position.y * moverateY, transform.position.z);
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition; // �������λ�ú���һ��λ�õĲ�ֵ,�Ա��ں���ͼƬλ�Ƶ�λ�ò������ƫ��
        transform.position += new Vector3(deltaMovement.x*parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y); // ������������ƶ�
        lastCameraPosition = cameraTransform.position; // ����ĵ�ǰλ��Ϊ��һ��λ��

        LightPositionX = cameraTransform.position.x - transform.position.x > 0 ? Mathf.Abs(LightPositionX):-Mathf.Abs(LightPositionX); // �������жϽ�ɫ������ ���ڵƹ��ƶ�����ɫ��ǰ��
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) // �������͵�ǰ����(������)�Ĳ�ֵ�������زĵı�ֵ, �Ὣ������������ƶ�,�Դﵽ����ѭ���ı���Ч��.
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;  //����ƫ����
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX + LightPositionX, transform.position.y,transform.position.z);
        }
        
    }
}
