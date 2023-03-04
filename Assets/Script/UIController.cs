using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    float chrono = 60;
    public Text chronoText;
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
    }
}
