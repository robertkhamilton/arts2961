using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSound : MonoBehaviour {

	public AudioClip crashSoft;
	public AudioClip crashHard;

	private AudioSource source;
	private float lowPitchRange = .15F;
	private float highPitchRange = 1.75F;
	private float velToVol = .2F;
	private float velocityClipSplit = 10F;


	void Awake () {
		source = GetComponent<AudioSource> ();

	}

	void  OnCollisionEnter (Collision coll) {

		source.pitch = Random.Range (lowPitchRange, highPitchRange);

		float hitVol = coll.relativeVelocity.magnitude * velToVol * 0.1f;

		//source.PlayOneShot (crashSoft, 1F);

		if (coll.relativeVelocity.magnitude < velocityClipSplit) {
			//source.PlayOneShot (crashSoft, 1F);
			source.PlayOneShot (crashSoft, hitVol);
		} else {
			//source.PlayOneShot (crashHard, 1F);
			source.PlayOneShot (crashHard, hitVol);
		}
	}
}
