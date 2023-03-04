using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public GameObject scalpel, marteau;
    public Transform playerCam;
    public LayerMask interractableObject;
    RaycastHit hitinfo;
    bool handEmpty = true;
    public GameObject scalpelInHand, marteauInHAnd;
    bool haveScalpel, haveMarteau;
    bool canTakeItem;
    GameObject itemInHand;

    //Organes
    public GameObject foie;
    public GameObject intestin;
    public GameObject colon;
    public GameObject coeur;
    public GameObject estomac;
    public GameObject rein1;
    public GameObject rein2;
    public GameObject poumous;


    // Start is called before the first frame update
    void Start()
    {
        scalpelInHand.SetActive(false);
        marteauInHAnd.SetActive(false);
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
                
                //hitinfo.transform.position = new Vector3(0.3f, -0.2f, 0.3f);
                handEmpty= false;
                if (hitinfo.collider.CompareTag("scalpel"))
                {
                    scalpelInHand.SetActive(true);
                    haveScalpel= true;
                    itemInHand = hitinfo.rigidbody.gameObject;
                    itemInHand.SetActive(false);
                }
                else if (hitinfo.collider.CompareTag("marteau"))
                {
                    marteauInHAnd.SetActive(true);
                    haveMarteau= true;
                    itemInHand = hitinfo.rigidbody.gameObject;
                    itemInHand.SetActive(false);
                }
            }
        }
        else
        {
            if (haveScalpel)
            {
                var ishit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, 1000f, interractableObject);
                if (ishit && hitinfo.collider.CompareTag("organe"))
                {
                    hitinfo.rigidbody.gameObject.SetActive(false);
                }
                else
                {
                    scalpelInHand.SetActive(false);
                    haveScalpel = false;
                }
            }
            else if (haveMarteau)
            {
                marteauInHAnd.SetActive(false);
                haveMarteau= false;
            }
            itemInHand.SetActive(true);
            itemInHand.transform.position = transform.position;
            handEmpty = true;
        }
    }
}
