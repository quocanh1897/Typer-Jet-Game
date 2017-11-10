using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jetFall : MonoBehaviour {
    public float jetSpeed;

    public GameObject weapon;
    public GameObject explose;
    public GameObject target;
    public int difficultOfWord;
    Transform tfTarget;

    private bool success;
    private float oldPosition;
    private float point = 0f;

    private GameObject jet;
    public GameObject textHolder;
    // Use this for initialization
    void Start()
    {
        jet = gameObject;
        //jetSpeed = -2f;
        jetSpeed = Random.Range(-5f, -2f);
        tfTarget = target.GetComponent<Transform>();//vi tri cua muc tieu (tank)
        jet.GetComponent<Rigidbody2D>().isKinematic = true;
        success = true;
        point = 30f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (jet != null)
        {
            jet.transform.Translate(new Vector3(Time.deltaTime * jetSpeed, 0, 0));
            if (Mathf.Abs(transform.position.x - tfTarget.position.x) < 0.2f && success)
            {
                success = false;
                DropBoom();
                Destroy(jet, 4f);
            }
        }
    }
    void DropBoom()
    {
        Collider2D cld = gameObject.GetComponent<Collider2D>();
        cld.isTrigger = true;
        Instantiate(weapon, transform.position, Quaternion.identity);
    }
    public void getPointforplayer()
    {
        target.GetComponent<tanka>().getpoint(point);
    }
    public void getManaforplayer()
    {
        target.GetComponent<tanka>().getmana();
    }
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    getManaforplayer();
    //    getPointforplayer();
    //    InputField.FindObjectOfType<InputField>().text = null;
    //    Vector3 transPos = transform.position;
    //    GameObject explosion = Instantiate(explose, transPos, Quaternion.identity);
    //    Debug.Log("explosion !");
    //    Text textKeyJet = gameObject.GetComponentInChildren<textHolder>().keyOfJet;
    //    Destroy(textKeyJet, 0f);
    //    Destroy(explosion, 1f);
    //    Destroy(gameObject, 0.4f);
    //}
    public void getshot()
    {
        target.GetComponent<tanka>().gun();
    }
    void OnDestroy()
    {
        getManaforplayer();
        getPointforplayer();
        InputField.FindObjectOfType<InputField>().text = null;
        Vector3 transPos = transform.position;
        GameObject explosion = Instantiate(explose, transPos, Quaternion.identity);
        Text textKeyJet = gameObject.GetComponentInChildren<textHolder>().keyOfJet;
        Destroy(textKeyJet, 0f);
        Destroy(explosion, 1f);
    }

}
