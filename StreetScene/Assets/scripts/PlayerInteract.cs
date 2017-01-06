using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

    [SerializeField]
    private Transform castPoint;

    //[SerializeField]
    //private GameObject textDisplay;

    [SerializeField]
    private LayerMask layerMask;

    private DoorScript ds;

    void Update()
    {
        var fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(castPoint.position, fwd, out hit, Mathf.Infinity, layerMask)) ;
        {
            if (hit.collider == null)
            {
                //textDisplay.SetActive(false);
                return;
            }

            else if ((hit.distance <= 2.0) && (hit.collider.gameObject.tag == "LockedDoor"))
            {
                //textDisplay.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ds = hit.collider.gameObject.GetComponentInParent<DoorScript>();

                    ds.OpenDoor();
                   
                }

            }

        }
    }
}
