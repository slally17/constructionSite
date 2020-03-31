using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine1Move : MonoBehaviour
{
    //USED FOR BULLDOZER
    [SerializeField] private float speed;
    [SerializeField] private float precision;
    [SerializeField] private Transform[] moveSpots;

    private bool enable;
    [HideInInspector] public bool tagged;
    private int arrayPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        enable = false;
        tagged = false;
        arrayPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enable && tagged)
        {
            //transform.position = Vector3.MoveTowards(transform.position, moveSpots[arrayPosition].position, speed*Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speed;

            Quaternion lookDirection = Quaternion.LookRotation(moveSpots[arrayPosition].position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, 30 * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveSpots[arrayPosition].position) < precision)
            {
                if(arrayPosition < moveSpots.Length-1)
                    arrayPosition++;
                else
                    arrayPosition = 0;
            }
        }
    }

    public void start()
    {
        enable = !enable;
    }
}
