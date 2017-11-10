using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5,enemy6,health7;
    public GameObject boss;
    public GameObject player;
    public GameObject bloodboss;
    public GameObject danger;
    public float spawnRate = 3f;
    private float nextSpawn = 0f;
    private int whatToSpawn;
    private float winpoint;
    private bool see_boss;
    private bool while_see_boss;
    private bool while_danger;
    private float start_danger;
    private GameObject Danger;
    // Update is called once per frame
    void Start()
    {
        winpoint = 200f;
        see_boss = false;
        while_see_boss = false;
        while_danger = false;
    }
    void Update()
    {
        if ((Time.time > nextSpawn)&&!see_boss)
        {
            whatToSpawn = Random.Range(1, 8); //random jet 1 - jet 5
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemy3, transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(enemy4, transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(enemy5, transform.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(enemy6, new Vector3(5.2f,0.5f,0f), Quaternion.identity);
                    break;
                case 7:
                    Instantiate(health7, transform.position, Quaternion.identity);
                    break;
            }
            //set next spawn time
            nextSpawn = Time.time + spawnRate;
          }
        check_see_boss();
     }
    void check_see_boss()
    {
        if (boss != null)
        {
            if ((player.GetComponent<tanka>().point>=winpoint)&&!while_see_boss)
            {
                see_boss = true;clean_before_see_boss();
                if(Time.time>=start_danger+2.5f)
                {
                    Destroy(Danger, 0.01f);
                    Create_boss();
                }
            }
        }
    }
    void set_blood_for_boss()
    {
        bloodboss.SetActive(true);
        Debug.Log(boss.GetComponent<bossscene1>().health);
        player.GetComponent<tanka>().setmaxvalueforslideder("bloodboss", boss.GetComponent<bossscene1>().health);
        player.GetComponent<tanka>().setvaluefortslider("bloodboss", boss.GetComponent<bossscene1>().health);
    }
    void clean_before_see_boss()
    {
        if (!while_danger)
        {
            GameObject[] jet = GameObject.FindGameObjectsWithTag("jet");
            foreach (GameObject Jet in jet)
            {
                Destroy(Jet, 0.2f);
            }
            Danger = Instantiate(danger, new Vector3(0, 1.8f, 0), Quaternion.identity);
            start_danger = Time.time;
            while_danger = true;
        }
    }
    void Create_boss()
    {
        if (!while_see_boss)
        {
            GameObject Boss = Instantiate(boss, new Vector3(12.9f, 1.35f, 0), Quaternion.identity);
            set_blood_for_boss();while_see_boss = true;
        }
    }
}

