//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class flyplane : MonoBehaviour {

//    // Use this for initialization
//    public float moveSpeed;
//    public float moveRange;
//    public Vector3 oldPosition;
//    public GameObject weapon;
//    public GameObject explose;
//    public GameObject target;
//    Transform tftarget;
//    public Text showkey;
//    Rigidbody2D rb;
//    private bool success;
//    public string key;
//    void Start () {
//        oldPosition = transform.position;
//        rb = gameObject.GetComponent<Rigidbody2D>();
//        tftarget = target.GetComponent<Transform>();
//        rb.isKinematic = true;
//        success = true;
//        showkey.transform.position = transform.position;
//        showkey.text = key;
//    }
//	// Update is called once per frame
//	void Update () {
//        if(Mathf.Abs(transform.position.x-tftarget.position.x)<5&&success){ success = false;DropBoom(); }
//        transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed,0,0));
//        showkey.transform.position = transform.position;
//    }
//    void DropBoom()
//    {
//        Instantiate(weapon, transform.position, Quaternion.identity);
//    }
//}
