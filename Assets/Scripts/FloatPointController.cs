using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatPointController : MonoBehaviour
{
    private TextMesh text;
    public GameObject floatPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ShowDamage(int damage,Vector3 pos)
    {
        GameObject fp = Instantiate(floatPoint,pos,Quaternion.identity);
        fp.transform.SetParent(this.transform);
        text = fp.GetComponentInChildren<TextMesh>();
        text.text = damage.ToString();
        Destroy(fp, 0.8f);
    }
}
