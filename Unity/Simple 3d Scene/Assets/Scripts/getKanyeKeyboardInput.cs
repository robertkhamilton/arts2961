using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class getKanyeKeyboardInput : MonoBehaviour
{
    public AudioMixer kanyeMixer;

    public AudioMixerSnapshot lowPassed;
    public AudioMixerSnapshot notLowPassed;

    int escToggle = 0;
    int kanye1Toggle = 0;
    int kanye2Toggle = 0;
    int kanye3Toggle = 0;
    int kanye4Toggle = 0;
    int kanye5Toggle = 0;
    int kanye6Toggle = 0;

    float kanyeOrbY;

    GameObject child1, child2, child3, child4, child5, child6;


    // Start is called before the first frame update
    void Start()
    {
        child1 = this.transform.Find("kanye_sphere_1").gameObject;
        child2 = this.transform.Find("kanye_sphere_2").gameObject;
        child3 = this.transform.Find("kanye_sphere_3").gameObject;
        child4 = this.transform.Find("kanye_sphere_4").gameObject;
        child5 = this.transform.Find("kanye_sphere_5").gameObject;
        child6 = this.transform.Find("kanye_sphere_6").gameObject;

        kanyeOrbY = child1.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Interp In/Out Master group
            print("Escape key was pressed");
            ToggleFilter();

        } else if(Input.GetKeyDown("1"))
        {
            // Interp In/Out Master group
            print("1 key was pressed");

            kanye1Toggle = kanye1Toggle == 0 ? 1 : 0;
            child1.transform.position = new Vector3(child1.transform.position.x, kanyeOrbY - (kanye1Toggle * kanyeOrbY * 0.5f), child1.transform.position.z);
            kanyeMixer.SetFloat("Volume1", kanye1Toggle*-80.0f);

        }
        else if (Input.GetKeyDown("2"))
        {
            // Interp In/Out Master group
            print("2 key was pressed");

            kanye2Toggle = kanye2Toggle == 0 ? 1 : 0;
            child2.transform.position = new Vector3(child2.transform.position.x, kanyeOrbY - (kanye2Toggle * kanyeOrbY * 0.5f), child2.transform.position.z);
            kanyeMixer.SetFloat("Volume2", kanye2Toggle * -80.0f);
        }
        else if (Input.GetKeyDown("3"))
        {
            // Interp In/Out Master group
            print("3 key was pressed");

            kanye3Toggle = kanye3Toggle == 0 ? 1 : 0;
            child3.transform.position = new Vector3(child3.transform.position.x, kanyeOrbY - (kanye3Toggle * kanyeOrbY * 0.5f), child3.transform.position.z);
            kanyeMixer.SetFloat("Volume3", kanye3Toggle * -80.0f);
        }
        else if (Input.GetKeyDown("4"))
        {
            // Interp In/Out Master group
            print("4 key was pressed");

            kanye4Toggle = kanye4Toggle == 0 ? 1 : 0;
            child4.transform.position = new Vector3(child4.transform.position.x, kanyeOrbY - (kanye4Toggle * kanyeOrbY * 0.5f), child4.transform.position.z);
            kanyeMixer.SetFloat("Volume4", kanye4Toggle * -80.0f);
        }
        else if (Input.GetKeyDown("5"))
        {
            // Interp In/Out Master group
            print("5 key was pressed");

            kanye5Toggle = kanye5Toggle == 0 ? 1 : 0;
            child5.transform.position = new Vector3(child5.transform.position.x, kanyeOrbY - (kanye5Toggle * kanyeOrbY * 0.5f), child5.transform.position.z);
            kanyeMixer.SetFloat("Volume5", kanye5Toggle * -80.0f);
        }
        else if (Input.GetKeyDown("6"))
        {
            // Interp In/Out Master group
            print("6 key was pressed");

            kanye6Toggle = kanye6Toggle == 0 ? 1 : 0;
            child6.transform.position = new Vector3(child6.transform.position.x, kanyeOrbY - (kanye6Toggle * kanyeOrbY * 0.5f), child6.transform.position.z);
            kanyeMixer.SetFloat("Volume6", kanye6Toggle * -80.0f);
        }
    }
    

    public void ToggleFilter()
    {
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        escToggle = escToggle == 0 ? 1 : 0;
        Lowpass();
    }

    public void Lowpass()
    {
        if(escToggle == 1)
        {
            lowPassed.TransitionTo(0.1f);
        } else
        {
            notLowPassed.TransitionTo(0.1f);
        }
    }
}
