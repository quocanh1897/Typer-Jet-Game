using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Scene2 : MonoBehaviour {

    // Use this for initialization
    public GameObject explose;
    private float damage;
    private float mana;
    private float moveSpeed;
    public int type_boom;
	void Start () {
        mana = 20f;
        moveSpeed = 5f;
        if (type_boom == 0) { damage = 10f; }
        else if(type_boom==1) { damage = 50f;}
	}
	// Update is called once per frame
	void Update () {
        if (type_boom == 0)
        { transform.Translate(new Vector3(0, -1 * Time.deltaTime * moveSpeed, 0)); }
        if(type_boom==1)
        {
          transform.Translate(new Vector3(0, -1 * Time.deltaTime * 2, 0));
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<tanka_scene2>().lose_heart(damage);
            other.gameObject.GetComponent<tanka_scene2>().get_mana(mana);
        }
        Destroy(gameObject, 0.01f);
    }
    void OnDestroy()
    {
        if (type_boom == 0)
        {
            GameObject exp = Instantiate(explose, transform.position, Quaternion.identity);
            Destroy(exp, 1f);
        }
        else if(type_boom==1)
        {
            GameObject exp = Instantiate(explose, new Vector3(transform.position.x,transform.position.y-0.5f,transform.position.z), Quaternion.identity);
            Destroy(exp, 2.9f);
        }
    }
}
