﻿using UnityEngine;
using System.Collections;

public class slicerBehaviour : MonoBehaviour {

    TurboSlice turboSlicer;
    public GameObject tip;
    public GameObject root;
    GameObject soundBox;
    AudioSource audioSource;
    //public AudioClip audioClip;

	// Use this for initialization
	void Start () {
        turboSlicer = TurboSlice.instance;
        soundBox = GameObject.Find("soundBox");
        audioSource = soundBox.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    bool triggerEnter;
    Vector3 firstHitPoint;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("tatami"))
        {
            triggerEnter = true;
            firstHitPoint = this.gameObject.transform.position;
        }       

    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("tatami"))
        {
            if (triggerEnter)
            {
                print(this.gameObject.rigidbody.velocity.magnitude.ToString());
                    Vector3[] triangle = new Vector3[3] { firstHitPoint, tip.transform.position, root.transform.position };
                    GameObject[] slicedObject = turboSlicer.splitByTriangle(col.gameObject, triangle, true);
                    for (int i = 0; i < slicedObject.Length; i++)
                    {
                        slicedObject[i].rigidbody.constraints = RigidbodyConstraints.None;
                        slicedObject[i].rigidbody.AddForce((this.gameObject.transform.position - firstHitPoint) * 5, ForceMode.Impulse);
                    }
                    audioSource.Play();
                
            }
        }
    }
}