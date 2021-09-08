using System.Collections;
using UnityEngine;

public class ThrowObject : MonoBehaviour {

	public GameObject projectile;
	public AudioClip shootSound;

	public float throwSpeed = 2000f;
	private AudioSource source;

	public float volLowRange = 0.5f;
	public float volHighRange = 1.0f;

	void Awake () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetMouseButtonDown(0) )
		{
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot (shootSound, vol);

			GameObject throwThis = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
			throwThis.GetComponent<Rigidbody>().AddRelativeForce (new Vector3(0,0,throwSpeed));
		}

	}
}
