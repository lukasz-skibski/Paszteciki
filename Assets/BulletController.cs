using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float ttl = 1.0f;
	public Vector3 vector;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, ttl);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += vector;
	}
}
