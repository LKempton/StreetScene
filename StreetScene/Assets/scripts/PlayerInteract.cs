﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

    [SerializeField]
    private Transform castPoint;

    [SerializeField]
    private GameObject textDisplay;
    [SerializeField]
    private GameObject storyText;

    [SerializeField]
    private LayerMask layerMask;

    private DoorScript ds;
    private CabinetScript cs;
    private PlayerInventory pi;
    [SerializeField]
    private SoundManagerScript sm;
    [SerializeField]
    private PlayerVoiceScript pv;

    void Start()
    {
        pi = gameObject.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        var fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, fwd);

        if (Physics.Raycast(castPoint.position, castPoint.forward, out hit, Mathf.Infinity, layerMask)) 
        {
            if (hit.collider == null)
            {
                print("null hit");
                textDisplay.SetActive(false);
                return;
            }

            else if ((hit.distance <= 2.0) && (hit.collider.gameObject.tag == "LockedDoor"))
            {
                textDisplay.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && pi.GetCrowbar() == true)
                {
                    sm.PlayOpen();
                    ds = hit.collider.gameObject.GetComponentInParent<DoorScript>();

                    ds.OpenDoor();
                }

                else if (Input.GetKeyDown(KeyCode.E) && pi.GetCrowbar() == false && pi.GetKey() > 0)
                {
                    pv.DoorVoiceClips(true);
                }

                else if (Input.GetKeyDown(KeyCode.E) && pi.GetCrowbar() == false)
                {
                    pv.DoorVoiceClips(false);
                }
            }
            else if ((hit.distance <= 2.5) && (hit.collider.gameObject.tag == "LockedCabinet"))
            {
                textDisplay.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    cs = hit.collider.gameObject.GetComponentInParent<CabinetScript>();

                    if (pi.GetKey() > 0)
                    {
                        sm.KeySound();
                        pi.SetKey(false);

                        cs.InsertKey();
                    }
                }
            }

            else if ((hit.distance <= 2.5) && (hit.collider.gameObject.tag == "Axe"))
            {
                print("axe in range");
                textDisplay.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && (cs.GetKeys() <= 0))
                {
                    sm.PlayPickup();
                    Destroy(hit.collider.gameObject);
                    pi.SetAxe(true);
                }
                
            }

            else if ((hit.distance <= 2.5) && (hit.collider.gameObject.tag == "Crowbar"))
            {
                print("bar in range");
                textDisplay.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    sm.PlayPickup();
                    Destroy(hit.collider.gameObject);
                    pi.SetCrowbar(true);
                }
            }

            else if ((hit.distance <= 3.0) && (hit.collider.gameObject.tag == "Plank"))
            {
                //print("plank in range");
                textDisplay.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && pi.GetAxe() == true)
                {
                    sm.PlayOpen();
                    Destroy(hit.collider.gameObject);
                }
                else if (Input.GetKeyDown(KeyCode.E) && pi.GetAxe() == false && pi.GetCrowbar() == false)
                {
                    pv.PlankVoiceClips(false);
                }
                else if (Input.GetKeyDown(KeyCode.E) && pi.GetAxe() == false && pi.GetCrowbar() == true)
                {
                    pv.PlankVoiceClips(true);
                }
            }

            else if ((hit.distance <= 2.5) && (hit.collider.gameObject.tag == "Key"))
            {
                //print("key in range");
                textDisplay.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    sm.PlayPickup();
                    Destroy(hit.collider.gameObject);
                    pi.SetKey(true);
                }
            }

            else if ((hit.distance <= 2.5) && (hit.collider.gameObject.tag == "Story"))
            {
                //print("story in range");
                storyText.GetComponent<Text>().text = hit.collider.gameObject.GetComponent<StorySphere>().GetStory().ToString();
                storyText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<StorySphere>().EventSphere();
                }
            }
            else
            {
                storyText.SetActive(false);
                textDisplay.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Well"))
        {
            print("end level");
            Application.LoadLevel(2);
        }
    }
}
