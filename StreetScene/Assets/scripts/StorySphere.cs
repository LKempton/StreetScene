using UnityEngine;
using System.Collections;

public class StorySphere : MonoBehaviour {

    [SerializeField]
    private string story;

    public string GetStory()
    {
        return story;
    }
}
