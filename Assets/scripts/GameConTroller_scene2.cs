using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameConTroller_scene2 : MonoBehaviour {
<<<<<<< HEAD
    [SerializeField]
=======

>>>>>>> 07d22c23732375ae99a99380444b0e262277aae8
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
    public float start_born_rate;
    public float start_born_health_rate;
    public float point_see_boss;
    private GameObject Countdown;
<<<<<<< HEAD
    public InputField input;
=======
>>>>>>> 07d22c23732375ae99a99380444b0e262277aae8
    private bool isStartGame;
    private GameObject Jets;
    private float start_time_born_jets;
    private float start_time_born_health;
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
<<<<<<< HEAD
        input.ActivateInputField();
=======
>>>>>>> 07d22c23732375ae99a99380444b0e262277aae8
        start_time_born_jets = Time.time;
        start_time_born_health = start_born_health_rate;
        Time.timeScale = 0;
        isStartGame = true;
        time_start_game = Time.time;
        isseeboss = false;
        while_see_boss = false;win_game = false;
        start_see_boss = false;
        start_fire_work = Time.time;fire_work = false;
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        input.ActivateInputField();
=======
>>>>>>> 07d22c23732375ae99a99380444b0e262277aae8
        if (!start_see_boss)
        {
            if (!isStartGame)
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
            else
            {
                if (Time.time >= time_start_game + 4f)
                {
                    Destroy(Countdown, 0.01f); isStartGame = false;
                }
            }
        }
        else
        {
            if (isseeboss)
            {
                if (Time.time >= start_time_danger + 2.5f)
                {
                    Destroy(Danger, 0.01f);
                    Create_Boss(); isseeboss = false;
                }
            }
        }
        if(win_game)
        {
            if(Time.time>=start_fire_work+7f)
            {
                Destroy(Firework, 0.01f);win_game = false;
                Destroy(Boss, 0.01f);
                Win_game();
            }
        }
        check_see_boss();
    }
    public void Start_Game()
    {
        Panel_start.SetActive(false);
        Time.timeScale = 1;
        Count_down();
    }
    void Count_down()
    {
        Countdown = Instantiate(countdown, new Vector3(0, 2.2f, 0), Quaternion.identity);
        time_start_game = Time.time;
    }
    public void Lose_game()
    {
        Time.timeScale = 0;
        Panel_lose.SetActive(true);
        Show_lose_point.text = "Your Points: " + point;
    }
    public void Win_game()
    {
        Time.timeScale = 0;
        Panel_win.SetActive(true);
        Show_win_point.text = "Your Points: " + nowplayer.GetComponent<tanka_scene2>().point;
    }
    public void Restart_Game()
    {
        Panel_lose.SetActive(false);
        isStartGame = true;
        SceneManager.LoadScene(2);
    }
    public void New_Game()
    {
        Panel_win.SetActive(false);
        isStartGame = true;
        SceneManager.LoadScene(2);
    }
    public void test()
    {
        Debug.Log("aaaaaa");
    }
    public void see_boss()
    {
        if(!isseeboss)
        {
            GameObject[] jets = GameObject.FindGameObjectsWithTag("jet");
            foreach(GameObject jet in jets)
            {
                Destroy(jet, 0.01f);
            }
            Danger = Instantiate(danger, new Vector3(0, 1.8f, 0), Quaternion.identity);
            start_time_danger = Time.time;
            isseeboss = true;
        }
    }
    void Create_Boss()
    {
        if(!while_see_boss)
        {
            Boss = Instantiate(boss_scene, new Vector3(11.87f,-3.37f, 0), Quaternion.identity);
            while_see_boss = true;
        }
    }
    public void set_blood_for_boss(float blood)
    {
        blood_of_boss.maxValue = blood;
        blood_of_boss.value = blood;
    }
    public void lose_heart_boss(float damaged)
    {
        blood_of_boss.value -= damaged;
    }
    void check_see_boss()
    {
        if (!start_see_boss)
        {
            if (nowplayer.GetComponent<tanka_scene2>().point >= point_see_boss)
            {
                see_boss(); start_see_boss = true;
            }
        }
    }
    public void check_die_boss()
    {
        if(blood_of_boss.value<=0)
        {
            Fire_work();
        }
    }
    void Fire_work()
    {
        if(!fire_work)
        {
            Firework = Instantiate(firework, new Vector3(0, -3f, 0), Quaternion.identity);
            start_fire_work = Time.time; fire_work = true;
            win_game = true;
            Boss.GetComponent<BossScene2>().at_die();
        }
    }
}
