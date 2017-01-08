using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    private bool isOpen = false;

    [SerializeField]
    private GameObject controlPanel;

    public void StartLevel()
    {
        Application.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlsPanel()
    {
        if (isOpen == false)
        {
            controlPanel.SetActive(true);
            isOpen = true;
        }
        else if (isOpen == true)
        {
            controlPanel.SetActive(false);
            isOpen = false;
        }
    }
}
