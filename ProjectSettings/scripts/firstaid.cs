﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstaid : MonoBehaviour {

    // Use this for initialization
	public int where_scene;
    private float health_recover = 20f;
    public ParticleSystem showheart;
    public GameObject oj;
    private Vector3 targetPosition;
    public GameObject target;

    void Start() {
        oj = gameObject;
        targetPosition = target.GetComponent<Transform>().position;
    }
    // Update is called once per frame
    void Update() {
        if (Mathf.Abs(oj.GetComponent<Transform>().position.y - targetPosition.y) < 2)
        {
            if (target.gameObject.GetComponent<tanka>())
            {
                target.gameObject.GetComponent<tanka>().recover(health_recover);
            }
            else if (target.gameObject.GetComponent<tanka_scene2>())
            {
                target.gameObject.GetComponent<tanka_scene2>().recover(health_recover);
            }
            Destroy(gameObject, 0.1f);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        

        //else if (other.gameObject.tag=="Player")
        //{
        //    if (other.gameObject.GetComponent<tanka>())
        //    { other.gameObject.GetComponent<tanka>().recover(health_recover); }
        //    else if(other.gameObject.GetComponent<tanka_scene2>())
        //    {
        //        other.gameObject.GetComponent<tanka_scene2>().recover(health_recover);
        //    }
        //    Destroy(gameObject, 0.1f);
        //}

    }
    void OnDestroy()
    {
		SoundController.PlaySound(soundsGame.heal);
		ParticleSystem heart = Instantiate(showheart, transform.position, Quaternion.identity);
        Destroy(heart, 1f);
    }
}
