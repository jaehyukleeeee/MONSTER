using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster : MonoBehaviour {

	float speed = 1.0f;

    public int hp = 100;
	public GameObject _char;
    public GameObject Door;
    public GameObject mon;
	public Slider healthBarSlider;
	public GameObject hand;
    Animator animator;
    bool dead = false;
	SpriteRenderer sprReder;

	public Text hp_Text;


    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
		sprReder = mon.GetComponent<SpriteRenderer> ();

    }
	
	// Update is called once per frame
	void Update () {
		hp_Text.text = "Monster HP : "+hp.ToString();
        if (dead == false)
        {
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

		if(hp == 75)
		{
			hand.SetActive (true);
			animator.SetBool("armX", true);
		}

        if(hp == 50)
        {
            speed = 2.0f;
        }

        if(hp <= 0)
        {
            dead = true;
            animator.SetBool("die", true);
            Door.SetActive(true);
            mon.GetComponent<BoxCollider2D>().enabled = false;
        }

	}

	void FixedUpdate(){
		sprReder.color = new Color (255 / 255, 255 / 255, 255 / 255, 255 / 255);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "bullet") {
			hp--;
			healthBarSlider.value -= 1.0f;
			sprReder.color = new Color (255 / 255, 0 / 255, 0 / 255, 255 / 255);
            hit.Hit.PlaySound();
            Debug.Log ("hate");
		}
    }
}
