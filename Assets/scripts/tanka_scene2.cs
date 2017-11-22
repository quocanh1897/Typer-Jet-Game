using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tanka_scene2 : MonoBehaviour {

    // Use this for initialization
    public float blood; //Mau cua Player
    public float mana; //Mana cua Player
    public Slider slider_blood;
    public Slider slider_mana;
    public Image image_power;
    public Text Text_show_point;
    public GameObject shooting_effect; //Hieu ung ban dan tu nong sung
    public GameObject explosion;
    public GameConTroller_scene2 control;
	public GameObject shield;
	public GameObject shield_dmg;
    public float point;
	public bool isprotect;
    private float start_time_explose;
    private bool isLoseGame;
    private bool isplaying;
	private GameObject shield1;
	private GameObject shield2;
    void Start () {
        slider_blood.maxValue = blood;
        slider_blood.value = blood;
        slider_mana.maxValue = mana;
        slider_mana.value = 0;
        point = 0;
        image_power.GetComponent<Animator>().enabled = false;
        slider_blood.minValue = 0;slider_mana.minValue = 0;
		isLoseGame = false;isplaying = false;isprotect = false;
	}
    // Update is called once per frame
	void Update () {
        check_full_mana();
        if(!isplaying) check_lose(); //Trang thai nay la con choi nen kiem tra xem thua chua
        if(isLoseGame) //Trang thai nay la da thua 
        {
            if (Time.time > start_time_explose + 5f) //Cho cho 5 s troi qua xong goi ham Lose_game tu GameController_scene_2
            {
                isLoseGame = false;
                slider_blood.value = blood;
                control.point = point; control.Lose_game();
            }
        }
	}
    public void lose_heart(float damage) //Ham  mat 1 luong mau
    {
        slider_blood.value -= damage;
    }
    public void get_mana(float power) //Ham nhan 1 luong mana
    {
        slider_mana.value += power;
    }
    void check_full_mana() //Kiem tra day mana chua de su dung galtingun
    {
        if (slider_mana.value >= mana)
        {
            image_power.GetComponent<Animator>().enabled = true;
            if (Input.GetKey(KeyCode.Space)) //Khi day mana ma nguoi choi bam space
            {
                image_power.GetComponent<Animator>().enabled = false;
                slider_mana.value = 0;
                GameObject[] galti = GameObject.FindGameObjectsWithTag("galtigun");
                foreach(GameObject gobj in galti)
                {
                    gobj.GetComponent<galtigunweapon>().fire = true; //Thiet lap bien fire cho tat ca cac galtingun
                }
                InputField.FindObjectOfType<InputField>().text = null;
            }
        }
    }
    public void recover(float addblood) //Hoi phuc khi nhan 1 luong mau
    {
        slider_blood.value += addblood;
    }
    public float get_now_blood()
    {
        return slider_blood.value;
    }
    public void get_point(float addpoint) //Nhan 1 so diem, tao hieu ung no o nong sung tank
    {
        point += addpoint;
        Text_show_point.text = "Point: " + point;
        GameObject exp = Instantiate(shooting_effect, new Vector3(-4.12f, -2.4f, 0), Quaternion.Euler(0,0,-60));
        Destroy(exp,0.5f);
    }
    void check_lose() //Kiem tra xem co thua chua
    {
        if(slider_blood.value<=0) //Neu mau <=0 => thua 
        {
            explose_tank();isplaying = true;
        }
    }
    void explose_tank() //Khi da thua thi cho no xe tang
    {
        if(!isLoseGame)
        {
			SoundController_2.PlaySound_2(soundsGame_2.bomnonhanh);
			GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 5f);
            start_time_explose = Time.time; isLoseGame = true; //Thiet lap moc thoi gian de tinh thoi gian huy hieu ung no
        }
    }
    void OnDestroy() //Ham nay khong xai :))
    {
        control.point = point; control.Lose_game();
    }
    public float get_now_point()
    {
        return point;
    }
	public void create_shield()
	{
		if (!isprotect) {
			isprotect = true;
			shield1 = Instantiate (shield, transform.position, Quaternion.identity);
		}
	}
	public void create_shield_dmg()
	{
		isprotect = true;
		shield2 = Instantiate(shield_dmg, transform.position, Quaternion.identity);
	}
	public void destroy_shields()
	{
		isprotect = false;
		GameObject []shields=GameObject.FindGameObjectsWithTag("shield");
		Destroy (shields [0], 0f);
		Destroy(shield2, 0);
	}
}
