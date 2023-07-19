using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBehaviour : MonoBehaviour
{
	[Header("Movement")]
	public float speed = 50f;

	void Update()
	{
		Vector3 movement = transform.forward * speed * Time.deltaTime;
		GetComponent<Rigidbody>().MovePosition(transform.position + movement);
	}

	void OnTriggerEnter(Collider theCollider)
	{
		if (theCollider.tag == "Enemy" || theCollider.tag == "Environment")
			RemoveProjectile();
	}

	void RemoveProjectile()
	{
		Destroy(gameObject);
	}
}
