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
    public LayerMask interractableObject;
    RaycastHit hitinfo;



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

        var ishit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, 1000f, interractableObject) ;
        if (ishit)
        {
            print(hitinfo.collider.gameObject.name);
        }
    }
}
