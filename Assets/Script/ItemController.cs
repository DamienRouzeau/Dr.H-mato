using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Transform player, playerCam;
    bool canBePick, isPicked, isTouched;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= 50f)
        {
            canBePick= true;
        }
        else
        {
            canBePick= false;
        }

        if (canBePick && Input.GetKey(KeyCode.Mouse0)) 
        {
            print("test");
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            isPicked= true;
        }

        if (isPicked)
        {
            if(isTouched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isPicked= false;
                isTouched= false;
            }

            if (!Input.GetKey(KeyCode.Mouse0)) 
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isPicked= false;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isPicked)
        {
            isTouched= true;
        }
    }
}
