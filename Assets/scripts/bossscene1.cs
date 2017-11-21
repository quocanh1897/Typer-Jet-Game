using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class bossscene1 : MonoBehaviour {

    // Use this for initialization
    public GameObject rocket;
    public GameObject explosion;
    public GameObject textholder;
    public GameObject target;
    public GameObject firework;
    private GameObject Firework;
    public float health;
    public float speed;
    public int difficultOfWord;
    private float damage_rocket;
    private float damage_stream;
    private float time_rate_fire_rocket=5f;
    private float start_time_rocket;
    private float point_one;
    private string key;
    private bool attack;
    private bool win_game;
    private bool fire_work;
    private bool stop_boss;
    private bool high;
    private float start_firework;
    private float point;
    private float speed_high;
    private float oldposition;
    private float highposition;
    private float lowposition;
    private float direction;
    void Start () {
        damage_rocket = 10f;
        damage_stream = 0.1f;
        health = 50f;
        point = 500f;
        speed_high = 5f;
        point_one = 50f;
        start_time_rocket = Time.time;
        attack = false;
        stop_boss = false;
        win_game = false;
        fire_work = false;
        high = false;
        direction = 1;
        key = textholder.GetComponent<textHolder>().textUI.text;
    }
	// Update is called once per frame
	void Update () {
        if (!win_game)
        {
            transform.Translate(new Vector3(Time.deltaTime * speed * (-1), 0, 0));
            float a = Mathf.Abs(transform.position.x - target.GetComponent<Transform>().position.x);
            if (!stop_boss)  textholder.SetActive(false); 
            if (a < 11.5f && a > 11f && !stop_boss)//Boss di 1 doan nho thi dung lai
            {
                textholder.SetActive(true);
                speed = 0; attack = true;stop_boss = true;
                oldposition = transform.position.y;highposition = transform.position.y+2f;
                lowposition = transform.position.y - 2f;
                
            }
            if (attack)
            {
				//SoundController.PlaySound(soundsGame.dailien);
                make_oscillate();
                GameObject.FindGameObjectWithTag("Player").GetComponent<tanka>().loseheart(damage_stream);
                fire_rocket();
				//SoundController.PlaySound(soundsGame.bomno);
                change_text();
				//SoundController.PlaySound(soundsGame.bomno);
                die_boss();
            }
        }


        if(fire_work)
        {
			
            if(Time.time>=start_firework+7f)
            {
				//SoundController.PlaySound(soundsGame.dailien);
                Destroy(Firework, 0.01f);fire_work = false;
                Destroy(gameObject, 0.01f);
				SoundController.PlaySound(soundsGame.bomno);
            }
        }
    }
    void OnDestroy()
    {
        GameObject control = GameObject.FindGameObjectWithTag("GameController");
        control.GetComponent<GameController>().WinGame();
    }
    public void loseheart(float damage)
    {
        health -= damage;
        target.GetComponent<tanka>().setvaluefortslider("bloodboss", target.GetComponent<tanka>().getcurrentvalueofslider("bloodboss") - damage);
    }
    void change_text()
    {
        InputField attack = InputField.FindObjectOfType<InputField>();
        if (attack.text==key)
        {
			SoundController.PlaySound(soundsGame.bomno);
			show_effect_explosion();
            loseheart(50);
            key = textholder.GetComponent<textHolder>().getWords(difficultOfWord);
            textholder.GetComponent<textHolder>().textUI.text = key;
            attack.text = null;
            target.GetComponent<tanka>().getpoint(point_one);
        }
    }
    void die_boss()
    {
        if(health<=0)
        {
            explose();
            show_firework();
        }
    }
    void show_effect_explosion()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 0.5f);
    }
    void fire_rocket()
    {
        if(Time.time>=start_time_rocket)
        {
			SoundController.PlaySound(soundsGame.bomno);
			SoundController.PlaySound(soundsGame.dailien1);
            GameObject Rocket = Instantiate(rocket, new Vector3(4.07f, 1.32f, 0), Quaternion.identity);
            start_time_rocket = Time.time + time_rate_fire_rocket;
        }
    }
    void show_firework()
    {
		////SoundController.PlaySound(soundsGame.dailien);
        if (!fire_work)
        {
            Firework = Instantiate(firework, new Vector3(0, -3f, 0), Quaternion.identity);
            start_firework = Time.time;fire_work = true;
        }
    }
    void explose()
    {
        if (!win_game)
        {
            Destroy(textholder, 0.01f);
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 7f);
            win_game = true;
            target.GetComponent<tanka>().getpoint(point);
            Animator[] anmtor= gameObject.GetComponentsInChildren<Animator>();
            foreach(Animator Anmtor in anmtor)
            {
                Anmtor.enabled = false;
            }
        }
    }
    void make_oscillate()
    {
        oldposition += Time.deltaTime * direction*speed_high;
        if(oldposition>=highposition)
        {
            direction *= -1;
            oldposition = highposition;
        }
        else if(oldposition<=lowposition)
        {
            direction *= -1;
            oldposition = lowposition;
        }
        transform.position = new Vector3(transform.position.x, oldposition, transform.position.z);
    }
}
