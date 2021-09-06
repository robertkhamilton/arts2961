using System.Collections;
using UnityEngine;

public class ThrowObject : MonoBehaviour {

	public GameObject projectile;
	public AudioClip shootSound;

	private float throwSpeed = 2000f;
	private AudioSource source;

	private float volLowRange = 0.5f;
	private float volHighRange = 1.0f;

	void Awake () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.GetButtonDown ("Fire1")) {
		
		//if(Mouse.current.leftButton.isPressed)
		if ( Input.GetMouseButtonDown(0) )
		{
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot (shootSound, vol);

			GameObject throwThis = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
			throwThis.GetComponent<Rigidbody>().AddRelativeForce (new Vector3(0,0,throwSpeed));
		}

	}
}
