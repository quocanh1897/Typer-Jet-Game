using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallbullet : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public GameObject source_gun; //Bien nay la vi tri dau dan cua vien dan
    public GameObject explose;
    public int type_bullet; //Ham nay xac dinh dan cua doi thuong nao, co 2 doi duong su dung dan la: galtingun va Boss_scene_2
    private Rigidbody2D rb;
    public float damage;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((transform.position - source_gun.GetComponent<Transform>().position) * (-1) * speed, ForceMode2D.Impulse); //Ham nay dung de tao luc cho vien dan bay theo huong cua dau dan (huong cua Player)
         //Bang 0 la dan cua galtingun se bi huy sau 1 luc de tranh tran bo nho, nguoc lai la dan cua Boss_scene_2
		Destroy(gameObject, 1.5f);
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
    void OnTriggerEnter2D(Collider2D other) //Neu nhu la strigger thi day la dan cua galtingun, se tieu diet may bay
    {
        if (other.gameObject.tag == "jet")
        {
            Destroy(gameObject, 0.5f);
        }
    }
    void OnCollisionEnter2D(Collision2D other) //Neu nhu la collision thi day la dan cua Boss_scene_2, se mat mau cua Player
    {
        if (other.gameObject.tag == "Player")
        {
            ////////////////////////////////////////////////nong tieu lien
			//SoundController_2.PlaySound_2(soundsGame_2.bomnonhanh);
			Destroy(gameObject, 0.01f);
            other.gameObject.GetComponent<tanka_scene2>().lose_heart(damage);
        }
	else if(other.gameObject.tag == "shield")
	{
		Destroy(gameObject,0.01f);
	}
    }
}