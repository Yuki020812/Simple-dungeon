using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string ContentText = "";
    //public GameObject DialogBox;
    private bool isSign = false;
    private DialogBoxText dialogText;
    // Start is called before the first frame update
    void Start()
    {
        dialogText = GameObject.FindObjectOfType<DialogBoxText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSign)
        {
            dialogText.Show(ContentText);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            LoadScene.instance.LoadNewScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isSign = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSign = false;
        dialogText.Hide();  
    }
}
