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
    public int type_jet;
    private float moveSpeed;
    private float mana;
    private float point;
    private bool drop_boom;
    private float start_time_drop_boom;
    private float start_time_fire_rocket;
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
        InputField attack = InputField.FindObjectOfType<InputField>();
        if(attack.text==textholder.GetComponentInChildren<textHolder>().keyOfJet.text)
        {
            moveSpeed = 0;
            Destroy(gameObject, 0.1f);
            attack.text = null;
        }
	}
    void Drop_Boom()
    {
        Collider2D cld = gameObject.GetComponent<Collider2D>();
        cld.isTrigger = true;
        GameObject Weapon = Instantiate(weapon, transform.position, Quaternion.identity);
    }
    void Drop_Boom_Cluster()
    {
        if(Time.time>=start_time_drop_boom)
        {
            Drop_Boom();
            start_time_drop_boom = Time.time + 0.5f;
        }
    }
    void OnDestroy()
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
    void Fire_Rocket()
    {
        Collider2D cld = gameObject.GetComponent<Collider2D>();
        cld.isTrigger = true;
        if (Time.time >= start_time_fire_rocket)
        {
            GameObject Rocket = Instantiate(rocket, transform.position, Quaternion.identity);
            start_time_fire_rocket = Time.time + 1f;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="smallbullet")
        {
            Destroy(gameObject, 0.1f);
        }
    }
 }
