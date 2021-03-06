﻿using UnityEngine;
using System.Collections;

public class GameManagerBehavior : MonoBehaviour {

    TextMesh timeTM;
    TextMesh guideTM;
    TextMesh scoreTM;
    public AudioClip alartSound;
    AudioSource audioSource;
    scoremeshBehavior scmb;

    public int state = 0;

    /*
     * ステート
     * 0:ゲーム開始前
     * 1:ゲーム中
     * 2:ゲーム終了後
     */

	// Use this for initialization
	void Start () {
        timeTM = GameObject.Find("timemesh").GetComponent<TextMesh>();
        guideTM = GameObject.Find("texmesh").GetComponent<TextMesh>();
        scoreTM = GameObject.Find("scoremesh").GetComponent<TextMesh>();
        audioSource = GameObject.Find("soundBox").GetComponent<AudioSource>();
        scmb = GameObject.Find("scoremesh").GetComponent<scoremeshBehavior>();
	}

    public float timer = 0.0f;

	// Update is called once per frame
	void Update () {
        if (state == 1)
        {
            timer += Time.deltaTime;
            timeTM.text = string.Format("{0}sLeft",((int)(60 - timer)).ToString()); 
            if (timer >= 60.0f)
            {
                //タイムオーバー
                this.gameEnd();
            }
        }
	}

    public void gameStart()
    {
        int zero = 0;
        scoreTM.text = zero.ToString();
        scmb.score = 0;

        GameObject[] woods = GameObject.FindGameObjectsWithTag("wood");
        for (int i = 0; i < woods.Length; i++)
        {
            woodBehavior wb = woods[i].GetComponent<woodBehavior>();
            wb.ResetTatami();
        }
        audioSource.PlayOneShot(alartSound);
        state = 1;
    }

    public void gameRestart()
    {
        GameObject[] tatamis = GameObject.FindGameObjectsWithTag("tatami");
        for (int i = 0; i < tatamis.Length; i++)
        {
            Destroy(tatamis[i]);
        }
        GameObject[] woods = GameObject.FindGameObjectsWithTag("wood");
        for (int i = 0; i < woods.Length; i++)
        {
            woodBehavior wb = woods[i].GetComponent<woodBehavior>();
            wb.ResetTatami();
        }
        GameObject.Find("scoremesh").GetComponent<scoremeshBehavior>().reset();
        timer = 0.0f;
        audioSource.PlayOneShot(alartSound);
        state = 1;
    }

    public void gameEnd()
    {
        timer = 0.0f;
        guideTM.text = "Press to Restart";
        timeTM.text = "Your score";
        audioSource.PlayOneShot(alartSound);
        state = 2;
    }

    public void Return()
    {
        timeTM.text = "60sLeft";
        guideTM.text = "Press to Start";
        GameObject[] tatamis = GameObject.FindGameObjectsWithTag("tatami");
        for (int i = 0; i < tatamis.Length; i++)
        {
            Destroy(tatamis[i]);
        }
        state = 0;
    }

    
}
