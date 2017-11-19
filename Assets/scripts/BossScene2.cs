using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScene2 : MonoBehaviour {

    // Use this for initialization
    public float blood_boss;
    public float dagamed;
    public int difficultOfWord;
    public float point_one;
    public float speed;
    public GameObject textholder;
    public GameObject explosion;
    public GameObject bullet;
    public GameObject shooting_effect;
    public GameObject small_bullet;
    public GameObject target;
    private string key;
    private float start_time_bullet;
    private float start_time_smallbullet;
    private bool stop_boss;
    private bool attack;
	void Start () {
        key = textholder.GetComponent<textHolder>().textUI.text;
        start_time_bullet = Time.time;
        start_time_smallbullet = Time.time;
        stop_boss = false;attack = false;
        textholder.GetComponentInChildren<textHolder>().keyOfJet.fontSize = 20;
        textholder.SetActive(false);
        set_blood_for_boss();
    }
    // Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(Time.deltaTime * speed * (-1), 0, 0));
        float a = Mathf.Abs(transform.position.x - target.GetComponent<Transform>().position.x);
        if (a<13&&!stop_boss)
        {
            speed = 0;stop_boss = true;
            textholder.SetActive(true);attack = true;
            gameObject.GetComponentInChildren<Animator>().enabled = false;
        }
        if(attack)
        {
            fire_bullet(); 
            change_text();
            fire_smallbullet();
        }
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConTroller_scene2>().check_die_boss();
    }
    void lose_heart(float damage)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConTroller_scene2>().lose_heart_boss(dagamed);
    }
    void change_text()
    {
        InputField attack = InputField.FindObjectOfType<InputField>();
        if (attack.text == key)
        {
            show_effect_explosion();
            lose_heart(dagamed);
            key = textholder.GetComponent<textHolder>().getWords(difficultOfWord);
            textholder.GetComponent<textHolder>().textUI.text = key;
            attack.text = null;
            GameObject.FindGameObjectWithTag("Player").GetComponent<tanka_scene2>().get_point(point_one);
        }
    }
    void show_effect_explosion()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 0.5f);
    }
    void fire_bullet()
    {
        if(Time.time>start_time_bullet)
        {
            GameObject Bullet = Instantiate(bullet, new Vector3(4.34f, -2.32f, 0), Quaternion.identity);
            start_time_bullet = Time.time + 1;
            GameObject Shooting_effect = Instantiate(shooting_effect, new Vector3(4.14f, -2.36f, 0), Quaternion.Euler(0,0,75));
            Destroy(Shooting_effect, 0.5f);
        }
    }
    void fire_smallbullet()
    {
        if (Time.time >= start_time_smallbullet)
        {
            GameObject Smallbullet = Instantiate(small_bullet, new Vector3(4.53f, -3.15f, 0), Quaternion.Euler(0, 0, 90));
            start_time_smallbullet = Time.time + 0.5f;
        }
    }
    void set_blood_for_boss()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConTroller_scene2>().set_blood_for_boss(blood_boss);
    }
    void OnDestroy()
    {
        
    }
    public void at_die()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 7f);
        Destroy(textholder,0.01f);
        attack = false;
    }
}
