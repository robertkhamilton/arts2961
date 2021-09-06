using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class FallDamage : MonoBehaviour
    {
        public float damageThreshold = 3f;
        public float damageMultiplier = 2.85f;

        ThirdPersonController myController;

        float startYPos, endYPos;
        bool firstCall = true;
        bool damaged = false;


        void Awake()
        {
            myController = GetComponent<ThirdPersonController>(); 
        }


        void Update()
        {
            if (!myController.Grounded)
            {
                if (transform.position.y > startYPos)
                {
                    firstCall = true;
                }
                if (firstCall)
                {
                    firstCall = false;
                    damaged = true;
                    startYPos = transform.position.y;
                }
            }
            else
            {
                endYPos = transform.position.y;
                if (damaged && (startYPos - endYPos) > damageThreshold)
                {
                    damaged = false;
                    firstCall = true;

                    float amount = startYPos - endYPos - damageThreshold;
                    float damage = (damageMultiplier == 0f) ? amount : amount * damageMultiplier;
                    myController.ChangeHealth(-Mathf.RoundToInt(damage));
                }
            }
        }
    }

}