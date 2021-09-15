using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class SimpleFootsteps : MonoBehaviour
    {

        ThirdPersonController myController;
        AudioSource myAudioSource;

        private bool walking = false;
        public bool mute;

        void Awake()
        {
            myController = GetComponent<ThirdPersonController>();
            myAudioSource = GetComponent<AudioSource>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!mute)
            {
                if (myController.Grounded)
                {
                    if (myController.Walking)
                    {
                        // If we're not already walking (locally), start the walking sound, else, let it keep playing...
                        if (!walking)
                        {
                            myAudioSource.Play();
                            walking = true;
                        }
                    }
                    else
                    {
                        myAudioSource.Stop();
                        walking = false;
                    }
                }
            }
        }
    }
}
