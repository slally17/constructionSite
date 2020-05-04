using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rfidScript : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject resultsPage;
    [SerializeField] private GameObject rfidPage;
    [SerializeField] private GameObject logFlag;
    [SerializeField] private GameObject rebarFlag;
    [SerializeField] private GameObject woodFlag;
    [SerializeField] private GameObject logReport;
    [SerializeField] private GameObject rebarReport;
    [SerializeField] private GameObject woodReport;

    private bool log;
    private bool wood;
    private bool rebar;

    // Start is called before the first frame update
    void Start()
    {
        log = false;
        wood = false;
        rebar = false;
        logReport.SetActive(false);
        woodReport.SetActive(false);
        rebarReport.SetActive(false);
        mainPage.SetActive(true);
        resultsPage.SetActive(false);
        rfidPage.SetActive(false);
    }

    public void logSelected()
    {
        if (log)
        {
            log = false;
            logFlag.SetActive(false);
        }
        else
        {
            log = true;
            logFlag.SetActive(true);
        }
    }
    public void woodSelected()
    {
        if (wood)
        {
            wood = false;
            woodFlag.SetActive(false);
        }
        else
        {            
            wood = true;
            woodFlag.SetActive(true);
        }
    }
    public void rebarSelected()
    {
        if (rebar)
        {
            rebar = false;
            rebarFlag.SetActive(false);
        }
        else
        {
            rebar = true;
            rebarFlag.SetActive(true);
        }
    }

    public void done()
    {
        mainPage.SetActive(false);
        resultsPage.SetActive(true);
        if (log)
        {
            logReport.SetActive(true);
        }
        if (wood)
        {
            woodReport.SetActive(true);
        }
        if (rebar)
        {
            rebarReport.SetActive(true);
        }
    }

    public void back()
    {
        log = false;
        wood = false;
        rebar = false;
        logFlag.SetActive(false);
        woodFlag.SetActive(false);
        rebarFlag.SetActive(false);
        logReport.SetActive(false);
        woodReport.SetActive(false);
        rebarReport.SetActive(false);
        mainPage.SetActive(true);
        resultsPage.SetActive(false);
        rfidPage.SetActive(false);
    }
}
