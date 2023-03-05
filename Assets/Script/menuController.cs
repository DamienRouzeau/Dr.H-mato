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
    public Animator animator;
    void Start()
    {
        Time.timeScale = 1;
        animator.SetTrigger("menu");
        Screen.SetResolution(1920, 1080, false);
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("option");
    }

    public void OtoM()
    {
        animator.SetTrigger("optionMenu");
    }

    public void goTuto()
    {
        animator.SetTrigger("tuto");
    }
    public void Suite()
    {
        animator.SetTrigger("next");
    }

    public void quit()
    {
        Application.Quit();
    }
}
