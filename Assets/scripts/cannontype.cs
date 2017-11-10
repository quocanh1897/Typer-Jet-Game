using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cannontype : MonoBehaviour {

    // Use this for initialization
    public GameObject bullet;
    public GameObject explose;
    public GameObject target;
    public Text showkey;
    Collider2D cld;
    Text rfr_showkey;
    float firerate = 5f;
    float nexttime = 5f;
    float point = 10f;
    string key = "cannon";
	void Start () {
        rfr_showkey = Instantiate(showkey, transform.position, Quaternion.identity);
        GameObject can = GameObject.FindGameObjectWithTag("canvas");
        rfr_showkey.transform.SetParent(can.transform, false);
        rfr_showkey.transform.position = new Vector3(830,75, 0);
        rfr_showkey.text = key;
        cld = gameObject.GetComponent<Collider2D>();
    }
	// Update is called once per frame
	void Update () {
        firebullet();
	}
    void firebullet()
    {
        if(Time.time>nexttime)
        {
            nexttime = Time.time + firerate;
            cld.isTrigger = true;
            GameObject Bullet = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            cld.isTrigger = false;
        }
        InputField attack = InputField.FindObjectOfType<InputField>();
        if(attack.text==key)
        {
            target.GetComponent<tanka>().getpoint(point);
            target.GetComponent<tanka>().getmana();
            target.GetComponent<tanka>().gun();
            Destroy(gameObject, 0.1f);
            Destroy(rfr_showkey, 0.1f);
            attack.text = null;
            return;
        }
    }
    void OnDestroy()
    {
        GameObject exp = Instantiate(explose, transform.position, Quaternion.identity);
        Destroy(exp, 1f);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject, 0.1f);
        Destroy(rfr_showkey, 0.1f);
    }
}
