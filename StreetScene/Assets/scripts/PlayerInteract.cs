using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

    [SerializeField]
    private Transform castPoint;

    [SerializeField]
    private GameObject textDisplay;

    [SerializeField]
    private LayerMask layerMask;

    private DoorScript ds;
    private CabinetScript cs;
    private PlayerInventory pi;

    void Start()
    {
        pi = gameObject.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        var fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(castPoint.position, fwd, out hit, Mathf.Infinity, layerMask)) 
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
                    ds = hit.collider.gameObject.GetComponentInParent<DoorScript>();

                    ds.OpenDoor();
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
                    Destroy(hit.collider.gameObject);
                    pi.SetCrowbar(true);
                }
            }

            else if ((hit.distance <= 3.0) && (hit.collider.gameObject.tag == "Plank"))
            {
                print("plank in range");
                textDisplay.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && pi.GetAxe() == true)
                {
                    Destroy(hit.collider.gameObject);
                }
            }

            else
            {
                textDisplay.SetActive(false);
            }
        }
    }
}
