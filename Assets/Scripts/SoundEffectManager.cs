using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip[] audioClip;

    public AudioSource audioSource;

    public void Effect(int i)
    {
        audioSource.PlayOneShot(audioClip[i]);
    }

}
