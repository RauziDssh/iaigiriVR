using UnityEngine;
using System.Collections;

public class woodBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("tatami"))
        {
            col.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
