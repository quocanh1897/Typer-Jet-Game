using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallrocket : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
    public GameObject explosion;
    public float speed;
    private float damage;
    private Rigidbody2D rb;
    private GameObject warhead;
    void Start () {
        damage = 10f;
        
	}
	// Update is called once per frame
	void Update () {
        transform.Translate((target.transform.position - transform.position) * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<tanka>().loseheart(damage);
            Destroy(gameObject, 0.01f);
        }
    }
    void OnDestroy()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 0.2f);
    }
}
