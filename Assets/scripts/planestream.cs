using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planestream : MonoBehaviour
{
    private float damage = 0.1f;
    public GameObject explose;
    private GameObject target;
    public GameObject textHolder;
    public GameObject shooting_shield_effect;
    private GameObject obj;

    private float point = 50f;
    void Start()
    {
        obj = gameObject;
        GameObject can = GameObject.FindGameObjectWithTag("canvas");
    }
    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<tanka>().isprotect &&
            !GameObject.FindGameObjectWithTag("Player").GetComponent<tanka>().isdmging)
        {
            Debug.Log("ahihi");
            shooting_shield_effect.SetActive(false);
            target.GetComponent<tanka>().create_shield_dmg();
            GameObject.FindGameObjectWithTag("Player").GetComponent<tanka>().isdmging = true;
            damage = 0;
        }
        if (target != null)
        {
            target.GetComponent<tanka>().loseheart(damage);
            target.GetComponent<tanka>().getmana();
        }
        float a = Mathf.Abs(obj.GetComponent<Transform>().position.x - target.GetComponent<Transform>().position.x);
        if ( a < 11.5f && a > 11f)//planeStream di 1 doan nho thi dung lai
        {
            obj.GetComponent<jetFall>().jetSpeed = 0f;
            //abs (5 -- 6) = 11
        } 
    }
}