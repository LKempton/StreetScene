using UnityEngine;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {

    [SerializeField]
	private AudioSource[] audio = new AudioSource[2];

    [SerializeField]
    private AudioClip footstepIndoors;
    [SerializeField]
    private AudioClip footstepOutdoors;
    

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    public void PlayPickup()
    {
        audio[0].Play();
    }

    public void PlayOpen()
    {
        audio[1].Play();
    }

    public void ChangeFootsteps(bool isOutside)
    {
        if (isOutside == true)
        {
            for (int i = 0; i < 2; i++ )
                controller.m_FootstepSounds[i] = footstepOutdoors;
        }
        else if (isOutside == false)
        {
            for (int i = 0; i < 2; i++)
                controller.m_FootstepSounds[i] = footstepIndoors;
        }
    }

    public void KeySound()
    {
        audio[2].Play();
    }
}

