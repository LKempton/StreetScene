using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StorySphere : MonoBehaviour {

    [SerializeField]
    private string story;

    [SerializeField]
    private bool isEvent = false;

    [SerializeField]
    private FinalLevel fl;

    public string GetStory()
    {
        return story;
    }

    public void EventSphere()
    {
        if (isEvent == true)
        {
            fl.BeginFade(1);
        }
    } 
}
