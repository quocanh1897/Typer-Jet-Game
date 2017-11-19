using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tanka_scene2 : MonoBehaviour {

    // Use this for initialization
    public float blood;
    public float mana;
    public Slider slider_blood;
    public Slider slider_mana;
    public Image image_power;
    public Text Text_show_point;
    public GameObject shooting_effect;
    public GameObject explosion;
    public GameConTroller_scene2 control;
    public float point;
    private float start_time_explose;
    private bool isLoseGame;
    private bool isplaying;
    void Start () {
        slider_blood.maxValue = blood;
        slider_blood.value = blood;
        slider_mana.maxValue = mana;
        slider_mana.value = 0;
        point = 0;
        image_power.GetComponent<Animator>().enabled = false;
        slider_blood.minValue = 0;slider_mana.minValue = 0;
        isLoseGame = false;isplaying = false;
	}
    // Update is called once per frame
	void Update () {
        check_full_mana();
       if(!isplaying) check_lose();
        if(isLoseGame)
        {
            if (Time.time > start_time_explose + 1f)
            {
                isLoseGame = false;
                slider_blood.value = blood;
                //Destroy(gameObject, 0.01f);
                control.point = point; control.Lose_game();
                Debug.Log("ahihi");
            }
        }
	}
    public void lose_heart(float damage)
    {
        slider_blood.value -= damage;
    }
    public void get_mana(float power)
    {
        slider_mana.value += power;
    }
    void check_full_mana()
    {
        if (slider_mana.value >= mana)
        {
            image_power.GetComponent<Animator>().enabled = true;
            if (Input.GetKey(KeyCode.Space))
            {
                image_power.GetComponent<Animator>().enabled = false;
                slider_mana.value = 0;
                GameObject[] galti = GameObject.FindGameObjectsWithTag("galtigun");
                foreach(GameObject gobj in galti)
                {
                    gobj.GetComponent<galtigunweapon>().fire = true;
                }
                InputField.FindObjectOfType<InputField>().text = null;
            }
        }
    }
    public void recover(float addblood)
    {
        slider_blood.value += addblood;
    }
    public float get_now_blood()
    {
        return slider_blood.value;
    }
    public void get_point(float addpoint)
    {
        point += addpoint;
        Text_show_point.text = "Point: " + point;
        GameObject exp = Instantiate(shooting_effect, new Vector3(-4.12f, -2.4f, 0), Quaternion.Euler(0,0,-60));
        Destroy(exp,0.5f);
    }
    void check_lose()
    {
        if(slider_blood.value<=0)
        {
            explose_tank();isplaying = true;
        }
    }
    void explose_tank()
    {
        if(!isLoseGame)
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 5f);
            start_time_explose = Time.time; isLoseGame = true;
        }
    }
    void OnDestroy()
    {
        control.point = point; control.Lose_game();
    }
    public float get_now_point()
    {
        return point;
    }
}
