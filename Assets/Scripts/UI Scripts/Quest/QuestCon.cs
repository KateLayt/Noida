using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestCon : MonoBehaviour
{
    int firec = 0, koluc = 0;
    public GameObject f_count, k_count, f_local, k_local, run_button, firstpage, secondpage, wolf, questname, speffect, skill1, skill2;
    public ChacterController ch;
    bool running = false;
    int cur_f, cur_k;
    Text f_c, k_c, fl_c, kl_c;
    // Start is called before the first frame update
    void Start()
    {
        f_c = f_count.GetComponent<Text>();
        k_c = k_count.GetComponent<Text>();
        fl_c = f_local.GetComponent<Text>();
        kl_c = k_local.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            int new_f = Int32.Parse(f_c.text);
            if (cur_f != new_f)
            {
                firec += new_f - cur_f;
                cur_f = new_f;
                fl_c.text = firec.ToString() + "/3";
            }

            int new_k = Int32.Parse(k_c.text);
            if (cur_k != new_k)
            {
                koluc += new_k - cur_k;
                cur_k = new_k;
                kl_c.text = koluc.ToString() + "/3";
            }

            if (firec > 2 && koluc > 2)
            {
                SwitchPage();
            }
        }
    }

    public void StartQuest()
    {
        running = true;
        Button rb = run_button.GetComponent<Button>();
        rb.interactable = false;
        cur_f = Int32.Parse(f_c.text);
        cur_k = Int32.Parse(k_c.text);
    }

    void SwitchPage()
    {
        firstpage.SetActive(false);
        secondpage.SetActive(true);
    }

    public void FinishQuest()
    {
        if (ch.on_spawn)
        {
            GameObject w = GameObject.Find("Wolf(Clone)");
            if (w != null)
            {
                return;
            }
            //secondpage.SetActive(false);
            //questname.SetActive(false);
            skill1.SetActive(true);
            skill2.SetActive(true);
            Instantiate(wolf, new Vector3(-53, -36, 0), Quaternion.identity);
            Fading f = speffect.GetComponent<Fading>();
            f.Fade();
        }
    }
}
