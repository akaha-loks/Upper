using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    private AudioSource myFX;
    public AudioClip clickFx;

    private void Start()
    {
        myFX = GetComponent<AudioSource>();
    }
    public void ClickSound()
    {
        myFX.PlayOneShot(clickFx);
    }
}