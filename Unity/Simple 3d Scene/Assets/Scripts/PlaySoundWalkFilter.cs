using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

//
public class PlaySoundWalkFilter : MonoBehaviour
{

    AudioSource myAudioSource;

    public AudioMixer cherMixer;

    public GameObject playerObject;

    public float maximumVolume = 1.0f;
    public float minimumVolume = 0.0f;
    public float fadeDuration = 1.0f;

    public GameObject myPath;

    BoxCollider myBoxCollider;
    Vector3[] myBoxVertices;

    float startDistance, endDistance, normalizedStartDistance, normalizedEndDistance;

    // Start is called before the first frame update
    void Start()
    {
        // get reference to AudioSource
        myAudioSource = gameObject.GetComponent<AudioSource>();

        // get reference to Box Collider on this path        
        myBoxVertices = GetColliderVertexPositions(myPath);

        Debug.Log(myBoxVertices[0]);
        Debug.Log(myBoxVertices[1]);
        Debug.Log(myBoxVertices[2]);
        Debug.Log(myBoxVertices[3]);
        Debug.Log(myBoxVertices[4]);
        Debug.Log(myBoxVertices[5]);
        Debug.Log(myBoxVertices[6]);
        Debug.Log(myBoxVertices[7]);
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

            // just check position of 2 corners for now (not fancy)
            startDistance = Vector3.Distance(myBoxVertices[0], playerObject.transform.position);
            endDistance = Vector3.Distance(myBoxVertices[1], playerObject.transform.position);

            // ~ 5.0 - 30.0 range
            Debug.Log("start: " + startDistance + ", end: " + endDistance);

            normalizedStartDistance = Map(startDistance, 4.9f, 31.0f, 0.0f, 1.0f);
            normalizedEndDistance = Map(endDistance, 4.9f, 31.0f, 0.0f, 1.0f);

            Debug.Log("start: " + normalizedStartDistance + ", end: " + normalizedEndDistance);

            cherMixer.SetFloat("lowPassCutoff", normalizedStartDistance * 5000.0f);
        }
    }

    void walkFadeIn()
    {
        StartCoroutine(FadeAudioSource.StartFade(myAudioSource, fadeDuration, maximumVolume));
    }

    void walkFadeOut()
    {
        StartCoroutine(FadeAudioSource.StartFade(myAudioSource, fadeDuration, minimumVolume));
    }

    // https://gamedev.stackexchange.com/questions/128833/how-can-i-get-a-box-colliders-corners-vertices-positions
    public Vector3[] GetColliderVertexPositions(GameObject obj)
    {
        BoxCollider b = obj.GetComponent<BoxCollider>(); //retrieves the Box Collider of the GameObject called obj
        Vector3[] vertices = new Vector3[8];
        vertices[0] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f);
        vertices[1] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f);
        vertices[2] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f);
        vertices[3] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f);
        vertices[4] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f);
        vertices[5] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f);
        vertices[6] = obj.transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f);
        vertices[7] = obj.transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f);

        return vertices;
    }

    public float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
