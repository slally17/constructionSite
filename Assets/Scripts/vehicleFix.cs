using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleFix : MonoBehaviour
{
    [SerializeField] private GameObject machine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = machine.transform.position; 
    }
}
