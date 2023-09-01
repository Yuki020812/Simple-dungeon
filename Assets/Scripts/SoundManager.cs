using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip pickCoin;
    public static AudioClip attack;


    public static AudioClip throwCoin;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        pickCoin = Resources.Load<AudioClip>("Audio/PickCoin");
        throwCoin = Resources.Load<AudioClip>("Audio/ThrowCoin");
        attack = Resources.Load<AudioClip>("Audio/Attack");
        pickCoin = Resources.Load<AudioClip>("PickCoin");
        throwCoin = Resources.Load<AudioClip>("ThrowCoin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayPickCoin()
    {
        audioSrc.PlayOneShot(pickCoin);
    }

    public static void Attack()
    {
        audioSrc.PlayOneShot(attack);
    }
    
}
