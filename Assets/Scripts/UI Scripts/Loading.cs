using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update

    public Image mask;
    float originalSize, currentSize = 0.1f;
    public bool loading = false;
    public PointInst inst;

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        SetValue(currentSize);
    }

    void Update()
    {
        if (loading)
        {
            currentSize += 0.15f * Time.deltaTime;
            SetValue(currentSize);
        }
        if (currentSize > 0.9f)
        {
            inst.Enable();
            gameObject.SetActive(false);
        }
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }

    public void Load()
    {
        loading = true;
    }
}
