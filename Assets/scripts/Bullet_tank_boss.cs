using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_tank_boss : MonoBehaviour
{

    // Use this for initialization
    public Transform []target; //Tap hop diem de vien dan bay theo, cai nay do minh tu tao
    public GameObject explosion; 
    public float damage;
    public float speed;
    private int current; //Xac dinh xem vien dan da bay den diem nao cua quy dao
    void Start()
    {
        // Day la vien dan lua duoc ban ra tu nong dai bac cua Boss_scene_2, no se bay theo quy dao cua tap hop diem.
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position != target[current].position) //Kiem tra neu chua di toi diem tiep theo trong quy dao
        {
            transform.rotation = Quaternion.Euler(target[current].position.x, target[current].position.y, target[current].position.z); //Xoay vien dan theo huong cua diem tiep theo
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime); //Sau do di chuyen den diem tiep theo trong quy dao
            gameObject.GetComponent<Rigidbody2D>().MovePosition(pos);// Di chuyen luon thanh phan vat ly cua no di theo
        }
        else current = (current + 1) % target.Length; //Neu da di chuyen roi thi tang current len
    }
    void OnTriggerEnter2D(Collider2D other) //Khi va cham voi Player thi mat mau Player
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
