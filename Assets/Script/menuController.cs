using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject option;
    public GameObject tuto;
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void start()
    {
        SceneManager.LoadScene("Cabinet");
    }

    public void fullscreen()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 60);
    }

    public void windowed()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void goOptions()
    {
        menu.SetActive(false);
        option.SetActive(true);
    }

    public void OtoM()
    {
        menu.SetActive(true);
        option.SetActive(false);
    }

    public void goTuto()
    {
        menu.SetActive(false);
        tuto.SetActive(true);
    }
    public void TtoM()
    {
        menu.SetActive(true);
        tuto.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }
}
