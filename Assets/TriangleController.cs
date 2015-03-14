using UnityEngine;
using System.Collections;

public class TriangleController : MonoBehaviour {

	public GameObject bulletPrefab;

	public Vector3 rotationVector;

	private float lastShot;
	private float bulletSpeed = 0.1f;
	private float shootDelay = 0.1f;

	private Vector3 bulletSpawnPoint1;
	private Vector3 bulletSpawnPoint2;
	private Vector3 bulletSpawnPoint3;
	private Vector3 pivot;

	// Use this for initialization
	void Start () {
		lastShot = Time.time;
		bulletSpawnPoint1 = new Vector3 (renderer.bounds.min.x, renderer.bounds.min.y, 0);
		bulletSpawnPoint2 = new Vector3 (renderer.bounds.max.x, renderer.bounds.min.y, 0);
		bulletSpawnPoint3 = new Vector3 (renderer.bounds.center.x, renderer.bounds.max.y, 0);
		pivot = new Vector3 (renderer.bounds.center.x,
		                             renderer.bounds.min.y + ((renderer.bounds.max.y - renderer.bounds.min.y) * 0.33333f),
		                             0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float lerp = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
		GetComponent<SpriteRenderer> ().color = Color.Lerp(Color.red, Color.yellow, lerp);

		transform.Rotate (rotationVector);
		if (Time.time - lastShot > shootDelay) {
			lastShot = Time.time;
			spawnBullets();
		}
	}

	private void spawnBullets() {
		spawnBullet (bulletSpawnPoint1, Quaternion.Euler (0, 0, 120));
		spawnBullet (bulletSpawnPoint2, Quaternion.Euler (0, 0, 240));
		spawnBullet (bulletSpawnPoint3, Quaternion.Euler (0, 0, 0));
	}

	private void spawnBullet(Vector3 bulletSpawnPoint, Quaternion rotation) {
		Vector3 pos = (transform.rotation * (bulletSpawnPoint - pivot)) + pivot;
		GameObject bullet = Instantiate (bulletPrefab, pos, transform.rotation * Quaternion.identity) as GameObject;
		bullet.GetComponent<BulletController> ().vector = rotation * transform.up * bulletSpeed;
	}
}
