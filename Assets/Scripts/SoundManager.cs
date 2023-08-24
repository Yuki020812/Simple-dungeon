using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip pickCoin;
<<<<<<< HEAD
    public static AudioClip attack;
=======

>>>>>>> 0887a4aff6410cfdee15a76485c274c1a6b5c839
    public static AudioClip throwCoin;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
<<<<<<< HEAD
        pickCoin = Resources.Load<AudioClip>("Audio/PickCoin");
        throwCoin = Resources.Load<AudioClip>("Audio/ThrowCoin");
        attack = Resources.Load<AudioClip>("Audio/Attack");
=======
        pickCoin = Resources.Load<AudioClip>("PickCoin");
        throwCoin = Resources.Load<AudioClip>("ThrowCoin");
>>>>>>> 0887a4aff6410cfdee15a76485c274c1a6b5c839
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayPickCoin()
    {
        audioSrc.PlayOneShot(pickCoin);
    }
<<<<<<< HEAD

    public static void Attack()
    {
        audioSrc.PlayOneShot(attack);
    }
=======
>>>>>>> 0887a4aff6410cfdee15a76485c274c1a6b5c839
    
}
