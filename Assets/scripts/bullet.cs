using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Use this for initialization
    public GameObject explose;
    private float speed;
    private float damage=10f;
    void Start()
    {
        speed = 10f;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

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
        GameObject exp = Instantiate(explose, transform.position, Quaternion.identity);
        Destroy(exp, 0.4f);
    }
}
