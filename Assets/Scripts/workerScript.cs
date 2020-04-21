using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerScript : MonoBehaviour
{
    [SerializeField] private GameObject lShoulder;
    [SerializeField] private GameObject rShoulder;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject neck;

    [SerializeField] private GameObject currentMenu;
    [SerializeField] private GameObject resultsMenu;

    private bool lShoulderBool;
    private bool rShoulderBool;
    private bool backBool;
    private bool neckBool;

    public void lShoulderSelect()
    {
        if(lShoulderBool)
        {
            lShoulderBool = false;
        }
        else
        {
            lShoulderBool = true;
        }
    }
    public void rShoulderSelect()
    {
        if (rShoulderBool)
        {
            rShoulderBool = false;
        }
        else
        {
            rShoulderBool = true;
        }
    }
    public void backSelect()
    {
        if (backBool)
        {
            backBool = false;
        }
        else
        {
            backBool = true;
        }
    }
    public void neckSelect()
    {
        if (neckBool)
        {
            neckBool = false;
        }
        else
        {
            neckBool = true;
        }
    }
    public void select()
    {
        currentMenu.SetActive(false);
        resultsMenu.SetActive(true);
    }
}
