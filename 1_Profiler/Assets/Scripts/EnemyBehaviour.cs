using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBehaviour : MonoBehaviour
{
	[Header("Movement")]
	public float speed = 2f;

	[Header("Life Settings")]
	public float enemyHealth = 1f;

	[Header("Bullet Impact")]
	public GameObject bulletHitPrefab;

	void Update()
	{
		if(!Settings.IsPlayerDead())
			transform.LookAt(Settings.PlayerPosition);
		Vector3 movement = transform.forward * speed * Time.deltaTime;
		this.GetComponent<Rigidbody>().MovePosition(transform.position + movement);
	}

	//Enemy Collision
	void OnTriggerEnter(Collider theCollider)
	{
		if (theCollider.tag != "Bullet")
			return;

		enemyHealth--;

		if(enemyHealth <= 0)
		{
			Instantiate(bulletHitPrefab, this.transform);
			Destroy(gameObject,0.1f);
		}
	}

}
