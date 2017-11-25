using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstaid : MonoBehaviour {

    // Use this for initialization
	public int where_scene;
	public float health_recover;
    public ParticleSystem showheart;
    public GameObject oj;
    private Vector3 targetPosition;
	private Vector3 targetPosition2;
    public GameObject target;
	public GameObject target2;
	public GameObject targetconst;
    void Start() {
        oj = gameObject;
		targetPosition = targetconst.GetComponent<Transform> ().position;            
		targetPosition2 = target.GetComponent<Transform> ().position; 
    }
    // Update is called once per frame
    void Update() {
        if (Mathf.Abs(oj.GetComponent<Transform>().position.y - targetPosition.y) < 4)
        {
			//if (target)
				//target.GetComponent<tanka> ().recover (health_recover);
			if (target2)
				GameObject.FindGameObjectWithTag ("Player").GetComponent<tanka_scene2> ().recover (health_recover);
            Destroy(gameObject, 0.1f);
        }

		if (Mathf.Abs(oj.GetComponent<Transform>().position.y - targetPosition2.y) < 4)
		{
			Debug.Log ("reco");
			if (target)
				target.GetComponent<tanka> ().recover (health_recover);
			if (target2)
				GameObject.FindGameObjectWithTag ("Player").GetComponent<tanka> ().recover (health_recover);
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
