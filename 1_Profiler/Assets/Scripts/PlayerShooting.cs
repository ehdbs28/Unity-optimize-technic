using Unity.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public bool spreadShot = false;

	[Header("General")]
	public Transform gunBarrel;
	public ParticleSystem shotVFX;
	public AudioSource shotAudio;
	public float fireRate = .1f;
	public int spreadAmount = 20;

	[Header("Bullets")]
	public GameObject bulletPrefab;

	float timer;

	void Start()
	{

	}

	void Update()
	{
		timer += Time.deltaTime;

		if (Input.GetButton("Fire1") && timer >= fireRate)
		{
			Vector3 rotation = gunBarrel.rotation.eulerAngles;
			rotation.x = 0f;

			if (spreadShot)
				SpawnBulletSpread(rotation);
			else
				SpawnBullet(rotation);
			

			timer = 0f;

			if (shotVFX)
				shotVFX.Play();

			if (shotAudio)
				shotAudio.Play();
		}
	}

	void SpawnBullet(Vector3 rotation)
	{
		GameObject bullet = Instantiate(bulletPrefab) as GameObject;

		bullet.transform.position = gunBarrel.position;
		bullet.transform.rotation = Quaternion.Euler(rotation);
	}

	void SpawnBulletSpread(Vector3 rotation)
	{
		int max = spreadAmount / 2; // -> 이걸 비트 연산으로 << 1
		int min = -max;

		Vector3 tempRot = rotation;
		for (int x = min; x < max; x++)
		{
			tempRot.x = (rotation.x + 3 * x) % 360;

			for (int y = min; y < max; y++)
			{
				tempRot.y = (rotation.y + 3 * y) % 360;

				// 풀 매니징
				GameObject bullet = Instantiate(bulletPrefab) as GameObject;

				bullet.transform.position = gunBarrel.position;
				bullet.transform.rotation = Quaternion.Euler(tempRot);
			}
		}
	}

}

