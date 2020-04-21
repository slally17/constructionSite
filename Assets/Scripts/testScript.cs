using UnityEngine;
using UnityEngine.Rendering;

//attach this script to your camera object
public class testScript : MonoBehaviour
{
    public RenderTexture cubemapEye;
    public RenderTexture equirect;

    void LateUpdate()
    {
        //Debug.Log("test");
        //Camera cam = GetComponent<Camera>();
        //cam.RenderToCubemap(cubemapEye, 63, Camera.MonoOrStereoscopicEye.Mono);
        //cubemapEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Mono);
    }

    public void test()
    {
        //Debug.Log("test");
        Camera cam = GetComponent<Camera>();
        cam.RenderToCubemap(cubemapEye, 63, Camera.MonoOrStereoscopicEye.Mono);
        cubemapEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Mono);
    }
}