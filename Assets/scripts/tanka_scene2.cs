using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class tanka_scene2 : MonoBehaviour {

    // Use this for initialization
    public int nowscene;
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
        point = float.Parse(get_old_point("1"));
        image_power.GetComponent<Animator>().enabled = false;
        slider_blood.minValue = 0;slider_mana.minValue = 0;
<<<<<<< HEAD
	isLoseGame = false;isplaying = false;isprotect = false;
	get_point(0);
=======
		isLoseGame = false;isplaying = false;isprotect = false;
>>>>>>> fd64d57372834d0be14c1eeeab3129584c01bd99
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
	
        if(nowscene==3)
	{ 
	  GameObject exp = Instantiate(shooting_effect, new Vector3(transform.position.x+2.3f,transform.position.y+1.4f, 0), Quaternion.Euler(0,0,-60));
	  Destroy(exp,0.1f);
	}
        else if(nowscene==2)
	{
	  GameObject exp = Instantiate(shooting_effect, new Vector3(transform.position.x+2.3f,transform.position.y+0.3f, 0), Quaternion.Euler(0,0,-60));
	  Destroy(exp,0.1f);
	}
	
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
<<<<<<< HEAD
			SoundController.PlaySound(soundsGame.taokhien);
=======
>>>>>>> fd64d57372834d0be14c1eeeab3129584c01bd99
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
<<<<<<< HEAD
		SoundController.PlaySound(soundsGame.vokhien);
		Destroy (shields [0], 0f);
		Destroy(shield2, 0);
	}
    public string get_old_point(string id)
    {
	string res = "";string connectionString="URI=file:" + Application.dataPath + "/words.db";
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                int num =UnityEngine.Random.Range(1, 1223);
                string sqlQuery = "SELECT * from highscore where ID = '" +id+ "'";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = reader.GetString(2);
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        return res;
    }
=======
		Destroy (shields [0], 0f);
		Destroy(shield2, 0);
	}
>>>>>>> fd64d57372834d0be14c1eeeab3129584c01bd99
}
