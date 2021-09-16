using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class ProcessMicInput : MonoBehaviour
    {
        float maxLoudness = 0.0f;
        float minLoudness = 1.0f;
        float currentMicLoudness;

        public bool mute;
        public float jumpThreshold = 0.9f;

        public GameObject playerObject;
        StarterAssetsInputs myStarterAssetsInputs;

        // Start is called before the first frame update
        void Start()
        {
            myStarterAssetsInputs = playerObject.GetComponent<StarterAssetsInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!mute)
            {
                currentMicLoudness = MicInput.MicLoudness;

                if (currentMicLoudness > maxLoudness)
                {
                    maxLoudness = currentMicLoudness;
                    Debug.Log("current: " + currentMicLoudness.ToString("##.#####") + ", max: " + maxLoudness + ", min: " + minLoudness);
                    playerJump(currentMicLoudness);
                }
                else if (currentMicLoudness < minLoudness)
                {
                    minLoudness = currentMicLoudness;
                }

                //Debug.Log("current: " + currentMicLoudness.ToString("##.#####") + ", max: " + maxLoudness + ", min: " + minLoudness);

                //float db = linearToDecibel(currentMicLoudness)
                //Debug.Log("Volume is " + currentMicLoudness.ToString("##.#####") + ", db = " + db);
            }
        }

        float linearToDecibel(float linValue)
        {
            return 20 * Mathf.Log10(Mathf.Abs(linValue));
        }

        void playerJump(float linValue)
        {
            if (linValue >= jumpThreshold)
            {
                // jump
                Debug.Log("Jump Player, Jump!!!");
                myStarterAssetsInputs.jump = true;

            } else
            {
                myStarterAssetsInputs.jump = false;
            }
        }
    }
}
