using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip[] audioClip;

    public AudioSource audioSource;

    public void SoundEfect()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }
}
