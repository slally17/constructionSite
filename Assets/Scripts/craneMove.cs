using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneMove : MonoBehaviour
{
    private bool enable = false;
    [HideInInspector] public bool tagged = false;
    [HideInInspector] public int lapCount;
    private int previous, current;
    private float rotation = 0;
    private float timer = 1.5f*Mathf.PI;

    [SerializeField] private GameObject craneTop;


    void Start()
    {

    }

    void Update()
    {
        if (enable && tagged)
        {
            previous = Mathf.RoundToInt((timer - 1.5f * Mathf.PI) % (2 * Mathf.PI));
            timer += Time.deltaTime*0.25f;
            current = Mathf.RoundToInt((timer - 1.5f * Mathf.PI) % (2 * Mathf.PI));

            if (previous == 6 && current == 0)
                lapCount++;

            rotation = -60 * (Mathf.Sin(timer) + 1.0f);
            craneTop.transform.localEulerAngles = new Vector3(0, rotation, 0);
        }

    }

    public void start()
    {
        if (enable)
        {
            //lapCount = Mathf.RoundToInt((timer - 1.5f * Mathf.PI) % (2 * Mathf.PI));
            enable = false;
        }
        else
        {
            //timer = 1.5f * Mathf.PI;
            lapCount = 0;
            enable = true;
        }
    }
}
