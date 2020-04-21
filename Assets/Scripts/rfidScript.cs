using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rfidScript : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject rfidPage;

    // Start is called before the first frame update
    void Start()
    {
        mainPage.SetActive(true);
        rfidPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void logSelected()
    {

    }
    public void woodSelected()
    {

    }
    public void rebarSelected()
    {

    }
}
