using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

	public float speed = 10.0f;
	bool lr; // 왼쪽 오른쪽
	public VirtualJoystick joystick;
	Character _char;
	// Update is called once per frame

	void Start()
	{
		_char = GameObject.Find ("Character").GetComponent<Character>();
		Debug.Log (_char.gameObject.transform.localScale);
	}

	void Update () {
		//transform.Translate(Vector2
		Move();
	}

	void Move(){



		Vector3 moveVelocity = Vector3.zero;

		Vector3 bp = transform.position;
		bp.y = _char.gameObject.transform.position.y + 0.6f;
		transform.position = bp;

		/*if (joystick.Horizontal () == 0) {
			moveVelocity = 
			}
		}*/

		if (_char.gameObject.transform.localScale.x > 0) {
			lr = true;
			//moveVelocity = Vector3.left;
		} 
		else if (_char.gameObject.transform.localScale.x < 0) {
			lr = false;
			//moveVelocity = Vector3.right;
			//transform.localScale = new Vector3 (-1, 1, 1);
		}


		if (lr == true) {
			moveVelocity = Vector3.left;
		}

		if (lr == false) {
			moveVelocity = Vector3.right;
		}



		//float yMove = _char.transform.localPosition.y + 10;

		transform.position += moveVelocity * speed * Time.deltaTime;
		//this.transform.Translate(new Vector3(0, yMove, 0));
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "mob") {
			Destroy (gameObject);
		}
	}
}
