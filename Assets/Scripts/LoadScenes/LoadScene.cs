using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    private static LoadScene _instance;

    public static LoadScene instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("LoadScene").GetComponent<LoadScene>();
            }

            return _instance;
        }
    }
    
    // public GameObject eventObj;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        // DontDestroyOnLoad(this.eventObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNewScene(int index)
    {
        StartCoroutine(LoadNewScenes(index));
    }

    IEnumerator LoadNewScenes(int index)
    {
        anim.SetBool("FadeIn",true);
        anim.SetBool("FadeOut",false);

        yield return new WaitForSeconds(1.2f);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScene;
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        anim.SetBool("FadeIn",false);
        anim.SetBool("FadeOut",true);
    }
}
