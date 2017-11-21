using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jets_scene2 : MonoBehaviour {

    // Use this for initialization
    public GameObject exeplose;
    public GameObject target;
    public GameObject weapon;
    public GameObject textholder;
    public GameObject rocket;
    public int difficultOfWord;
    public int type_jet; //Bien nay xac dinh loai may bay nao, do minh tu tao, hien tai co 3 loai
    private float moveSpeed;
    private float mana;
    private float point;
    private bool drop_boom;
    private float start_time_drop_boom; //Bien nay su dung doi voi may bay tha boom chum
    private float start_time_fire_rocket; //Bien nay su dung doi voi may bay ban rocket
    void Start () {
        moveSpeed = 2f;	drop_boom = false;
        textholder.GetComponentInChildren<textHolder>().keyOfJet.fontSize = 20;
        start_time_drop_boom = Time.time;
        start_time_fire_rocket = Time.time;
        mana = 5f;
        point = 20f;
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
        if (type_jet == 0) // Tha bomb thuong
        {
            if (Mathf.Abs(transform.position.x-target.GetComponent<Transform>().position.x)<0.5f && !drop_boom)
            {
                Drop_Boom(); drop_boom = true;
            }
        }
        else if(type_jet==1) //Tha bomb chum
        {
            if (Mathf.Abs(transform.position.x - target.GetComponent<Transform>().position.x) <2f)
            {
                Drop_Boom_Cluster();
            }
        }
        else if(type_jet==2) //Tha ten lua
        {
            if ((transform.position.x - target.GetComponent<Transform>().position.x < 10f) && (transform.position.x - target.GetComponent<Transform>().position.x>=0))
            {
                Fire_Rocket();
            }
        }
        InputField attack = InputField.FindObjectOfType<InputField>(); //Kiem tra neu nguoi choi nhap dung tu khoa thi no,huy doi tuong
        if(attack.text==textholder.GetComponentInChildren<textHolder>().keyOfJet.text)
        {
            moveSpeed = 0;
            Destroy(gameObject, 0.1f);
            attack.text = null;
        }
	}
    void Drop_Boom() //Ham tha boom
    {
        Collider2D cld = gameObject.GetComponent<Collider2D>();
        cld.isTrigger = true;
        GameObject Weapon = Instantiate(weapon, transform.position, Quaternion.identity);
    }
    void Drop_Boom_Cluster() //Ham tha boom chum
    {
        if(Time.time>=start_time_drop_boom) //Dieu kien nay lam cho boom chum tha ra cu 0.5s 1 qua
        {
            Drop_Boom();
            start_time_drop_boom = Time.time + 0.5f;
        }
    }
    void OnDestroy() //Ham trong giai doan huy may bay: tinh diem, lay mana,...
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<tanka_scene2>().get_mana(mana);
            GameObject.FindGameObjectWithTag("Player").GetComponent<tanka_scene2>().get_point(point);
        }
        GameObject exp = Instantiate(exeplose, transform.position, Quaternion.identity);
        Destroy(exp, 0.5f);
        Destroy(textholder, 0.01f);
    }
    void Fire_Rocket() //Ham nay dung de tha rocket ra
    {
        Collider2D cld = gameObject.GetComponent<Collider2D>();
        cld.isTrigger = true;
        if (Time.time >= start_time_fire_rocket) //Dieu kien nay de xac dinh cu 1s la se co 1 rocket bay ra
        {
            GameObject Rocket = Instantiate(rocket, transform.position, Quaternion.identity);
            start_time_fire_rocket = Time.time + 1f;
        }
    }
    void OnTriggerEnter2D(Collider2D other) //Ham nay de nhan tinh hieu va cham tu vien dan ban tu galtingun, neu va cham dan thi no may bay
    {
        if(other.gameObject.tag=="smallbullet")
        {
            Destroy(gameObject, 0.1f);
        }
    }
 }
