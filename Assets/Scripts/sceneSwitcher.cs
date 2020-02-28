using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public void groundScene()
    {
        SceneManager.LoadScene(2);
    }

    public void modelScene()
    {
        SceneManager.LoadScene(1);
    }
}
