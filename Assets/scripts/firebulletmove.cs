using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebulletmove : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
    private float oldposition;
    private float leftposiotion;
    private float rightposition;
    private float speed_turn;
    private float direction;
    private Transform trs;
	void Start () {
        oldposition = target.transform.position.x;
        trs = gameObject.GetComponent<Transform>();
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        leftposiotion = oldposition + 2f;
        rightposition = oldposition - 2f;
        direction = 1;
        speed_turn = 5f;
    }
	// Update is called once per frame
	void Update () {
        oldposition += Time.deltaTime * direction * speed_turn;
        if(oldposition>=leftposiotion)
        {
            direction *= -1;
            oldposition = leftposiotion;
        }
        else if(oldposition<=rightposition)
        {
            direction *= -1;
            oldposition = rightposition;
        }
        transform.position = new Vector3(oldposition, transform.position.y, transform.position.z);
    }
}
