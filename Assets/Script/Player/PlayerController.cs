using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public Transform playerCam;
    public LayerMask interractableObject;
    RaycastHit hitinfo;
    bool handEmpty = true;





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
        if (handEmpty)
        {
            var ishit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, 1000f, interractableObject);
            if (ishit)
            {
                hitinfo.transform.position = new Vector3(0.3f, -0.2f, 0.3f);
                handEmpty= false;
            }
        }
        else
        {
            hitinfo.rigidbody.AddForce(Vector3.forward * 2f);
            handEmpty = true;
        }
    }
}
