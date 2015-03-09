using UnityEngine;
using System.Collections;

public class slicerBehaviour : MonoBehaviour {

    TurboSlice turboSlicer;
    public GameObject tip;
    public GameObject root;
    GameObject soundBox;
    AudioSource audioSource;
    scoremeshBehavior scmb;
    bool gamestarted;
    public GameManagerBehavior gmb;
    //public AudioClip audioClip;

	// Use this for initialization
	void Start () {
        turboSlicer = TurboSlice.instance;
        soundBox = GameObject.Find("soundBox");
        audioSource = soundBox.GetComponent<AudioSource>();
        scmb = GameObject.Find("scoremesh").GetComponent<scoremeshBehavior>();
        //gmb = GameObject.Find("GameManagerBehavior").GetComponent<GameManagerBehavior>();
        StartCoroutine("CollisionReset");
	}

    private IEnumerator CollisionReset()
    {
        // コルーチンの処理
        while (true)
        {
            this.collider.isTrigger = true;
            yield return new WaitForSeconds (0.1f);
        }
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
            if (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.rigidbody.velocity.sqrMagnitude >= 1.2f)
            {
                this.gameObject.collider.isTrigger = true;
                if (col.CompareTag("tatami"))
                {
                    triggerEnter = true;
                    firstHitPoint = this.gameObject.transform.position;


                }
            }
            else
            {
                this.gameObject.collider.isTrigger = false;
            }
        }   
    }

    void OnCollisionExit(Collision col) {
        this.gameObject.collider.isTrigger = true;
    }

    void OnCollisionEnter(Collision col)
    {
        this.gameObject.collider.isTrigger = true;
    }


    void OnTriggerExit(Collider col)
    {
            
                if (col.CompareTag("tatami"))
                {
                    if (triggerEnter)
                    {

                        Vector3 endHitPoint = this.gameObject.transform.position;
                        float headspeed = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.rigidbody.velocity.sqrMagnitude;
                        if (headspeed >= 12.0f)
                        {
                            Vector3[] triangle = new Vector3[3] { firstHitPoint, tip.transform.position, root.transform.position };
                            GameObject[] slicedObject = turboSlicer.splitByTriangle(col.gameObject, triangle, true);
                            for (int i = 0; i < slicedObject.Length; i++)
                            {
                                slicedObject[i].rigidbody.constraints = RigidbodyConstraints.None;
                                slicedObject[i].rigidbody.AddForce((endHitPoint - firstHitPoint) * 5, ForceMode.Impulse);
                            }
                            scmb.add((this.gameObject.transform.position - firstHitPoint).sqrMagnitude);
                            audioSource.Play();
                        }
                    }

                }
        }
    }

