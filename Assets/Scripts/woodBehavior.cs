using UnityEngine;
using System.Collections;

public class woodBehavior : MonoBehaviour {

    public GameObject tatami;

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

    public void ResetTatami()
    {
        Vector3 respawnPosition = new Vector3(this.transform.position.x,this.transform.position.y + 2.0f,this.transform.position.z);
        Instantiate(tatami,respawnPosition,Quaternion.identity);
    }
}
