using UnityEngine;
using System.Collections;

public class CabinetScript : MonoBehaviour {

    private Animator anim;

    private int keysLeft = 5;

    [SerializeField]
    private GameObject[] keySlots = new GameObject[5];

    private int index = 0;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OpenCabinet()
    {
        print("Cabinet opening");
        anim.SetTrigger("OpenCabinet");
    }

    public void InsertKey()
    {
        print("Key used");
        FillSlots();

        keysLeft--;

        if (keysLeft <= 0)
        {
            OpenCabinet();
        }
    }

    void FillSlots()
    {
        keySlots[index].SetActive(true);

        index++;
    }

    public int GetKeys()
    {
        return keysLeft;
    }

}
