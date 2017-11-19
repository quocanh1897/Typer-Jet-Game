using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallbullet : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public GameObject source_gun;
    public GameObject explose;
    public int type_bullet;
    private Rigidbody2D rb;
    public float damage;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((transform.position - source_gun.GetComponent<Transform>().position) * (-1) * speed, ForceMode2D.Impulse);
        if (type_bullet == 0)
        { Destroy(gameObject, 1.5f); }
        speed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnDestroy()
    {
        GameObject exp = Instantiate(explose, transform.position, Quaternion.identity);
        Destroy(exp, 0.2f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "jet")
        {
            Destroy(gameObject, 0.5f);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.01f);
            other.gameObject.GetComponent<tanka_scene2>().lose_heart(damage);
        }
    }
}