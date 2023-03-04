using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    float chrono = 60;
    //float phaseflou1 = 45, phaseflou2 = 30, phaseflou3 = 15;
    public Text chronoText;
    public Animator animationFlou;
    // Start is called before the first frame update
    void Start()
    {
        chronoText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        chronoText.text = "" + chrono;
    }

    private void FixedUpdate()
    {
        chrono -= Time.deltaTime;
        /*if (chrono < phaseflou1) animationFlou.SetTrigger("flou");
        if (chrono < phaseflou2) animationFlou.SetTrigger("flou");
        if (chrono < phaseflou3) animationFlou.SetTrigger("flou");*/
    }
}
