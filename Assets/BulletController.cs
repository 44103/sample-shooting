using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

  //爆発エフェクトのPrefab
	public GameObject explosionPrefab;

	void Update () {
		transform.Translate (0, 0.2f, 0);

		if (transform.position.y > 5) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		// 爆発エフェクトを生成する
		GameObject explosion = Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		Destroy (coll.gameObject);
		Destroy (gameObject);
		Destroy (explosion, 2.0f);
	}
}
