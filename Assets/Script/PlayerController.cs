using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    //public GameObject Item;
    public CheckLookAt lookAt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClic()
    {
        Instantiate(lookAt, transform.position, transform.rotation);
    }
}
