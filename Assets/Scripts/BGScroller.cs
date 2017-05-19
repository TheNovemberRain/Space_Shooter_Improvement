using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
	public float scrollSpeed;

	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 30f);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}
