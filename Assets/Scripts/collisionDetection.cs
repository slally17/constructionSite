using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private float collisionDistance = 1;
    [SerializeField] private GameObject[] otherResources;

    bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        colliding = false;
        display.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        colliding = false;

        for(int i=0; i<otherResources.Length; i++)
        {
            if(Vector3.Distance(transform.position, otherResources[i].transform.position) < collisionDistance)
            {
                colliding = true;
            }
            //Debug.Log(Vector3.Distance(transform.position, otherResources[i].transform.position));
        }

        if(colliding)
            display.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        else
            display.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    public void collisidionDistanceSlider(float newValue)
    {
        collisionDistance = newValue;
    }
}
