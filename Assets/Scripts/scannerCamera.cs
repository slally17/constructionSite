using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class scannerCamera : MonoBehaviour
{
    //[SerializeField] private RenderTexture cubemapEye;
    //[SerializeField] private RenderTexture equirect;

    [SerializeField] private Canvas display;
    [SerializeField] private GameObject saveDisplay;
    Camera snapCam;

    int startingResWidth = 6;
    int startingResHeight = 6;
    int resWidth, resHeight;

    float cameraWidth = 0;
    float cameraHeightMin = 0;
    float cameraHeightMax = 0;
    float cameraHeight;

    Texture2D snapshot;


    void Awake()
    {
        //snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapCam = GetComponent<Camera>();
        snapCam.gameObject.SetActive(false);
        //display.gameObject.SetActive(false);
        //display.GetComponent<Canvas>().enabled = false;
    }

    public void takeScan(int resolution, int quality, int color)
    {
        //Debug.Log(cameraWidth);
        snapCam.lensShift = new Vector2(0, (float)(0.5+((cameraHeightMin)/100)));
        
        if (color == 1)
            GetComponent<Grayscale>().enabled = false;
        else if(color == 2)
            GetComponent<Grayscale>().enabled = true;

        cameraHeight = cameraHeightMax - cameraHeightMin;
        resWidth = (int)(startingResWidth * cameraWidth * ((float)quality / (float)resolution));
        resHeight = (int)(startingResHeight * cameraHeight * ((float)quality / (float)resolution));
        snapCam.fieldOfView = cameraWidth;
        if(cameraWidth>140)
            snapCam.fieldOfView = 140;
        snapCam.aspect = cameraWidth / cameraHeight;

        snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);

        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if(false)
        {
            //Input
            snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string fileName = snapshotName();
            System.IO.File.WriteAllBytes(fileName, bytes);
            snapCam.gameObject.SetActive(false);


            //Output
            //display.gameObject.SetActive(true);
            display.GetComponent<RectTransform>().sizeDelta = new Vector2(resWidth, resHeight);
            //byte[] bytes2 = System.IO.File.ReadAllBytes(fileName);
            Texture2D output = new Texture2D(resWidth, resHeight);
            output.LoadImage(bytes);
            display.GetComponentInChildren<RawImage>().texture = output;

            bytes = null;
            snapshot = null;
            output = null;
        }

        if(snapCam.gameObject.activeInHierarchy)
        {
            //Debug.Log("test");
            //Test
            //Camera cam = GetComponent<Camera>();
            //cam.RenderToCubemap(cubemapEye, 63, Camera.MonoOrStereoscopicEye.Mono);
            //cubemapEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Mono);


            //Input
            snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            //string fileName = snapshotName();
            //System.IO.File.WriteAllBytes(fileName, bytes);
            snapCam.gameObject.SetActive(false);


            //Output
            //display.gameObject.SetActive(true);
            display.GetComponent<RectTransform>().sizeDelta = new Vector2(resWidth, resHeight);
            //byte[] bytes2 = System.IO.File.ReadAllBytes(fileName);
            Texture2D output = new Texture2D(resWidth, resHeight);
            output.LoadImage(bytes);
            display.transform.GetChild(0).GetComponent<RawImage>().texture = output;
            saveDisplay.GetComponent<saveScan>().saveTexture180(output);

            bytes = null;
            snapshot = null;
            output = null;
        }
    }
    
    string snapshotName()
    {
        return string.Format("{0}/Snapshots/snap_{1}x{2}_{3}.png",
            Application.temporaryCachePath,
            resWidth,
            resHeight,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void cameraWidthSlider(Slider newWidth)
    {
        cameraWidth = (int)newWidth.value;
    }
    public void cameraMinHeightSlider(Slider newHeightMin)
    {
        cameraHeightMin = (int)newHeightMin.value;
    }
    public void cameraMaxHeightSlider(Slider newHeightMax)
    {
        cameraHeightMax = (int)newHeightMax.value;
    }
}
