using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    bool fade = false;
    SpriteRenderer sr;
    float transparency;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        transparency = 0f;
        sr.color = new Color(1f, 1f, 1f, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            sr.color = new Color(1f, 1f, 1f, transparency);
            transparency -= Time.deltaTime;
            if (transparency <= 0)
            {
                fade = false;
                transparency = 1f;
            }
        }
    }

    public void Fade()
    {
        fade = true;
        transparency = 1f;
    }
}
