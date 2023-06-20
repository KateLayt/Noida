using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Interactable : MonoBehaviour
{
    public Sprite awail, lined, nonawail, sel;
    bool awailable = true, selected = false;
    SpriteRenderer sr;
    float ticker = 5f;
    GameObject char_obj, manager;
    public bool dissapearing;
    Text count;
    ChacterController character;
    CountHolder ch;
    string count_name;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("UI Manager");
        ch = manager.GetComponent<CountHolder>();
        count_name = gameObject.name.Split(" ")[0];
        sr = GetComponent<SpriteRenderer>();
        char_obj = GameObject.Find("Char");
        character = char_obj.GetComponent<ChacterController>();

    }


    // Update is called once per frame
    void Update()
    {

        if (selected)
        {
            if ((character.pointpos.x != transform.position.x) || (character.pointpos.y != transform.position.y))
            {
                Deselect();
            }
        }
        if (ticker > 0)
        {
            ticker -= Time.deltaTime;
            if (ticker <= 0)
            {
                awailable = true;
                sr.sprite = awail;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    { 
        if (selected && (collider.gameObject == char_obj))
        {
            Interact();
        }
    }

    public void Line()
    {
        if (selected)
        {
            return;
        }

        if (awailable)
        {
            sr.sprite = lined;
        }
    }

    public void Unline()
    {
        if (selected)
        {
            return;
        }
        if (awailable)
        {
            sr.sprite = awail;
        }
        else
        {
            sr.sprite = nonawail;

        }
    }

    public void SelectInter()
    {
        if (awailable)
        {
            character.GetPoint(transform.position);
            sr.sprite = sel;
            selected = true;
        }
    }

    public void Deselect()
    {
        selected = false;
        Unline();
    }

    void Interact()
    {
        //do sth to inventory
        if (awailable)
        {
            ch.Change(count_name, 1);
            sr.sprite = nonawail;
            awailable = false;
            Deselect();
            ticker = 5f;
            if (dissapearing)
            {
                Destroy(gameObject);
            }
        }
    }
}
