using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {

	float speed = 3.0f;
	public GameObject _char;
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

		transform.position = Vector3.MoveTowards(transform.position, _char.transform.position, speed * Time.deltaTime);

		if (_char.transform.position.x - transform.position.x < 0)
		{

			transform.localScale = new Vector3(1, 1, 1);

		}
		else if (_char.transform.position.x - transform.position.x > 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);

		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "char") {
			a = 255;
			Debug.Log ("hate");
		}
	}

	public void bc(){
		a = 0;
	}
}
