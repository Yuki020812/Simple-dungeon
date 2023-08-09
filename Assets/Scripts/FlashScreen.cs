using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour
{
    public Image image;
    public float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenFlash()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b,0.03f);
        yield return new WaitForSeconds(time);
        image.color = new Color(image.color.r, image.color.g, image.color.b,0);
    }
}
