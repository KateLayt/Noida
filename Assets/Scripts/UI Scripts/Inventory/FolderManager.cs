using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderManager : MonoBehaviour
{
    public GameObject Stones, Herbs, Trophies, Shrooms, StI, HeI, TrI, ShI;
    // Start is called before the first frame update
    void Start()
    {
    }

    void HideAll()
    {
        Stones.SetActive(false);
        Herbs.SetActive(false);
        Trophies.SetActive(false);
        Shrooms.SetActive(false);
        StI.SetActive(false);
        HeI.SetActive(false);
        TrI.SetActive(false);
        ShI.SetActive(false);
    }

    public void SwitchFolder(string Folder)
    {
        HideAll();
        switch (Folder)
        {
            case "Stones":
                Stones.SetActive(true);
                StI.SetActive(true);
                break;
            case "Herbs":
                Herbs.SetActive(true);
                HeI.SetActive(true);
                break;
            case "Shrooms":
                Shrooms.SetActive(true);
                ShI.SetActive(true);
                break;
            case "Trophies":
                Trophies.SetActive(true);
                TrI.SetActive(true);
                break;
            default:
                Herbs.SetActive(true);
                HeI.SetActive(true);
                break;
        }
    }
}
