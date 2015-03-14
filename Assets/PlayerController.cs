using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
	}

	void OnMouseDrag() {
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		rigidbody2D.MovePosition(curPosition);
	}
}
