using UnityEngine;
using System.Collections;

public class textBoxBehavior : MonoBehaviour {

    TextMesh textmesh;

	// Use this for initialization
	void Start () {
        textmesh = this.gameObject.GetComponent<TextMesh>();
        textmesh.text = "Start";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
