using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class Boundary{
//	public float xMax, xMin, zMax, zMin;
//}
[System.Serializable]
public struct Boundary{
	public float xMax, xMin, zMax, zMin;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public float fireRate;
	private float nextFire;

	private Rigidbody rb;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	private AudioSource audioSource;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		//Moving

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax) ,
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);	//Restricted area

		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);	//Rotation
	}

}
