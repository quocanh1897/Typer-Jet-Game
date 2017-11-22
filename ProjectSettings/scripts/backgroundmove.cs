using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour {
    public float moveSpeed;
    public float moveRange;
    private Vector3 oldPosition;
    private GameObject bg;

	// Use this for initialization
	void Start () {
        bg = gameObject;
        oldPosition = bg.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        bg.transform.Translate(new Vector3((-1) * Time.deltaTime * moveSpeed, 0, 0));

        if (Vector3.Distance(oldPosition,bg.transform.position)>moveRange)
        {
            bg.transform.position = oldPosition;
        }
	}
}
