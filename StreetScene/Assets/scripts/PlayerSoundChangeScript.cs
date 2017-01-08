using UnityEngine;
using System.Collections;

public class PlayerSoundChangeScript : MonoBehaviour {

    [SerializeField]
    private SoundManagerScript sm;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Indoors"))
        {
            print("indoors");
            sm.ChangeFootsteps(false);
        }
        else if (col.CompareTag("Outdoors"))
        {
            print("outdoors");
            sm.ChangeFootsteps(true);
        }
    }
}
