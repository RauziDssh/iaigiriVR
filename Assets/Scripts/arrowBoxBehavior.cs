using UnityEngine;
using System.Collections;

public class arrowBoxBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Renderer>().material.color = transblue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public bool handentered = false;
    Color transblue = new Color(0.0f, 0.0f, 1.0f, 0.3f);
    Color transgreen = new Color(0.0f, 1.0f, 0.0f, 0.3f);

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "palm")
        {
            if (handentered == false)
            {
                handentered = true;
                this.gameObject.GetComponent<Renderer>().material.color = transgreen;

            }
        }
    }


    
    void OnTriggerStay(Collider col)
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "palm")
        {
            if (handentered == true)
            {
                this.gameObject.GetComponent<Renderer>().material.color = transblue;
                handentered = false;
            }
        }
    }
}
