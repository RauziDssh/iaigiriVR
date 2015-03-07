using UnityEngine;
using System.Collections;

public class consoleBoxBehavior : MonoBehaviour {

    GameObject gameManager;
    GameManagerBehavior gmb;
    TextMesh scoreTM;
    TextMesh guideTM;

	// Use this for initialization
	void Start () {
        scoreTM = GameObject.Find("scoremesh").GetComponent<TextMesh>();
        guideTM = GameObject.Find("texmesh").GetComponent<TextMesh>();
        gmb = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        this.gameObject.renderer.material.color = transred;
	}

    public float timer = 0.0f;
	// Update is called once per frame
	void Update () {
        
	}

    public bool handentered = false;
    Color transred = new Color(1.0f,0.0f,0.0f,0.3f);
    Color transgreen = new Color(0.0f, 1.0f, 0.0f, 0.3f); 

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "palm")
        {
            if (handentered == false)
            {
                handentered = true;
                this.gameObject.renderer.material.color = transgreen;

            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "palm")
        {
            handentered = true;
            timer += Time.deltaTime;
            this.gameObject.renderer.material.color = transgreen;
            if (timer >= 4.0f)
            {
                this.gameObject.renderer.material.color = transred;
                handentered = false;
                timer = 0.0f;
                //処理
                switch (gmb.state)
                {
                    case 0:
                        int zero = 0;
                        scoreTM.text = zero.ToString();
                        gmb.gameStart();
                        break;
                    case 1:
                        gmb.gameRestart();
                        break;
                    case 2:
                        gmb.Return();
                        int hundred = 100;
                        scoreTM.text = hundred.ToString();
                        break;
                }
            }
            else
            {
                switch (gmb.state)
                {
                    case 0:
                        float num = 100.0f - timer * 25.0f;
                        scoreTM.text = ((int)num).ToString();
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "palm")
        {
            if (handentered == true)
            {
                this.gameObject.renderer.material.color = transred;
                handentered = false;
                timer = 0.0f;
                switch (gmb.state)
                {
                    case 0:
                        int hundred = 100;
                        scoreTM.text = hundred.ToString();
                        break;
                }
            }
        }
    }
}
