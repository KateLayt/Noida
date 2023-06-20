using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevXP : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevXP instance { get; private set; }
    public float val;
    public Image mask;
    float originalSize;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.height;
    }

    public void SetValue(float value)
    {
        val = value;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize * value);
    }
}