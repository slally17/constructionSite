using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imuScript : MonoBehaviour
{
    [SerializeField] private GameObject laborer;
    [SerializeField] private GameObject painter;
    [SerializeField] private GameObject carpenter1;
    [SerializeField] private GameObject carpenter2;
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject laborerPage;
    [SerializeField] private GameObject painterPage;
    [SerializeField] private GameObject carpenter1Page;
    [SerializeField] private GameObject carpenter2Page;
    [SerializeField] private GameObject resultsPage;

    [SerializeField] private GameObject imuPage;

    // Start is called before the first frame update
    void Start()
    {
        mainPage.SetActive(true);
        laborerPage.SetActive(false);
        painterPage.SetActive(false);
        carpenter1Page.SetActive(false);
        carpenter2Page.SetActive(false);
        resultsPage.SetActive(false);

        imuPage.SetActive(false);
    }

    public void laborerSelect()
    {
        mainPage.SetActive(false);
        laborerPage.SetActive(true);
    }
    public void painterSelect()
    {
        mainPage.SetActive(false);
        painterPage.SetActive(true);
    }
    public void carpenter1Select()
    {
        mainPage.SetActive(false);
        carpenter1Page.SetActive(true);
    }
    public void carpenter2Select()
    {
        mainPage.SetActive(false);
        carpenter2Page.SetActive(true);
    }    
    public void backSelected()
    {
        resultsPage.SetActive(false);
        laborerPage.SetActive(false);
        painterPage.SetActive(false);
        carpenter1Page.SetActive(false);
        carpenter2Page.SetActive(false);
        mainPage.SetActive(true);

        imuPage.SetActive(false);
    }

}
