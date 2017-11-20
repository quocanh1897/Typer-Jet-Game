using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameConTroller_scene2 : MonoBehaviour {
    [SerializeField]
    // Use this for initialization
    public GameObject nowplayer;
    public GameObject jets;
    public GameObject planehealth;
    public GameObject Panel_start;
    public GameObject Panel_lose;
    public GameObject Panel_win;
    public GameObject countdown;
    public GameObject danger;
    public GameObject boss_scene;
    public Slider blood_of_boss;
    public GameObject firework;
    public Text Show_lose_point;
    public Text Show_win_point;
    public float point;
    public float start_born_rate; //Khoang thoi gian giua cac lan sinh may ban enemy
    public float start_born_health_rate; //Khoang thoi gian giua cac lan sinh may bay mau
    public float point_see_boss;
    private GameObject Countdown;
    public InputField input;
    private bool isStartGame;
    private GameObject Jets;
    private float start_time_born_jets; //Moc thoi gian de sinh ra may bay enemy
    private float start_time_born_health; //Moc thoi gian de sinh ra may bay mau
    private float time_start_game;
    private float start_time_danger;
    private bool isseeboss;
    private bool while_see_boss;
    private bool start_see_boss;
    private float start_fire_work;
    private bool win_game;
    private bool fire_work;
    private GameObject Boss;
    private GameObject Firework;
    private GameObject Danger;
    void Start () {
        input.ActivateInputField();
        start_time_born_jets = Time.time;
        start_time_born_health = start_born_health_rate;
        Time.timeScale = 0;
        isStartGame = true;
        time_start_game = Time.time; //Bien nay xac dinh thoi gian moc thoi gian bat dau game
        isseeboss = false;
        while_see_boss = false;win_game = false;
        start_see_boss = false;
        start_fire_work = Time.time;fire_work = false;
	}
	
	// Update is called once per frame
	void Update () {
        input.ActivateInputField();
        if (!start_see_boss) //Trang thai nay la chua gap boss
        {
            if (!isStartGame) //Trang thai da qua giai doan bat dau game, sinh ra 1 top may bay va may bay mau
            {
                if (Time.time >= start_time_born_jets)
                {
                    Jets = Instantiate(jets, transform.position, Quaternion.identity);
                    start_time_born_jets = Time.time + start_born_rate;
                }
                if (Time.time >= start_time_born_health)
                {
                    Instantiate(planehealth, transform.position, Quaternion.identity);
                    start_time_born_health = Time.time + start_born_health_rate;
                }
            }
            else //Trang thai nay la giai doan bat dau game, ta cho 4s de huy hieu ung dem nguoc
            {
                if (Time.time >= time_start_game + 4f)
                {
                    Destroy(Countdown, 0.01f); isStartGame = false;
                }
            }
        }
        else //Giai doan nay da bat dau gap boss
        {
            if (isseeboss) //Tinh hieu nay duoc kich phat tu ham void see_boss()
            {
                if (Time.time >= start_time_danger + 2.5f) //Cho cho 2.5s va sau do huy hieu ung Danger, tao ra boss
                {
                    Destroy(Danger, 0.01f);
                    Create_Boss(); isseeboss = false;
                }
            }
        }
        if(win_game) //Bien nay duoc kich phat tu ham Fire_work()
        {
            if(Time.time>=start_fire_work+7f) //Cho cho phao hoa no 7s
            {
                Destroy(Firework, 0.01f);win_game = false; //Huy phao hoa
                Destroy(Boss, 0.01f); //Huy Boss
                Win_game();
            }
        }
        check_see_boss();
    }
    public void Start_Game() //Ham bat dau Game, ta cho no dung thoi gian lai va show ra panel start game
    {
        Panel_start.SetActive(false);
        Time.timeScale = 1;
        Count_down(); 
    }
    void Count_down() //Ham nay dung de dem nguoc thoi gian 3-2-1-Go xong may bay moi ra
    {
        Countdown = Instantiate(countdown, new Vector3(0, 2.2f, 0), Quaternion.identity);
        time_start_game = Time.time; //Gan vao thoi gian cua game de do thoi gian xuat hien hieu ung Countdown
    }
    public void Lose_game() //Ham xu ly thua game, se duoc goi ben tank_scene2, ta show panel lose_game ra,dung thoi gian game lai
    {
        Time.timeScale = 0;
        Panel_lose.SetActive(true);
        Show_lose_point.text = "Your Points: " + point;
    }
    public void Win_game() //Ham xu ly thua game, se duoc goi ben Boss_scene2, ta show panel win_game ra,dung thoi gian game lai
    {
        Time.timeScale = 0;
        Panel_win.SetActive(true);
        Show_win_point.text = "Your Points: " + nowplayer.GetComponent<tanka_scene2>().point;
    }
    public void Restart_Game() //Ham nay xu ly khi thua game va muon choi lai
    {
        Panel_lose.SetActive(false);
        isStartGame = true;
        SceneManager.LoadScene(2);
    }
    public void New_Game() //Ham nay xu ly khi win game va muon choi lai
    {
        Panel_win.SetActive(false);
        isStartGame = true;
        SceneManager.LoadScene(2);
    }
    public void see_boss() //Ham nay xu ly giai doan chuan bi gap boss
    {
        if(!isseeboss)
        {
            GameObject[] jets = GameObject.FindGameObjectsWithTag("jet"); //Huy het may bay hien co
            foreach(GameObject jet in jets)
            {
                Destroy(jet, 0.01f);
            }
            Danger = Instantiate(danger, new Vector3(0, 1.8f, 0), Quaternion.identity); //Xuat hieu ung Danger
            start_time_danger = Time.time; //Do thoi gian de huy hieu ung danger
            isseeboss = true; //Thiet lap trang thai "da gap boss"
        }
    }
    void Create_Boss() //Ham nay tao ra boss
    { 
        if(!while_see_boss) //Bien nay chac chan rang boss chi tao ra dung 1 lan
        {
            Boss = Instantiate(boss_scene, new Vector3(11.87f,-3.37f, 0), Quaternion.identity);
            while_see_boss = true;
        }
    }
    public void set_blood_for_boss(float blood) //Thiet lap mau cho boss
    {
        blood_of_boss.maxValue = blood;
        blood_of_boss.value = blood;
    }
    public void lose_heart_boss(float damaged) //Mat mau boss
    {
        blood_of_boss.value -= damaged;
    }
    void check_see_boss() //Kiem tra xem da du diem de gap boss chua
    {
        if (!start_see_boss)
        {
            if (nowplayer.GetComponent<tanka_scene2>().point >= point_see_boss)
            {
                see_boss(); start_see_boss = true;
            }
        }
    }
    public void check_die_boss() //Kiem ra xem boss da chet chua
    {
        if(blood_of_boss.value<=0)
        {
            Fire_work(); //Neu da chet thi xuat hieu ung phao hoa ra
        }
    }
    void Fire_work()
    {
        if(!fire_work) //Bien nay chac chan rang phao hoa chi tao ra 1 lan 
        {
            Firework = Instantiate(firework, new Vector3(0, -3f, 0), Quaternion.identity);
            start_fire_work = Time.time; fire_work = true; //Xac dinh moc thoi gian de phao hoa bi destroy
            win_game = true;
            Boss.GetComponent<BossScene2>().at_die();
        }
    }
}
