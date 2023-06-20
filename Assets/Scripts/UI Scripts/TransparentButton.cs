using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentButton : MonoBehaviour
{
    [Range(0f, 1f)] //1
    public float AlphaLevel = 0.5f; //2
    private Image bt; //3

    void Start()
    {
        bt = gameObject.GetComponent<Image>();
        bt.alphaHitTestMinimumThreshold = AlphaLevel; //4
    }
}
