using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetReset : MonoBehaviour
{
    public void reset()
    {
        transform.rotation = Quaternion.identity;
    }
}
