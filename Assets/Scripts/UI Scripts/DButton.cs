using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DButton : MonoBehaviour
{
    public GameObject high, press;
    private Image im;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight()
    {
        press.SetActive(false);
        high.SetActive(true);
    }
    
    public void Press()
    {
        press.SetActive(true);
        high.SetActive(false);
    }
    
    public void Plain()
    {
        press.SetActive(false);
        high.SetActive(false);
    }
}
