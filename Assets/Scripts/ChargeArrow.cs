using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeArrow : State
{
    public LaunchArrow launchArrow;
    public CreateArrow createArrow;
    public GameObject arrowToBeCharged;
    public float damage;
    public Camera fpsCam;
    public LineRenderer stringLine;
    public GameObject bowNString;
    public Transform arrowSpawn;
    public FireScript fireScript;
    public Vector3 stringLineStartPos;
    public GameObject arrow;

    private void Awake()
    {
        stringLineStartPos = stringLine.GetPosition(1);
        
    }
    public override State RunCurrentState()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            damage = fireScript.damage;
            
            Vector3 force = arrowSpawn.TransformDirection(Vector3.forward * damage);
            arrowToBeCharged.GetComponent<Rigidbody>().isKinematic = false;
            arrowToBeCharged.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            damage = 1;

            launchArrow.arrowToBeLaunched = arrowToBeCharged;
            return launchArrow;
        }

        if(arrowToBeCharged == null)
        {
            arrow = Instantiate(arrow) as GameObject;
            arrowToBeCharged = arrow;
            return this;
        }

        else
        {
            if(Input.GetButton("Fire1") || Input.GetButtonDown("Fire1"))
            {
                ChargeShot();              
            }

            return this;
        }
    }

    private void ChargeShot()
    {




        if (fpsCam.fieldOfView >= 65)
        {
            fpsCam.fieldOfView -= Time.deltaTime * 20;
        }

        if (stringLine.GetPosition(1).x >= -0.4)
        {
            stringLine.SetPosition(1, new Vector3((stringLine.GetPosition(1).x - 
                Time.deltaTime), stringLineStartPos.y, stringLineStartPos.z));
        }

        arrowToBeCharged.transform.position = arrowSpawn.position;
        arrowToBeCharged.transform.rotation = arrowSpawn.rotation;
        if (arrowSpawn.localPosition.x >= 2.1)
        {
            arrowSpawn.Translate(Vector3.back * Time.deltaTime * 2);
        }
        if (bowNString.transform.localPosition.x >= -1.5f)
        {
            bowNString.transform.Translate(Vector3.left * Time.deltaTime * 2);
        }
    }
}