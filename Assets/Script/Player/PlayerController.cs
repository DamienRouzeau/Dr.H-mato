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

    //Organes in hand
    public GameObject foieInHand;
    public GameObject intestinInHand;
    public GameObject colonInHand;
    public GameObject coeurInHand;
    public GameObject estomacInHand;
    public GameObject rein1InHand;
    public GameObject rein2InHand;
    public GameObject poumousInHand;

    //Organes fixés
    public bool foiefixe = true;
    public bool intestinfixe = true;
    public bool colonfixe = true;
    public bool coeurfixe = true;
    public bool estomacfixe = true;
    public bool rein1fixe = true;
    public bool rein2fixe = true;
    public bool poumousfixe = true;


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
                else if (hitinfo.collider.CompareTag("organe"))
                {
                    switch (hitinfo.rigidbody.name)
                    {
                        case "foie":
                            foie.SetActive(false);
                            foieInHand.SetActive(true);
                            break;
                        case "intestin_grelle_retopo":
                            intestin.SetActive(false);
                            intestinInHand.SetActive(true);
                            break;
                        case "colon_low":
                            colon.SetActive(false);
                            colonInHand.SetActive(true);
                            break;
                        case "heart":
                            coeur.SetActive(false);
                            coeurInHand.SetActive(true);
                            break;
                        case "estomac_V2":
                            estomac.SetActive(false);
                            estomacInHand.SetActive(true);
                            break;
                        case "rein_V2":
                            rein1.SetActive(false);
                            rein1InHand.SetActive(true);
                            break;
                        case "rein_V2 (1)":
                            rein2.SetActive(false);
                            rein2InHand.SetActive(true);
                            break;
                        case "poumon_unt":
                            poumous.SetActive(false);
                            poumousInHand.SetActive(true);
                            break;
                        default: break;
                    }
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
                    switch(hitinfo.rigidbody.name)
                    {
                        case "foie":
                            foiefixe = false;
                            foie.SetActive(true);
                            break;
                        case "intestin_grelle_retopo":
                            intestinfixe = false;
                            intestin.SetActive(true);
                            break;
                        case "colon_low":
                            colonfixe = false;
                            colon.SetActive(true);
                            break;
                        case "heart":
                            coeurfixe = false;
                            coeur.SetActive(true);
                            break;
                        case "estomac_V2":
                            estomacfixe = false;
                            estomac.SetActive(true);
                            break;
                        case "rein_V2":
                            rein1fixe = false;
                            rein1.SetActive(true);
                            break;
                        case "rein_V2 (1)":
                            rein2fixe = false;
                            rein2.SetActive(true);
                            break;
                        case "poumon_unt":
                            poumousfixe = false;
                            poumous.SetActive(true);
                            break;
                        default: break;
                    }
                }
                else
                {
                    scalpelInHand.SetActive(false);
                    haveScalpel = false;
                    itemInHand.SetActive(true);
                    itemInHand.transform.position = transform.position;
                    handEmpty = true;
                }
            }
            else if (haveMarteau)
            {
                marteauInHAnd.SetActive(false);
                haveMarteau= false;
            }
            
            
        }
    }
}
