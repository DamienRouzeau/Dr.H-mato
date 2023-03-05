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
    bool organeInHand = false;

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

    //Organes clean
    public GameObject foieClean;
    public GameObject intestinClean;
    public GameObject colonClean;
    public GameObject coeurClean;
    public GameObject estomacClean;
    public GameObject rein1Clean;
    public GameObject rein2Clean;
    public GameObject poumousClean;

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
        Cursor.lockState = CursorLockMode.Locked;
        scalpelInHand.SetActive(false);
        marteauInHAnd.SetActive(false);
        coeurInHand.SetActive(false);
        poumousInHand.SetActive(false);
        rein1InHand.SetActive(false);
        rein2InHand.SetActive(false);
        colonInHand.SetActive(false);
        foieInHand.SetActive(false);
        intestinInHand.SetActive(false);
        estomacInHand.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Loose()
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


                else if (hitinfo.collider.CompareTag("cleanOrganes"))
                {
                    switch (hitinfo.collider.name)
                    {
                        case "foie":
                            print("test");
                            foieClean.SetActive(false);
                            foieInHand.SetActive(true);
                            break;
                        case "intestin_grelle_retopo":
                            intestinClean.SetActive(false);
                            intestinInHand.SetActive(true);
                            break;
                        case "colon_low":
                            colonClean.SetActive(false);
                            colonInHand.SetActive(true);
                            break;
                        case "heart":
                            coeurClean.SetActive(false);
                            coeurInHand.SetActive(true);
                            break;
                        case "estomac_V2":
                            estomacClean.SetActive(false);
                            estomacInHand.SetActive(true);
                            break;
                        case "rein_V2":
                            rein1Clean.SetActive(false);
                            rein1InHand.SetActive(true);
                            break;
                        case "rein_V2 (1)":
                            rein2Clean.SetActive(false);
                            rein2InHand.SetActive(true);
                            break;
                        case "poumon_unt":
                            poumousClean.SetActive(false);
                            poumousInHand.SetActive(true);
                            break;
                        default: break;
                    }
                    itemInHand = hitinfo.collider.gameObject;
                    organeInHand = true;
                }
                else if (hitinfo.collider.CompareTag("organe"))
                {
                    switch (hitinfo.rigidbody.name)
                    {
                        case "foie":
                            foie.SetActive(false);
                            break;
                        case "intestin_grelle_retopo":
                            intestin.SetActive(false);
                            break;
                        case "colon_low":
                            colon.SetActive(false);
                            break;
                        case "heart":
                            coeur.SetActive(false);
                            break;
                        case "estomac_V2":
                            estomac.SetActive(false);
                            break;
                        case "rein_V2":
                            rein1.SetActive(false);
                            break;
                        case "rein_V2 (1)":
                            rein2.SetActive(false);
                            break;
                        case "poumon_unt":
                            poumous.SetActive(false);
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
                var organeTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (organeTargeted && hitinfo.collider.CompareTag("organe"))
                {
                    hitinfo.transform.gameObject.SetActive(false);
                    /*switch (hitinfo.rigidbody.name)
                    {
                        case "foie":
                            foiefixe = false;
                            //foie.SetActive(true);
                            break;
                        case "intestin_grelle_retopo":
                            intestinfixe = false;
                            //intestin.SetActive(true);
                            break;
                        case "colon_low":
                            colonfixe = false;
                            //colon.SetActive(true);
                            break;
                        case "heart":
                            coeurfixe = false;
                            //coeur.SetActive(true);
                            break;
                        case "estomac_V2":
                            estomacfixe = false;
                            //estomac.SetActive(true);
                            break;
                        case "rein_V2":
                            rein1fixe = false;
                            //rein1.SetActive(true);
                            break;
                        case "rein_V2 (1)":
                            rein2fixe = false;
                            //rein2.SetActive(true);
                            break;
                        case "poumon_unt":
                            poumousfixe = false;
                            //poumous.SetActive(true);
                            break;
                        default: break;
                    }*/
                }
                else
                {
                    scalpelInHand.SetActive(false);
                    haveScalpel = false;
                    itemInHand.SetActive(true);
                    //itemInHand.transform.position = transform.position;
                    handEmpty = true;
                }
            }
            else if (haveMarteau)
            {
                marteauInHAnd.SetActive(false);
                haveMarteau= false;
            }
            else
            {
                switch (hitinfo.collider.name)
                {
                    case "foie":
                        foieClean.SetActive(true);
                        foieInHand.SetActive(false);
                        break;
                    case "intestin_grelle_retopo":
                        intestinClean.SetActive(true);
                        intestinInHand.SetActive(false);
                        break;
                    case "colon_low":
                        colonClean.SetActive(true);
                        colonInHand.SetActive(false);
                        break;
                    case "heart":
                        coeurClean.SetActive(true);
                        coeurInHand.SetActive(false);
                        break;
                    case "estomac_V2":
                        estomacClean.SetActive(true);
                        estomacInHand.SetActive(false);
                        break;
                    case "rein_V2":
                        rein1Clean.SetActive(true);
                        rein1InHand.SetActive(false);
                        break;
                    case "rein_V2 (1)":
                        rein2Clean.SetActive(true);
                        rein2InHand.SetActive(false);
                        break;
                    case "poumon_unt":
                        poumousClean.SetActive(true);
                        poumousInHand.SetActive(false);
                        break;
                    default: break;
                }
                organeInHand = false;

                handEmpty = true;
            }
        }
    }
}
