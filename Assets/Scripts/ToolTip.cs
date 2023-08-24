using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private TMP_Text toolTipText;
    private TMP_Text contentText;
    private CanvasGroup canvasGroup;
    private float targetAplha = 0;
    private float smoothing = 10; 
    // Start is called before the first frame update
    void Start()
    {
        toolTipText = GetComponent<TMP_Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        contentText = transform.Find("Content").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup.alpha != targetAplha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAplha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAplha) <= 0.01f)
            {
                canvasGroup.alpha = targetAplha;
            }
        }
    }

    public void Show(string text)
    {
        contentText.text = text;
        toolTipText.text = text;
        targetAplha = 1;
    }

    public void Hide()
    {
        targetAplha = 0;
    }

    public void SetLocalPosition(Vector2 position)
    {
        transform.localPosition = position;
    }
}
