using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour {

    public AudioClip hitClip;
    AudioSource hitSource;

    public static hit Hit;

    void Awake()
    {
        if (hit.Hit == null)
        {
            hit.Hit = this;
        }
    }

    // Use this for initialization
    void Start () {
        hitSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound()
    {
        hitSource.PlayOneShot(hitClip);
    }
}
