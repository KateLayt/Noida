using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
    
{
    public GameObject InventoryW, Map, AlchemyW;
    public PointInst p_inst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeActive(GameObject Window)
    {
        Window.SetActive(!Window.activeSelf);
    }

    public void OpenWithBlock(GameObject wind)
    {
        if(!wind.activeSelf)
        {
            wind.SetActive(true);
            p_inst.Disable();
        }
        else
        {
            wind.SetActive(false);
            p_inst.Enable();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
