using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public float dieTime;
    public float invincibleTime;
    public Slider hpSlider;
    public TMP_Text text;
    private Animator anim;
    private FlashScreen fs;
    private CapsuleCollider2D capColl;
    private PolygonCollider2D polColl;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fs = GetComponent<FlashScreen>();
        capColl = GetComponent<CapsuleCollider2D>();
        polColl = GetComponent<PolygonCollider2D>();
        text.text = health.ToString() + "/" + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitPlayer(int damage)
    {
        health-=damage;
        hpSlider.value = ((float)health / (float)maxHealth);
        text.text = health.ToString() + "/" + maxHealth.ToString();
        capColl.enabled = false;
        StartCoroutine(CapCollEnable());
        polColl.enabled = false;
        StartCoroutine(PolCollEnable());
        if (health <= 0)
        {
            hpSlider.transform.Find("Fill Area").localScale =  Vector3.zero;
            anim.SetTrigger("Die");
            GameController.isGameAlive = false;
            Destroy(gameObject,dieTime);
        }
        fs.ScreenFlash();
        anim.SetTrigger("Hit");
    }



    IEnumerator CapCollEnable()
    {
        yield return new WaitForSeconds(invincibleTime);
        capColl.enabled = true;
    }
    
    IEnumerator PolCollEnable()
    {
        yield return new WaitForSeconds(invincibleTime);
        polColl.enabled = true;
    }

}
