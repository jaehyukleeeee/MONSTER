using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

	public Slider healthBarSlider;
	public Monster mon;

	// Use this for initialization
	void Start () {
		//mon = gameObject.GetComponent<Monster> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnTriggerStay2D(Collider2D other){
		//if player triggers fire object and health is greater than 0
		if (other.tag == "bullet") 
		{
			healthBarSlider.value -= 0.01f;
			if (other.tag=="bullet" &&healthBarSlider.value==0)
			{
				Debug.Log ("vv");//reduce health
			}
		}


	}


}
