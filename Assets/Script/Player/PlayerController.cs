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
    public GameObject coeur, beauCoeur;
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
    //Organes bool in hand
    public bool foieInHandBool = false;
    public bool intestinInHandBool = false;
    public bool colonInHandBool = false;
    public bool coeurInHandBool = false;
    public bool estomacInHandBool = false;
    public bool rein1InHandBool = false;
    public bool rein2InHandBool = false;
    public bool poumousInHandBool = false;

    //Organes clean
    public GameObject foieClean;
    public GameObject intestinClean;
    public GameObject colonClean;
    public GameObject coeurClean;
    public GameObject estomacClean;
    public GameObject rein1Clean;
    public GameObject rein2Clean;
    public GameObject poumousClean;

    //Organes Trigger
    public GameObject foieTrigger;
    public GameObject intestinTrigger;
    public GameObject colonTrigger;
    public GameObject coeurTrigger;
    public GameObject estomacTrigger;
    public GameObject rein1Trigger;
    public GameObject rein2Trigger;
    public GameObject poumousTrigger;

    //Organes fix�s
    public bool foiefixe = true;
    public bool intestinfixe = true;
    public bool colonfixe = true;
    public bool coeurfixe = true;
    public bool estomacfixe = true;
    public bool rein1fixe = true;
    public bool rein2fixe = true;
    public bool poumousfixe = true;

    [SerializeField] int organeChanged = 0;


    // Start is called before the first frame update
    void Start()
    {
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
        poumousTrigger.SetActive(false);
        coeurTrigger.SetActive(false);
        rein1Trigger.SetActive(false);
        rein2Trigger.SetActive(false);
        colonTrigger.SetActive(false);
        foieTrigger.SetActive(false);
        intestinTrigger.SetActive(false);
        estomacTrigger.SetActive(false);
        beauCoeur.SetActive(false);

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


                else if (hitinfo.collider.CompareTag("cleanOrganes"))
                {
                    switch (hitinfo.collider.name)
                    {
                        case "foie":
                            foieTrigger.SetActive(true);
                            foieClean.SetActive(false);
                            foieInHand.SetActive(true);
                            foieInHandBool = true;
                            break;
                        case "intestin_grelle_retopo":
                            intestinTrigger.SetActive(true);
                            intestinClean.SetActive(false);
                            intestinInHand.SetActive(true);
                            intestinInHandBool = true;

                            break;
                        case "colon_low":
                            colonTrigger.SetActive(true);
                            colonClean.SetActive(false);
                            colonInHand.SetActive(true);
                            colonInHandBool = true;

                            break;
                        case "heart":
                            coeurTrigger.SetActive(true);
                            coeurClean.SetActive(false);
                            coeurInHand.SetActive(true);
                            coeurInHandBool = true;

                            break;
                        case "estomac_V2":
                            estomacTrigger.SetActive(true);
                            estomacClean.SetActive(false);
                            estomacInHand.SetActive(true);
                            estomacInHandBool = true;

                            break;
                        case "rein_V2":
                            rein1Trigger.SetActive(true);
                            rein1Clean.SetActive(false);
                            rein1InHand.SetActive(true);
                            rein1InHandBool = true;

                            break;
                        case "rein_V2 (1)":
                            rein2Trigger.SetActive(true);
                            rein2Clean.SetActive(false);
                            rein2InHand.SetActive(true);
                            rein2InHandBool = true;

                            break;
                        case "poumon_unt":
                            poumousTrigger.SetActive(true);
                            poumousClean.SetActive(false);
                            poumousInHand.SetActive(true);
                            poumousInHandBool = true;

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

                /*
                 * 
                 *              REPLACE ORGANES
                 * 
                 */

            else if (poumousInHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (zoneTargeted && hitinfo.collider.CompareTag("poumonTrigger"))
                {
                    poumous.SetActive(true);
                    poumousInHand.SetActive(false);
                    poumousTrigger.SetActive(false);
                    poumousInHandBool = false;
                    handEmpty = true;

                    organeChanged += 1;
                }
                
            }
            else if (foieInHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (hitinfo.collider.CompareTag("foieTrigger"))
                {
                    foie.SetActive(true);
                    foieInHand.SetActive(false);
                    foieTrigger.SetActive(false);
                    foieInHandBool= false;
                    handEmpty = true;

                    organeChanged += 1;
                }
            }
            else if ( rein1InHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (zoneTargeted && hitinfo.collider.CompareTag("rein1Trigger"))
                {
                    rein1.SetActive(true);
                    rein1InHand.SetActive(false);
                    rein1Trigger.SetActive(false);
                    rein1InHandBool= false;
                    handEmpty = true;

                    organeChanged += 1;
                }
            }
            else if (rein2InHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (zoneTargeted && hitinfo.collider.CompareTag("rein2Trigger"))
                {
                    rein2.SetActive(true);
                    rein2InHand.SetActive(false);
                    rein2Trigger.SetActive(false);
                    rein2InHandBool= false;
                    handEmpty = true;

                    organeChanged += 1;
                }
            }
            else if (estomacInHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (zoneTargeted && hitinfo.collider.CompareTag("estomacTrigger"))
                {
                    estomac.SetActive(true);
                    estomacInHand.SetActive(false);
                    estomacTrigger.SetActive(false);
                    estomacInHandBool= false;
                    handEmpty = true;

                    organeChanged += 1;
                }
            }
            else if (intestinInHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (zoneTargeted && hitinfo.collider.CompareTag("intestinTrigger"))
                {
                    intestin.SetActive(true);
                    intestinInHand.SetActive(false);
                    intestinTrigger.SetActive(false);
                    intestinInHandBool= false;
                    handEmpty = true;

                    organeChanged += 1;
                }
            }

            else if (colonInHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (zoneTargeted && hitinfo.collider.CompareTag("colonTrigger"))
                {
                    colon.SetActive(true);
                    colonInHand.SetActive(false);
                    colonTrigger.SetActive(false);
                    colonInHandBool= false;
                    handEmpty = true;

                    organeChanged += 1;
                }
            }
            else if (coeurInHandBool)
            {
                var zoneTargeted = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, Mathf.Infinity, interractableObject);
                if (zoneTargeted && hitinfo.collider.CompareTag("coeurTrigger"))
                {
                    beauCoeur.SetActive(true);
                    coeurInHand.SetActive(false);
                    coeurTrigger.SetActive(false);
                    coeurInHandBool = false;
                    handEmpty = true;

                    organeChanged += 1;
                }
            }

            else
            {
                switch (hitinfo.collider.name)
                {
                    case "foie":
                        foieClean.SetActive(true);
                        foieInHand.SetActive(false);
                        foieInHandBool = false;
                        break;
                    case "intestin_grelle_retopo":
                        intestinClean.SetActive(true);
                        intestinInHand.SetActive(false);
                        intestinInHandBool = false;

                        break;
                    case "colon_low":
                        colonClean.SetActive(true);
                        colonInHand.SetActive(false);
                        colonInHandBool = false;
                        break;
                    case "heart":
                        coeurClean.SetActive(true);
                        coeurInHand.SetActive(false);
                        coeurInHandBool = false;
                        break;
                    case "estomac_V2":
                        estomacClean.SetActive(true);
                        estomacInHand.SetActive(false);
                        estomacInHandBool = false;
                        break;
                    case "rein_V2":
                        rein1Clean.SetActive(true);
                        rein1InHand.SetActive(false);
                        rein1InHandBool = false;
                        break;
                    case "rein_V22":
                        rein2Clean.SetActive(true);
                        rein2InHand.SetActive(false);
                        rein2InHandBool = false;
                        break;
                    case "poumon_unt":
                        poumousClean.SetActive(true);
                        poumousInHand.SetActive(false);
                        poumousInHandBool = false;
                        break;
                    default: break;
                }
                organeInHand = false;

                handEmpty = true;
                foieTrigger.SetActive(false);
                intestinTrigger.SetActive(false);
                colonTrigger.SetActive(false);
                estomacTrigger.SetActive(false);
                rein1Trigger.SetActive(false);
                rein2Trigger.SetActive(false);
                poumousTrigger.SetActive(false);
                coeurTrigger.SetActive(false);
            }

        }
    }
}
