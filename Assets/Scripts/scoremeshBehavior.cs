using UnityEngine;
using System.Collections;

public class scoremeshBehavior : MonoBehaviour {

    public int score = 0;
    TextMesh textmesh;
    GameManagerBehavior gmb;

	// Use this for initialization
	void Start () {
	    textmesh = this.gameObject.GetComponent<TextMesh>();
        gmb = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void add(float point)
    {
        if (gmb.state == 1)
        {
            score += (int)(point * 1000.0f);
            textmesh.text = score.ToString();
        }
    }

    public void reset()
    {
        score = 0;
        textmesh.text = score.ToString();
    }
}
