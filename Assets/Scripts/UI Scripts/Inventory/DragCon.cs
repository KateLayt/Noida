using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCon : MonoBehaviour
{
    Ray2D ray;
    RaycastHit2D hit;
    Vector2 pos, initial;
    GameObject rec_obj;
    public GameBarCon gamecon;
    RectTransform rt;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        initial = rt.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetBack()
    {
        rt.position = initial;
    }


    public void FollowPointer()
    {
        rt.position = Input.mousePosition;
    }

    public void CheckReceiver()
    {
        GetBack();
        if (rec_obj != null)
        {
            gamecon.SetGame(true);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        rec_obj = coll.gameObject;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        rec_obj = null;
    }
}
