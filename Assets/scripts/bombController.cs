using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombController : MonoBehaviour
{
    private Animator anim;
    private GameObject other;
    private Vector3 targetPosition;
    public float damage;
    public GameObject obj;
    public GameObject target;
    public GameObject bombExplose;
   
    // Use this for initialization
    void Start()
    {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        targetPosition = target.GetComponent<Transform>().position;
        damage = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(obj.GetComponent<Transform>().position.y - targetPosition.y) < 0.4)
        {
            Debug.Log("trung");
            obj.GetComponent<Collider2D>().isTrigger = false;
            target.GetComponent<tanka>().loseheart(damage);
            target.GetComponent<tanka>().getmana();
            Destroy(obj, 0f);
			SoundController.PlaySound(soundsGame.bomno);
            Destroy(Instantiate(bombExplose, targetPosition, Quaternion.identity),0.5f);//huy bomb sau 0.5s
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shield")
        {
            Destroy(gameObject, 0f);
            Destroy(Instantiate(bombExplose, transform.position, Quaternion.identity), 0.5f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<tanka>().destroy_shields();
        }
    }


}
