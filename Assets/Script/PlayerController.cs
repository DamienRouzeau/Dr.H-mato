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
    public float sensitivityX = 8f;
    public float sensitivityY = 0.5f;
    float mouseX, mouseY;
    Vector2 mouseInput;

    public void ReceiveInput (Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }




    bool canTakeItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
        ReceiveInput(mouseInput);
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
