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

        // Start is called before the first frame update
        void Start()
        {
            myThirdPersonController = playerObject.GetComponent<ThirdPersonController>();
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
            // Only trigger footsteps if we're moving (speed > 0)
            if (mySpeed > 0)
            {
                Debug.Log("TRIGGER: " + foot);
                mySounds.PlayFootstep();
            }
        }
    }
}
