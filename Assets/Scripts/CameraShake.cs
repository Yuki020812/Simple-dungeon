using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        GameController.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        cam.DOShakePosition(.3f,.1f);
    }


}
