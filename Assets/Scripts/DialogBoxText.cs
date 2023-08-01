using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBoxText : MonoBehaviour
{
    private TMP_Text dialogText;
    private TMP_Text contentText;

    // Start is called before the first frame update
    void Start()
    {
        dialogText = GetComponent<TMP_Text>();
        contentText = transform.Find("ContentText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string text)
    {
        dialogText.text = text;
        contentText.text = text;
        transform.gameObject.SetActive(true);
    }

    public void Hide()
    {
        transform.gameObject.SetActive(false);
    }
}
