using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appearing : MonoBehaviour
{
    float transparency = 0f;
    GameObject desc;
    Image image;
    bool appear = false;
    float ping;

    // Start is called before the first frame update
    void Start()
    {
        desc = gameObject.transform.GetChild(0).gameObject;
        image = desc.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        if (appear)
        {
            ping -= Time.deltaTime;
            if (ping < 0)
            {
                desc.SetActive(true);
                image.color = new Color(image.color.r, image.color.g, image.color.b, transparency);
                transparency += Time.deltaTime * 2f;
            }
        }
    }

    public void Appear()
    {
        appear = true;
        ping = 1f;
    }

    public void Disappear()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        transparency = 0f;
        appear = false;
        desc.SetActive(false);
    }
}
