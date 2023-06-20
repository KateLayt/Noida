using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollbar : MonoBehaviour
{
    public GameObject lowp, highp;
    RectTransform h_rt, l_rt, own_rt;
    public float range, initial;
    public float val;
    // Start is called before the first frame update
    void Start()
    {
        h_rt = highp.GetComponent<RectTransform>();
        l_rt = lowp.GetComponent<RectTransform>();
        own_rt = GetComponent<RectTransform>();
        initial = own_rt.position.y;
        range = l_rt.position.y - h_rt.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(float value)
    {
        Vector3 pos = own_rt.position;
        pos.y = initial + range * value;
        own_rt.position = pos;
        val = value;
    }
}
