using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public AudioClip shootClip;
    AudioSource shootSource;

    public static shoot Shoot;

    void Awake()
    {
        if(shoot.Shoot == null)
        {
            shoot.Shoot = this;
        }
    }

	// Use this for initialization
	void Start () {
        shootSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void PlaySound () {
        shootSource.PlayOneShot(shootClip);
	}
}
