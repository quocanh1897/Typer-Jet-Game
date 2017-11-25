using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallrocket : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
    public GameObject explosion;
    public float speed;
    public float damage;
    private Rigidbody2D rb;
    private GameObject warhead;
    void Start () {
    }
	// Update is called once per frame
	void Update () {
        transform.Translate((target.transform.position - transform.position) * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            if (other.gameObject.GetComponent<tanka>())
            {
                other.gameObject.GetComponent<tanka>().loseheart(damage);
            }
            else if(other.gameObject.GetComponent<tanka_scene2>())
            {
               other.gameObject.GetComponent<tanka_scene2>().lose_heart(damage);
            }
            Destroy(gameObject, 0.01f);
        }
		if (other.gameObject.tag == "shield") {
			Destroy (gameObject, 0.01f);
		}
	}
    void OnDestroy()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(exp, 0.2f);
		SoundController_2.PlaySound_2(soundsGame_2.bomnonhanh);
    }
}
