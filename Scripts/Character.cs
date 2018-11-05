using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    public VirtualJoystick joystick;
	public GameObject axe;
	public GameObject axedrop;
	public GameObject bullet;
    public Monster Monster;
	public bool IsShoot = false;
	float shootDelay;
	float shootTimer;
	Animator animator;
    int speed = 5;
	bool equipAxe = false;
	bool ab= false;


	void Start(){
		animator = gameObject.GetComponent<Animator> ();
	}

	void Update(){
		Equip ();
	}

	void FixedUpdate () {
		Move ();

		if (IsShoot == true) {
			/*GameObject bullet = */Instantiate (bullet, transform.position, Quaternion.identity); //as GameObject;
            
			//bullet.transform.position.x ;
			IsShoot = false;
		}


    }

	void Move(){
		Vector3 moveVelocity = Vector3.zero;

		float yMove = joystick.Vertical() * speed * Time.deltaTime;

		if (joystick.Horizontal () == 0) {
			animator.SetBool ("isMoving", true);
			if (equipAxe == true) {
				animator.SetBool ("isaxeMoving", true);
			}
		}

		else if (joystick.Horizontal() < 0) {
			moveVelocity = Vector3.left;
			transform.localScale = new Vector3 (1, 1, 1);
			animator.SetBool ("isMoving", false);
			if (equipAxe == true) {
				animator.SetBool ("isaxeMoving", false);
			}
		} 
		else if (joystick.Horizontal() > 0) {
			moveVelocity = Vector3.right;
			transform.localScale = new Vector3 (-1, 1, 1);
			animator.SetBool ("isMoving", false);
			if (equipAxe == true) {
				animator.SetBool ("isaxeMoving", false);
			}
		}



		transform.position += moveVelocity * speed * Time.deltaTime;

		this.transform.Translate(new Vector3(0, yMove, 0));
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "door")
        {
            SceneManager.LoadScene("end");
            //DontDestroyOnLoad(transform.gameObject);
            //Destroy(gameObject);

            //this.transform.Translate(new Vector3(-7.1f, 0, 0));

        }
        if (coll.gameObject.tag == "mob")
        {
			animator.SetBool("die", true);
            SceneManager.LoadScene("gameover");
            

        }
		//if (coll.gameObject.tag == "hand") {
		//	animator.SetBool("die", true);
		//	SceneManager.LoadScene("gameover");
		//

		//}
    }

	public void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "axe" && ab == true) {
			Debug.Log ("good");
			Destroy (coll.gameObject);
			equipAxe = true;
			ab = false;
		} 
	}

	public void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "axe") {
			ab = false;
			Debug.Log ("bad");
		}
	}

	public void de() // a
	{
        if(joystick.Horizontal() == 0 && equipAxe == true)
        {
            IsShoot = true;
            shoot.Shoot.PlaySound();
        }
		

		if (equipAxe == false) {
			ab = true;

			Debug.Log ("true");
		}
	}

	public void be() // b
	{
		if (equipAxe == true) {
			ab = false;
			equipAxe = false;
			GameObject go = Instantiate (axe) as GameObject;
			go.transform.position = axedrop.transform.position;
			Debug.Log ("false");
		}

	}
		
	void Equip(){
		if (equipAxe == true) {
			animator.SetBool ("pick_up_axe", true);

		}

		if (equipAxe == false) {
			animator.SetBool ("pick_up_axe", false);

		}

	}
}