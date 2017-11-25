using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rocket : MonoBehaviour
{

    // Use this for initialization
    public GameObject explose;
    public float speed;
    private GameObject target;
    private Transform trs_taget;
    private Transform warhead;
    private Rigidbody2D rb;
    private bool fire;
    private float damage;
    void Start()
    {
        damage = 10f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        fire = false;
        foreach (Transform child in transform)
        {
            if (child.tag == "warhead")
            { warhead = child; break; }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!fire)
        {
            rb.AddForce((warhead.position - transform.position) * speed, ForceMode2D.Impulse);
            fire = true;
        }
    }
    void set_targer_at_fire()
    {
        GameObject[] jet = GameObject.FindGameObjectsWithTag("jet");
        foreach(GameObject gobj in jet)
        {
            Collider2D cld = gobj.GetComponent<Collider2D>();
            cld.isTrigger = false;
        }
    }
    void set_target_after_fire()
    {
        GameObject[] jet = GameObject.FindGameObjectsWithTag("jet");
        foreach (GameObject gobj in jet)
        {
            Collider2D cld = gobj.GetComponent<Collider2D>();
            cld.isTrigger = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        InputField attack = InputField.FindObjectOfType<InputField>();
        attack.text = null;
        Destroy(gameObject, 0.01f);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        InputField attack = InputField.FindObjectOfType<InputField>();
        attack.text = null;
        if(other.gameObject.tag=="jet")
        {
            Destroy(other.gameObject, 0.4f);
        }
        else if(other.gameObject.tag=="bossscene")
        {
            other.gameObject.GetComponent<bossscene1>().loseheart(damage);
        }
        Destroy(gameObject, 0.01f);
    }
    void OnDestroy()
    {
		//SoundController.PlaySound(soundsGame.bomno);
        GameObject gobj = Instantiate(explose, transform.position, Quaternion.identity);
        Destroy(gobj, 1f);
    }
}
