using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Animator animator;
    float lifetime = 0.7f;
    bool playing = false;

    // Update is called once per frame

    void Update()
    {
        if (playing)
        {
            lifetime -= Time.deltaTime;
            if ( lifetime < 0 )
            {
                playing = false;
                gameObject.SetActive(false);
            }
        }   
    }

    public void PlayEffect()
    {
        animator = GetComponent<Animator>();
        animator.Play("attack_buff");
        playing = true;
        lifetime = 1f;
    }
}
