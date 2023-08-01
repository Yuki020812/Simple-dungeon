using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public string ContentText = "";
    public GameObject DialogBox;
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
        if (isSign && Input.GetKeyDown(KeyCode.E))
        {
            dialogText.Show(ContentText);
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
