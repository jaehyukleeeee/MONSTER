using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_in : MonoBehaviour {

	public GameObject black;

	SpriteRenderer sprReder;

	int r = 255;
	int g = 255;
	int b = 255;
	int a = 0;

	// Use this for initialization
	void Start () {
		sprReder = black.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		sprReder.color = new Color (r / 255, g / 255, b / 255, a / 255);
	}

	void FixedUpdate(){
		a++;
	}

	public void bc(){
		a = 0;
	}
}
