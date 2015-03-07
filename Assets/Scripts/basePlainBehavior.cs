using UnityEngine;
using System.Collections;

public class basePlainBehavior : MonoBehaviour {

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
            Destroy(col.gameObject);
        }
    }
}
