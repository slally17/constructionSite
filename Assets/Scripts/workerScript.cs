using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class workerScript : MonoBehaviour
{
    [SerializeField] private GameObject shoulder;
    [SerializeField] private GameObject thigh;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject neck;
    [SerializeField] private GameObject shoulderText;
    [SerializeField] private GameObject thighText;
    [SerializeField] private GameObject backText;
    [SerializeField] private GameObject neckText;

    [SerializeField] private GameObject currentMenu;
    [SerializeField] private GameObject resultsMenu;

    public bool active = false;
    public string fileName;

    private bool shoulderBool = false;
    private bool thighBool = false;
    private bool backBool = false;
    private bool neckBool = false;
    private float timer = 0;
    private int timeCount = 0;
    private string fileContent = "";

    private void Update()
    {
        if(active)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timeCount++;
                timer = 0;

                fileContent += "\nTime: " + timeCount.ToString() + " seconds\n";

                if (shoulderBool)
                {
                    shoulderText.GetComponent<TextMeshProUGUI>().text = shoulder.transform.eulerAngles.y.ToString("#.00");
                    fileContent += "Shoulder: " + shoulder.transform.eulerAngles.x.ToString("#.00") +
                        " " + shoulder.transform.eulerAngles.y.ToString("#.00") +
                        " " + shoulder.transform.eulerAngles.z.ToString("#.00") + "\n";
                }
                else
                    shoulderText.GetComponent<TextMeshProUGUI>().text = "";

                if (thighBool)
                {
                    thighText.GetComponent<TextMeshProUGUI>().text = thigh.transform.eulerAngles.y.ToString("#.00");
                    fileContent += "Thigh: " + thigh.transform.eulerAngles.x.ToString("#.00") +
                        " " + thigh.transform.eulerAngles.y.ToString("#.00") +
                        " " + thigh.transform.eulerAngles.z.ToString("#.00") + "\n";
                }
                else
                    thighText.GetComponent<TextMeshProUGUI>().text = "";

                if (backBool)
                {
                    backText.GetComponent<TextMeshProUGUI>().text = back.transform.eulerAngles.y.ToString("#.00");
                    fileContent += "Back: " + back.transform.eulerAngles.x.ToString("#.00") +
                        " " + back.transform.eulerAngles.y.ToString("#.00") +
                        " " + back.transform.eulerAngles.z.ToString("#.00") + "\n";
                }
                else
                    backText.GetComponent<TextMeshProUGUI>().text = "";

                if (neckBool)
                {
                    neckText.GetComponent<TextMeshProUGUI>().text = neck.transform.eulerAngles.y.ToString("#.00");
                    fileContent += "Neck: " + neck.transform.eulerAngles.x.ToString("#.00") +
                        " " + neck.transform.eulerAngles.y.ToString("#.00") +
                        " " + neck.transform.eulerAngles.z.ToString("#.00") + "\n";
                }
                else
                    neckText.GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void shoulderSelect()
    {
        shoulderBool = !shoulderBool;
    }
    public void thighSelect()
    {
        thighBool = !thighBool;
    }
    public void backSelect()
    {
        backBool = !backBool;
    }
    public void neckSelect()
    {
        neckBool = !neckBool;
    }
    public void reset()
    {
        if(fileContent.Length > 1)
        {
            File.AppendAllText(fileName, fileContent);
            fileContent = "";
        }
        shoulderBool = false;
        thighBool = false;
        backBool = false;
        neckBool = false;
        active = false;
        timer = 0;
        timeCount = 0;
    }
    public void select()
    {
        currentMenu.SetActive(false);
        resultsMenu.SetActive(true);
    }
}
