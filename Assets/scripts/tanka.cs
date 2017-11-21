using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tanka : MonoBehaviour {

    // Use this for initialization
    public GameObject grouprocket;
    public GameObject gunsmoke;
    public GameObject Cannonenemy;
    private GameObject cannon;
    private GameObject fullmana;
    public float point;
    public float blood;
    public float maxmana;
    public GameController control;
    public GameObject explosion;
    private GameObject gobj;
    private Slider health;
    private bool Fire_GroupRocket;
    private bool lose_game;
    private float appearrate_cannon=10f;
    private float nexttime_cannon = 10f;
    private float start_destroy;
    void Start () {
        point = 0f;
        maxmana = 100f;
        //blood = 100f;

        gobj = GameObject.FindGameObjectWithTag("canvas");
        setmaxvalueforslideder("blood", blood);
        setvaluefortslider("blood", blood);
        setmaxvalueforslideder("mana", maxmana);
        setvaluefortslider("mana", 0f);

        Fire_GroupRocket = false;
        fullmana = GameObject.FindGameObjectWithTag("thunder");
        fullmana.GetComponent<Animator>().enabled=false;
        cannon = null;
        lose_game = false;
    }
	// Update is called once per frame
	void Update () {
        fire_grouprocket();
        die_tank();

        if(lose_game)
        {
            if(Time.time>start_destroy+3f)
            {

				Destroy(gameObject, 0.01f);lose_game = false;
            }
        }
    }
    public void loseheart(float damage)
    {
        //health.value -= damage;
        setvaluefortslider("blood", getcurrentvalueofslider("blood") - damage);
    }
    public void getpoint(float Point)
    {
        point += Point;
        setTextfortag("point", "Point: " + point);
    }
    public float getnowpoint()
    {
        return point;
    }
    void setTextfortag(string Tag,string text)
    {
        Text[] arr_text = Text.FindObjectsOfType<Text>();
        foreach (Text txt in arr_text)
        {
            if (txt.tag == Tag)
            {
                txt.text = text; break;
            }
        }
    }
    public void setvaluefortslider(string Tag,float currentmana)
    {
        Slider[] arr_slider = Slider.FindObjectsOfType<Slider>();
        foreach (Slider sld in arr_slider)
        {
            if (sld.tag == Tag)
            {
                sld.value = currentmana;break;
            }
        }
    }
    public void setmaxvalueforslideder(string Tag, float maxvalue)
    {
        Slider[] arr_slider = Slider.FindObjectsOfType<Slider>();
        foreach (Slider sld in arr_slider)
        {
            if (sld.tag == Tag)
            {
                sld.maxValue = maxvalue; break;
            }
        }
    }
    public float getcurrentvalueofslider(string Tag)
    {
        Slider[] arr_slider = Slider.FindObjectsOfType<Slider>();
        foreach (Slider sld in arr_slider)
        {
            if (sld.tag == Tag)
            {
                return sld.value;
            }
        }
        return 0f;
    }
    public void getmana()
    {
        setvaluefortslider("mana",getcurrentvalueofslider("mana")+10f);
    }
    void fire_grouprocket()
    {
        if(getcurrentvalueofslider("mana")==maxmana)
        {
            fullmana.GetComponent<Animator>().enabled=true;
            if (Input.GetKey(KeyCode.Space))
            {
				SoundController.PlaySound(soundsGame.dropbom);
                GameObject GroupRocket = Instantiate(grouprocket, new Vector3(1.4f, -3.4f, 0f), Quaternion.identity);
                setvaluefortslider("mana", 0f);
                fullmana.GetComponent<Animator>().enabled = false;
            }
        }
    }
    public void gun()
    {
        GameObject Gun = Instantiate(gunsmoke, new Vector3(-4.65f, -2.8f, 0), Quaternion.identity);
        Destroy(Gun, 0.2f);
    }
    public void recover(float recover_amount)
    {
        setvaluefortslider("blood", getcurrentvalueofslider("blood") + recover_amount);
    }
    public void die_tank()
    {
       if(getcurrentvalueofslider("blood")<=0)
        {
			//SoundController.PlaySound(soundsGame.bomno);
            explose_tank();
        }
    }
    void OnDestroy()
    {
        control.EndGames();
    }
    void explose_tank()
    {
        if(!lose_game)
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
			SoundController.PlaySound(soundsGame.bomno);
            Destroy(exp, 3f);
            start_destroy = Time.time;lose_game = true;
        }
    }
}
