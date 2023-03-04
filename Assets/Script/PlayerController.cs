using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    //public GameObject Item;
    public CheckLookAt lookAt;
    public Transform playerCam;
    bool canTakeItem;
    
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
        //CinemachineVirtualCamera.Instantiate(lookAt, transform.position, transform.rotation);
    }
}
