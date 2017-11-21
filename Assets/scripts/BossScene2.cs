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
        textholder.GetComponentInChildren<textHolder>().keyOfJet.fontSize = 20; //Chinh size chu textholder nho lai xiu :))
        textholder.SetActive(false); //Luc dau chua hien chu, dung lai tan cong moi hien chu
        set_blood_for_boss();
    }
    // Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(Time.deltaTime * speed * (-1), 0, 0));
        float a = Mathf.Abs(transform.position.x - target.GetComponent<Transform>().position.x);
        if (a<13&&!stop_boss) //Cho boss di chuyen 1 doan sau do dung lai va tan cong.
        {
            speed = 0;stop_boss = true;
            textholder.SetActive(true);attack = true;
            gameObject.GetComponentInChildren<Animator>().enabled = false;
        }
        if(attack) //Cac hoat dong luc tan cong: thay doi chu, ban dan dai bac, ban dan ria
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
    void change_text() //Thay doi tu khoa moi khi ta nhap dung tu khoa truoc do, lam mat mau boss, lay diem,...
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
    void show_effect_explosion() //Hieu ung no tai boss
    {
		SoundController_2.PlaySound_2(soundsGame_2.bomnonhanh);
		GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 0.5f);
    }
    void fire_bullet() //Ban 1 vien dan tai nong sung ria cua boss, moi giay ban 1 vien 
    {
        if(Time.time>start_time_bullet)
        {
            //////////////////////////////////////ban dai bac
			//SoundController_2.PlaySound_2(soundsGame_2.galting);
			GameObject Bullet = Instantiate(bullet, new Vector3(4.34f, -2.32f, 0), Quaternion.identity);
            start_time_bullet = Time.time + 1; //moi giay ban 1 vien 
            GameObject Shooting_effect = Instantiate(shooting_effect, new Vector3(4.14f, -2.36f, 0), Quaternion.Euler(0,0,75));
            Destroy(Shooting_effect, 0.5f);
        }
    }
    void fire_smallbullet() //Ban 1 vien dan lua tai nong dai bac cua boss, cu 0.5 giay ban 1 vien
    {
        if (Time.time >= start_time_smallbullet)
        {
            ///////////////////////////////////////////////ban dien
			SoundController_2.PlaySound_2(soundsGame_2.electricban);
			GameObject Smallbullet = Instantiate(small_bullet, new Vector3(4.53f, -3.15f, 0), Quaternion.Euler(0, 0, 90));
            start_time_smallbullet = Time.time + 0.5f; //cu 0.5 giay ban 1 vien
        }
    }
    void set_blood_for_boss() //Thiet lap mau cho boss
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConTroller_scene2>().set_blood_for_boss(blood_boss);
    }
    void OnDestroy()
    {
        
    }
    public void at_die() //Xu ly khi boss chet: tao hieu ung no trong 7s, lam no ngung tan cong
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 7f);
        Destroy(textholder,0.01f); 
        attack = false; //Bien nay xac dinh boss co dang tan cong hay khong 
    }
}
