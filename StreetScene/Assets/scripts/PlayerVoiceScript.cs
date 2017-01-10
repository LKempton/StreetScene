using UnityEngine;
using System.Collections;

public class PlayerVoiceScript : MonoBehaviour {

    [SerializeField]
    private AudioSource[] voiceAudio = new AudioSource[4];
    private bool[] hasPlayed = new bool[4];

    void Start()
    {
        for (int i = 0; i < hasPlayed.Length - 1; i++)
        {
            hasPlayed[i] = false;
        }
    }

    public void PlankVoiceClips(bool hasBar)
    {
        if (hasBar == true && hasPlayed[1] == false)
        {
            voiceAudio[1].Play();
            hasPlayed[1] = true;
        }
        else if (hasBar == false && hasPlayed[0] == false)
        {
            voiceAudio[0].Play();
            hasPlayed[0] = true;
        }
    }

    public void DoorVoiceClips(bool hasKey)
    {
        if (hasKey == true && hasPlayed[3] == false)
        {
            voiceAudio[3].Play();
            hasPlayed[3] = true;
        }
        else if (hasKey == false && hasPlayed[2] == false)
        {
            voiceAudio[2].Play();
            hasPlayed[2] = true;
        }
    }

}
