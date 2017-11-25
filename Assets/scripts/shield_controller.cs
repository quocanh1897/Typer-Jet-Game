using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_controller : MonoBehaviour {
    private Vector3 targetPosition;
    public GameObject obj;
    public GameObject target;
    
    // Use this for initialization
    void Start () {
        obj = gameObject;
        targetPosition = target.GetComponent<Transform>().position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(obj.GetComponent<Transform>().position.y - targetPosition.y) < 0.4)
        {
			if (GameObject.FindGameObjectWithTag ("Player").GetComponent<tanka> ()) {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<tanka> ().create_shield ();
			} else if (GameObject.FindGameObjectWithTag ("Player").GetComponent<tanka_scene2> ()) {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<tanka_scene2> ().create_shield ();
			}
            Destroy(obj, 0f);

            //Instantiate(target.GetComponent<tanka>().shield, targetPosition, Quaternion.identity);
            //Destroy(Instantiate(bombExplose, targetPosition, Quaternion.identity), 0.5f);//huy bomb sau 0.5s
        }
    }
   
    //void OnCollsionEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.tag=="Player")
    //    {
    //        other.gameObject.GetComponent<tanka>().create_shield();
    //    }
    //}
}
