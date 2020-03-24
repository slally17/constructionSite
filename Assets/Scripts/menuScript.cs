using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject machine1;
    [SerializeField] private GameObject machine2;
    [SerializeField] private GameObject worker;
    [SerializeField] private GameObject tripod;
    [SerializeField] private GameObject scanner;
    [SerializeField] private GameObject[] targets;
    [SerializeField] private GameObject scannerCanvas;
    [SerializeField] private GameObject drone;

    [SerializeField] private GameObject scannerMenu;
    [SerializeField] private GameObject scannerButtons;
    [SerializeField] private GameObject sensorMenu;
    [SerializeField] private GameObject sensorButtons;
    [SerializeField] private GameObject resourceMenu;
    [SerializeField] private GameObject resourceButtons;
    [SerializeField] private GameObject tripodMenu;
    [SerializeField] private GameObject tripodButtons;
    [SerializeField] private Canvas droneCanvas;
    [SerializeField] private GameObject menuBackButton;
    [SerializeField] private GameObject menuBackButton2;
    [SerializeField] private Canvas showCanvas;
    [SerializeField] private Canvas flightCanvas;
    [SerializeField] private Slider rotateSlider;
    [SerializeField] private Slider horizontalSlider;
    [SerializeField] private Slider verticalSlider;

    [SerializeField] private GameObject tripodScripts;

    [SerializeField] private float[] tripodMove = new float[3];
    [SerializeField] private float[] scannerMove = new float[3];
    [SerializeField] private float[] droneMove = new float[3];
    [SerializeField] private float[] backMove = new float[3];

    bool move = false;
    bool sensors = false;
    bool gps = false;
    bool targetsEnabled = false;
    bool tripodLevel = false;
    GameObject[] tags;
    Renderer[][] targetRenderers = new Renderer[3][];

    void Start()
    {
        sensorMenu.SetActive(false);
        sensorButtons.SetActive(false);
        resourceMenu.SetActive(false);
        resourceButtons.SetActive(false);
        scannerMenu.SetActive(false);
        scannerButtons.SetActive(false);
        tripodMenu.SetActive(false);
        tripodButtons.SetActive(false);
        menuBackButton.SetActive(false);
        menuBackButton2.SetActive(false);

        tripod.GetComponent<Renderer>().enabled = false;
        scanner.GetComponent<Renderer>().enabled = false;
        scannerCanvas.GetComponent<Canvas>().enabled = false;

        for (int i = 0; i < targets.Length; i++)
        {
            targetRenderers[i] = new Renderer[2];
            targetRenderers[i] = targets[i].GetComponentsInChildren<Renderer>();
            foreach(Renderer r in targetRenderers[i])
                r.enabled = false;
        }

        tags = GameObject.FindGameObjectsWithTag("selectionTag");
        disableTags();
    }

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

    //Functions to reset and quit scene.
    public void resetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void quitGame()
    {
        Application.Quit();
    }

    //Sensor Functions

    //Functions to select GPS
    public void gpsSelected()
    {
        sensorSelected();
        gps = true;
        resourceMenu.SetActive(true);
        resourceButtons.SetActive(true);
    }
    private void switchTag(GameObject Tag)
    {
        //disableTags();
        if(Tag.transform.GetChild(0).gameObject.activeSelf)
            Tag.transform.GetChild(0).gameObject.SetActive(false);
        else
            Tag.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void disableTags()
    {
        for (int i = 0; i < tags.Length; i++)
        {
            tags[i].gameObject.SetActive(false);
        }
    }

    //Function to select laserScanner
    public void laserScannerSelected()
    {
        sensorSelected();
        scannerMenu.SetActive(true);
        scannerButtons.SetActive(true);
    }
    public void tripodSelected()
    {
        tripodMenu.SetActive(true);
        tripodButtons.SetActive(true);
        tripod.GetComponent<Renderer>().enabled = true;        
    }
    public void positionTripod()
    {
        Vector3 newPosition = tripod.transform.position;
        mainCamera.transform.position = newPosition + new Vector3(tripodMove[0], tripodMove[1], tripodMove[2]);
        menuBackButton.SetActive(true);
        GetComponent<Canvas>().enabled = false;
    }
    public void levelTripod()
    {
        tripodLevel = true;
    }
    public void scannerBodySelected()
    {
        if(tripod.GetComponent<Renderer>().enabled == true)
        {
            tripodMenu.SetActive(false);
            tripodButtons.SetActive(false);
            scanner.GetComponent<Renderer>().enabled = true;
            //scanner.transform.parent.parent.GetComponent<ManipulationHandler>()
            //tripodScripts.GetComponent<ManipulationHandler>().enabled = false;
            MonoBehaviour[] scripts = tripodScripts.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }
    }
    public void targetsSelected()
    {
        targetsEnabled = true;

        for (int i=0;i<targets.Length;i++)
        {
            foreach (Renderer r in targetRenderers[i])
                r.enabled = true;
        }
    }
    public void scannerInterface()
    {
        if(tripod.GetComponent<Renderer>().enabled == true && scanner.GetComponent<Renderer>().enabled == true && targetsEnabled && tripodLevel)
        {
            menuBackButton.SetActive(true);
            scannerCanvas.GetComponent<Canvas>().enabled = true;

            Vector3 newPosition = scanner.transform.position;
            mainCamera.transform.position = newPosition + new Vector3(scannerMove[0], scannerMove[1], scannerMove[2]);
            //mainCamera.transform.eulerAngles = mainCamera.transform.eulerAngles + new Vector3(0, 90, 0);
            GetComponent<Canvas>().enabled = false;
            scannerMenu.SetActive(false);
            scannerButtons.SetActive(false);
        }
    }
    public void scan()
    {
        if(scanner.GetComponent<Renderer>().enabled == true)
        {
            scanner.GetComponent<Animator>().SetBool("spin", true);
        }
    }
    public void backMenu()
    {
        Vector3 newPosition = this.transform.position;
        mainCamera.transform.position = newPosition + new Vector3(backMove[0], backMove[1], backMove[2]);
        menuBackButton.SetActive(false);
        menuBackButton2.SetActive(false);
        GetComponent<Canvas>().enabled = true;
        resetScanner();
        resetDrone();
    }
    private void resetScanner()
    {
        scannerCanvas.GetComponent<Canvas>().enabled = false;
        scannerCanvas.GetComponent<scanScript>().resolution = 0;
        scannerCanvas.GetComponent<scanScript>().quality = 0;
        scannerCanvas.GetComponent<scanScript>().color = 0;
        scannerCanvas.GetComponent<scanScript>().profile = 0;
        scannerCanvas.GetComponent<scanScript>().coverage = false;
    }
    private void resetDrone()
    {
        drone.SetActive(false);
        droneCanvas.enabled = false;
        drone.GetComponent<droneScript>().taskSelected = false;
        drone.GetComponent<droneScript>().power = false;
        drone.GetComponent<droneScript>().motor = false;
        drone.transform.position = new Vector3(2.15f, -0.85f, 0.1717794f);
        drone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        flightCanvas.enabled = false;
        rotateSlider.value = 0;
        horizontalSlider.value = 0;
        verticalSlider.value = 0;
    }

    //Functions for drone
    public void droneSelected()
    {
        menuBackButton2.SetActive(true);
        drone.SetActive(true);
        droneCanvas.enabled = true;
        Vector3 newPosition = droneCanvas.transform.position;
        mainCamera.transform.position = newPosition + new Vector3(droneMove[0], droneMove[1], droneMove[2]);
        //mainCamera.transform.eulerAngles = mainCamera.transform.eulerAngles + new Vector3(25, 0, 0);
        GetComponent<Canvas>().enabled = false;
    }

    //Resource Functions

    //Function to select bulldozer
    public void machine1Function()
    {
        if(move)
        {
            machine1.GetComponent<machine1Move>().start();
        }

        if(sensors)
        {
            if(gps)
            {
                switchTag(machine1);
                machine1.GetComponent<machine1Move>().switchTag();
            }
        }
    }

    //Function to select dump truck
    public void machine2Function()
    {
        if(move)
        {
            machine2.GetComponent<machine2Move>().start();
        }

        if(sensors)
        {
            if(gps)
            {
                switchTag(machine2);
                machine2.GetComponent<machine2Move>().switchTag();
            }
        }
    }

    //Function to select worker
    public void workerFunction()
    {
        if(move)
        {
            worker.GetComponent<workerMove>().start();
        }

        if(sensors)
        {
            if(gps)
            {
                switchTag(worker);
                worker.GetComponent<workerMove>().switchTag();
            }
        }
    }

    //Functions to select move
    public void moveSelected()
    {
        sensorsDone();
        resourceMenu.SetActive(true);
        resourceButtons.SetActive(true);
        move = true;
    }
    private void moveDone()
    {
        move = false;
        resourceMenu.SetActive(false);
        resourceButtons.SetActive(false);
    }

    //Functions to select sensors
    public void sensorsSelected()
    {
        sensors = true;
        moveDone();
        sensorMenu.SetActive(true);
        sensorButtons.SetActive(true);
    }
    private void sensorSelected()
    {
        scanner.GetComponent<Animator>().SetBool("spin", false);
        scannerMenu.SetActive(false);
        scannerButtons.SetActive(false);
        gps = false;
        resourceMenu.SetActive(false);
        resourceButtons.SetActive(false);
    }
    public void sensorsDone()
    {
        scanner.GetComponent<Animator>().SetBool("spin", false);
        sensors = false;
        gps = false;
        moveDone();
        resourceMenu.SetActive(false);
        resourceButtons.SetActive(false);
        sensorMenu.SetActive(false);
        sensorButtons.SetActive(false);
        scannerMenu.SetActive(false);
        scannerButtons.SetActive(false);
    }
}
