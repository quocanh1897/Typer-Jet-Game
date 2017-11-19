using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_tank_boss : MonoBehaviour
{

    // Use this for initialization
    public Transform []target;
    public GameObject explosion;
    public float damage;
    public float speed;
    private int current;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position != target[current].position)
        {
            transform.rotation = Quaternion.Euler(target[current].position.x, target[current].position.y, target[current].position.z);
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            gameObject.GetComponent<Rigidbody2D>().MovePosition(pos);
            
        }
        else current = (current + 1) % target.Length;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<tanka_scene2>().lose_heart(damage);
            Destroy(gameObject, 0.01f);
        }
    }
    void OnDestroy()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 0.2f);
    }
}
