using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour { 
	public GameObject Character;  //A라는 GameObject변수 선언
	Transform AT; 
	void Start () 
	{ 
		AT=Character.transform; 
	} 
	void LateUpdate () { 
		transform.position = new Vector3 (AT.position.x,AT.position.y,transform.position.z); 
	} 
} 