using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gpsScript : MonoBehaviour
{
    [SerializeField] private GameObject bulldozer;
    [SerializeField] private GameObject dumpTruck;
    [SerializeField] private GameObject crane;

    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;
    [SerializeField] private GameObject page3;
    [SerializeField] private GameObject report;
    [SerializeField] private GameObject resourceMenu;
    [SerializeField] private GameObject moveText;

    GameObject[] tags;
    bool moving = false;

    private void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        report.SetActive(false);
        tags = GameObject.FindGameObjectsWithTag("selectionTag");
        resourceMenu.SetActive(false);        
    }

    public void indoorSelected()
    {

    }

    public void outdoorSelected()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }

    //Function to select bulldozer
    public void bulldozerFunction()
    {      
        switchTag(bulldozer);

        if (bulldozer.GetComponent<machine1Move>().tagged)
            bulldozer.GetComponent<machine1Move>().tagged = false;
        else
            bulldozer.GetComponent<machine1Move>().tagged = true;
    }

    //Function to select dump truck
    public void dumpTruckFunction()
    {
        switchTag(dumpTruck);

        if (dumpTruck.GetComponent<machine2Move>().tagged)
            dumpTruck.GetComponent<machine2Move>().tagged = false;
        else
            dumpTruck.GetComponent<machine2Move>().tagged = true;
    }
    public void craneFunction()
    {
        switchTag(crane);

        if (crane.GetComponent<craneMove>().tagged)
            crane.GetComponent<craneMove>().tagged = false;
        else
            crane.GetComponent<craneMove>().tagged = true;
    }

    private void switchTag(GameObject Tag)
    {
        if (Tag.transform.GetChild(0).gameObject.activeSelf)
            Tag.transform.GetChild(0).gameObject.SetActive(false);
        else
            Tag.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void removeTags()
    {
        if (bulldozer.GetComponent<machine1Move>().tagged)
        {
            bulldozer.GetComponent<machine1Move>().tagged = false;
            switchTag(bulldozer);
        }
        if (dumpTruck.GetComponent<machine2Move>().tagged)
        {
            dumpTruck.GetComponent<machine2Move>().tagged = false;
            switchTag(dumpTruck);
        }
    }

    public void done()
    {
        page2.SetActive(false);
        page3.SetActive(true);
    }

    public void back()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        report.SetActive(false);
        removeTags();
        moving = false;
        resourceMenu.SetActive(false);
    }

    //Function to move selected machines
    public void move()
    {
        bulldozer.GetComponent<machine1Move>().start();
        dumpTruck.GetComponent<machine2Move>().start();
        moving = !moving;

        if(moving)
        {
            moveText.GetComponent<TextMeshProUGUI>().text = "Stop";
            report.SetActive(false);
        }
        else
        {
            moveText.GetComponent<TextMeshProUGUI>().text = "Move";
            report.SetActive(true);
        }
    }


}
