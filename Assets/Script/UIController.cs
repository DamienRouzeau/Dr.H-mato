using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public Animator playerLoose;
    public GameObject menu;
    public GameObject tutoriel;
    public AudioSource tombe;
    public PlayerController playerController;
    public GameObject defeat;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        chronoText.GetComponent<TextMeshPro>();
    }

    void Update()
    {

        //Lose
        string text = chrono.ToString();
        string number = text.Substring(0, 2);
        chronoText.text = number;
        if (chrono<= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            playerLoose.SetBool("lose", true);
            tombe.Play();
            defeat.SetActive(true);
            Time.timeScale = 0;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
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
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void tuto()
    {
        menu.SetActive(false);
        tutoriel.SetActive(true);
    }

    public void tutoMenu()
    {
        menu.SetActive(true);
        tutoriel.SetActive(false);
    }
}
