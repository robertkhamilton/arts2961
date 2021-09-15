using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class PlaySoundWalk : MonoBehaviour
{

    AudioSource myAudioSource;

    public float maximumVolume = 1.0f;
    public float minimumVolume = 0.0f;
    public float fadeDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // get reference to AudioSource
        myAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            walkFadeIn();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            walkFadeOut();
        }
    }

    void OnTriggerStay(Collider other)
    {
        //if player is on a gameObject
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Still walking on " + gameObject.name);
        }
    }

    void walkFadeIn()
    {
        //StartCoroutine(FadeAudioSource.StartFade(AudioSource audioSource, float duration, float targetVolume));
        StartCoroutine(FadeAudioSource.StartFade(myAudioSource, fadeDuration, maximumVolume));


    }

    void walkFadeOut()
    {
        StartCoroutine(FadeAudioSource.StartFade(myAudioSource, fadeDuration, minimumVolume));
    }
}

 
// ROB'S TERRIBLE CROSS-FADER
/*
public class PlaySoundWalk : MonoBehaviour
{

    AudioSource myAudioSource;
    float currentVolume = 0.0f;
    float maximumVolume = 1.0f;
    float minimumVolume = 0.0f;

    bool fadeIn = false;
    bool fadeOut = false;

    // starting value for the Lerp
    static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // get reference to AudioSource
        myAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn)
        {
            walkFadeIn();
        } 
        else if(fadeOut)
        {
            walkFadeOut();
        }

        myAudioSource.volume = currentVolume;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            fadeIn = true;
            Debug.Log("Started walking on " + gameObject.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeOut = true;
            Debug.Log("Stopped walking on " + gameObject.name);
        }
    }

    void OnTriggerStay(Collider other)
    {
        //if player is on a gameObject
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Still walking on " + gameObject.name);
        }
    }

    void walkFadeIn()
    {
        // Interpolate volume of AudioSource from currentVolume => 1.0
        currentVolume = Mathf.Lerp(minimumVolume, maximumVolume, t);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        if (t >= 1.0f)
        {
            fadeIn = false;
            t = 0.0f;
        }
    }

    void walkFadeOut()
    {
        // Interpolate volume of AudioSource from currentVolume => 0.0
        currentVolume = Mathf.Lerp(maximumVolume, minimumVolume, t); 

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        if (t >= 1.0f)
        {
            fadeOut = false;
            t = 0.0f;
        }
    }
}

*/