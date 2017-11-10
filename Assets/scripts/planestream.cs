using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planestream : MonoBehaviour
{
    
    // Use this for initialization
    private float damage = 0.1f;
    public GameObject explose;
    private GameObject target;
    public GameObject textHolder;
    private GameObject obj;
    //public InputField input2;
    //public Text showkey;
    //Text rfr_showkey;
    //string key = "stream";
    private float point = 50f;
    void Start()
    {
        //input2.ActivateInputField();
        obj = gameObject;
        //rfr_showkey = Instantiate(showkey, transform.position, Quaternion.identity);
        GameObject can = GameObject.FindGameObjectWithTag("canvas");
        //rfr_showkey.transform.SetParent(can.transform, false);
        //rfr_showkey.transform.position = new Vector3(830, 200, 0);
        //rfr_showkey.text = key;
        
    }
    // Update is called once per frame
    void Update()
    {
        //input.ActivateInputField();
        //input2.ActivateInputField();
        //InputField attack = InputField.FindObjectOfType<InputField>();
        target = GameObject.FindGameObjectWithTag("Player");
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
        //if (attack.text == key)
        //{
        //    target.GetComponent<tanka>().gun();
        //    target.GetComponent<tanka>().getpoint(point);
        //    target.GetComponent<tanka>().getmana();
        //    target.GetComponent<tanka>().gun();
        //    Destroy(gameObject, 0.1f);
        //    //Destroy(rfr_showkey, 0.1f);
        //    attack.text = null;
        //   return;
        //}
    }
    //void OnDestroy()
    //{
    //    GameObject exp = Instantiate(explose, transform.position, Quaternion.identity);
    //    Destroy(exp, 1f);
    //}
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    GameObject exp = Instantiate(explose, transform.position, Quaternion.identity);
    //    Destroy(exp, 1f);
    //}
}