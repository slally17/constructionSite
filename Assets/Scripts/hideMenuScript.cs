using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideMenuScript : MonoBehaviour
{
    [SerializeField] private Canvas showCanvas;

    //Functions to show and hide the menu
    public void showMenu()
    {
        showCanvas.enabled = false;
        GetComponent<Canvas>().enabled = true;
    }
    public void hideMenu()
    {
        showCanvas.enabled = true;
        GetComponent<Canvas>().enabled = false;
    }
}
