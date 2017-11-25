using System.Collections;

using System.Collections.Generic;

using UnityEngine;


using UnityEngine.UI;

public class Boss_scene3 : MonoBehaviour 
{

	
// Use this for initialization

    public float blood_boss;
    public float dagamed;
    public int difficultOfWord;
    public float point_one;
    public float speed;
    public float start_time_childjet_rate;
    public GameObject explosion;
    public GameObject target;
    public GameObject child_jet;
    public GameObject textholder;
    public GameObject boss_scene3_2;
    private GameObject Boss_scene3_2;
    private string key;
    private float start_time_childjet;
    private bool stop_boss;
    private bool attack;
void Start () 
{
		
	
     set_blood_for_boss();
     key = textholder.GetComponent<textHolder>().textUI.text; 
     textholder.GetComponentInChildren<textHolder>().keyOfJet.fontSize = 20;
     start_time_childjet=Time.time;
     textholder.SetActive(false);
}
	
	
// Update is called once per frame
	
void Update () 
{
		
	
	transform.Translate(new Vector3(Time.deltaTime * speed * (-1), 0, 0));
        float a = Mathf.Abs(transform.position.x - target.GetComponent<Transform>().position.x);
        if (a<13&&!stop_boss) //Cho boss di chuyen 1 doan sau do dung lai va tan cong.
        {
            speed = 0;stop_boss = true;
            textholder.SetActive(true);attack = true;
        }
        if(attack) //Cac hoat dong luc tan cong: thay doi chu, ban dan dai bac, ban dan ria
        {
            born_childjet();
            change_text();
        }
	GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConTroller_scene2>().check_die_boss();
}

void born_childjet()
{
	if(Time.time>=start_time_childjet)
	{
			SoundController.PlaySound(soundsGame.khienbiban);
		GameObject Child=Instantiate(child_jet, new Vector3(5.76f,1.81f, 0),Quaternion.Euler(0,0,20));
		Boss_scene3_2=Instantiate(boss_scene3_2,new Vector3(5.76f,1.5f, 0),Quaternion.identity);
		start_time_childjet=Time.time+start_time_childjet_rate;
	}
}
void change_text() //Thay doi tu khoa moi khi ta nhap dung tu khoa truoc do, lam mat mau boss, lay diem,...
    {
        InputField attack = InputField.FindObjectOfType<InputField>();
        if (attack.text == key)
        {
            attack.text = null;
	    show_effect_explosion();
            lose_heart(dagamed);
            key = textholder.GetComponent<textHolder>().getWords(difficultOfWord);
            textholder.GetComponent<textHolder>().textUI.text = key;
            GameObject.FindGameObjectWithTag("Player").GetComponent<tanka_scene2>().get_point(point_one);
        }
    }
void set_blood_for_boss() //Thiet lap mau cho boss
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConTroller_scene2>().set_blood_for_boss(blood_boss);
    }
void lose_heart(float damage)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConTroller_scene2>().lose_heart_boss(dagamed);
    }
void show_effect_explosion() //Hieu ung no tai boss
    {
		SoundController_2.PlaySound_2(soundsGame_2.bomnonhanh);
		GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(exp, 0.5f);
    }
public void at_die() //Xu ly khi boss chet: tao hieu ung no trong 7s, lam no ngung tan cong
    {
        GameObject exp1 = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp1, 7f);
        Destroy(textholder,0.01f); 
        attack = false; //Bien nay xac dinh boss co dang tan cong hay khong 
	//Boss_scene3_2.GetComponent<Boss_scene3_2>().attack=false;
    }
    void OnDestroy()
    {
    	 Destroy(Boss_scene3_2,0.01f);
    }
}


