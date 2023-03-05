using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Windows;

public class UIController : MonoBehaviour
{
    float chrono = 60;
    //float phaseflou1 = 45, phaseflou2 = 30, phaseflou3 = 15;
    public Text chronoText;
    public Animator animationFlou;
    public GameObject menu;

    void Start()
    {
        chronoText.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        chronoText.text = "" + chrono;
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        chrono -= Time.deltaTime;
        /*if (chrono < phaseflou1) animationFlou.SetTrigger("flou");
        if (chrono < phaseflou2) animationFlou.SetTrigger("flou");
        if (chrono < phaseflou3) animationFlou.SetTrigger("flou");*/
    }

    public void returnGame()
    {
        menu.SetActive(false);
        Time.timeScale = 0;
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
