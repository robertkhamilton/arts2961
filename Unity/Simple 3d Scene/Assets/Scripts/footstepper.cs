/* Designing Musical Games 2021
 * 
 * Craptastic Footstep trigger script
 * 
 * Will trigger footfall event when colliders attached to feet make contact with Ground
 * 
 * - RigidBody needs to be added to Ground and any other objects that we wish to trigger this way
 * - Collider (FootTracker), GameObject (PlayerArmature), and text name (Left or Right foot) need to be populated in editor
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class footstepper : MonoBehaviour
    {
        public Sounds mySounds;
        public Collider myCollider;
        public string foot;
        public bool mute;

        private float mySpeed;

        public GameObject playerObject;

        ThirdPersonController myThirdPersonController;

        // local sound playback variables
        AudioSource myAudioSource;    
        AudioClip myAudioClip;
        public AudioClip[] myAudioClips;               // Array of AudioClips

        public float volLowRange = 0.7f;
        public float volHighRange = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            myThirdPersonController = playerObject.GetComponent<ThirdPersonController>();

            // get reference to AudioSource
            myAudioSource = gameObject.GetComponent<AudioSource>();

            

            myAudioSource.clip = myAudioClip;
        }

        // Update is called once per frame
        void Update()
        {
            // Read Speed parameter from the ThirdPersonController
            mySpeed = myThirdPersonController.getSpeed();
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("COLLISION!!");
        }

        // If Ground has a RigidBody with IsKinematic == True, this triggers the foot collider
        private void OnTriggerEnter(Collider other)
        {
            // choose one file at random from our array (populated in the Editor Inspector pane)
            myAudioClip = myAudioClips[Random.Range(0, myAudioClips.Length)];

            // Only trigger footsteps if we're moving (speed > 0)
            if (mySpeed > 0)
            {
                Debug.Log("TRIGGER: " + foot);

                // Local footstep sound playback method (in this script; see below)
                PlayFootstep();

                // Footstep sound playback method on aggregate Sounds.cs script
                // mySounds.PlayFootstep();
            }
        }

        // Local footstep sound playback method
        private void PlayFootstep()
        {
            // simple volume randomization within constraints
            float vol = Random.Range(volLowRange, volHighRange);

            myAudioSource.PlayOneShot(myAudioClip, vol);

        }

    }
}
