using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float dieTime;
    public float invincibleTime;
    public Slider hpSlider;
    public TMP_Text text;
    private Animator anim;
    private FlashScreen fs;
    private PlayerAttack pa;
    private CapsuleCollider2D capColl;
    private PolygonCollider2D polColl;

    private FloatPointController fpc;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fs = GetComponent<FlashScreen>();
        pa = GetComponentInChildren<PlayerAttack>();
        capColl = GetComponent<CapsuleCollider2D>();
        polColl = GetComponent<PolygonCollider2D>();

        fpc = FindObjectOfType<FloatPointController>().GetComponent<FloatPointController>();

        text.text = health.ToString() + "/" + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitPlayer(int damage)
    {
        health-=damage;
        hpSlider.value = health / maxHealth;
        text.text = health.ToString() + "/" + maxHealth.ToString();
        fs.ScreenFlash();
        if (pa.isAttack)
        {
            //todo
        }
        else
        {
            anim.SetTrigger("Hit");
        }

        GameController.camShake.Shake();
        capColl.enabled = false;
        StartCoroutine(CapCollEnable());
        polColl.enabled = false;
        StartCoroutine(PolCollEnable());
        if (health <= 0)
        {
            hpSlider.transform.Find("Fill Area").localScale = Vector3.zero;
            anim.SetTrigger("Die");
            GameController.isGameAlive = false;
            Destroy(gameObject, dieTime);
        }
        
        

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
