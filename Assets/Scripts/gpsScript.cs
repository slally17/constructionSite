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
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject bulldozerText;
    [SerializeField] private GameObject dumpTruckText;
    [SerializeField] private GameObject craneText;

    GameObject[] tags;
    bool moving = false;
    float timer = 0;

    private void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        report.SetActive(false);
        tags = GameObject.FindGameObjectsWithTag("selectionTag");
        resourceMenu.SetActive(false);        
    }

    private void Update()
    {
        if (moving)
            timer += Time.deltaTime;
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
        if(moving)
        {
            bulldozer.GetComponent<machine1Move>().start();
            dumpTruck.GetComponent<machine2Move>().start();
            crane.GetComponent<craneMove>().start();
            moving = false;
            moveText.GetComponent<TextMeshProUGUI>().text = "Move";
        }
        resourceMenu.SetActive(false);
    }

    //Function to move selected machines
    public void move()
    {
        bulldozer.GetComponent<machine1Move>().start();
        dumpTruck.GetComponent<machine2Move>().start();
        crane.GetComponent<craneMove>().start();
        moving = !moving;

        if(moving)
        {
            timer = 0;
            moveText.GetComponent<TextMeshProUGUI>().text = "Stop";
            report.SetActive(false);
        }
        else
        {
            moveText.GetComponent<TextMeshProUGUI>().text = "Move";
            report.SetActive(true);
            reportFunction();
        }
    }

    private void reportFunction()
    {
        timeText.GetComponent<TextMeshProUGUI>().text = "Time: " + timer.ToString("F1") + " seconds";

        if (bulldozer.GetComponent<machine1Move>().tagged)
        {
            bulldozerText.GetComponent<TextMeshProUGUI>().text = "Bulldozer Cycles: " + bulldozer.GetComponent<machine1Move>().lapCount;
        }
        if (dumpTruck.GetComponent<machine2Move>().tagged)
        {
            dumpTruckText.GetComponent<TextMeshProUGUI>().text = "Dump Truck Cycles: " + dumpTruck.GetComponent<machine2Move>().lapCount;
        }       
        if (crane.GetComponent<craneMove>().tagged)
        {
            craneText.GetComponent<TextMeshProUGUI>().text = "Crane Cycles: " + crane.GetComponent<craneMove>().lapCount;
        }
    }


}
