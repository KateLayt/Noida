using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountHolder : MonoBehaviour
{
    public GameObject crap_counter, raz_counter, fire_counter, apple_counter, kol_counter;
    public GameObject cc, rc, fc, ac, kc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(string name, int value)
    {
        switch (name)
        {
            case "Crap":
                ChangeValue(crap_counter, value);
                ChangeValue(cc, value);
                break;
            case "Razryv":
                ChangeValue(raz_counter, value);
                ChangeValue(rc, value);
                break;
            case "Apple":
                ChangeValue(apple_counter, value);
                ChangeValue(ac, value);
                break;
            case "Koluka":
                ChangeValue(kol_counter, value);
                ChangeValue(kc, value);
                break;
            case "Zarc":
                ChangeValue(fire_counter, value);
                ChangeValue(fc, value);
                break;
            default:
                return;
        }
    }

    void ChangeValue(GameObject counter, int value)
    {
        Text count = counter.GetComponent<Text>();
        int c = Int32.Parse(count.text) + value;
        count.text = c.ToString();
    }
}
