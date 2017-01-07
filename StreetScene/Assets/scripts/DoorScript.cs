using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
        print("animation called");
    }
}
