using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;


public class Child_Jet : MonoBehaviour 
{

	
// Use this for initialization

   public Transform []target;	
   public GameObject textholder;
   public GameObject explosion;
   public int difficultOfWord;
   public float speed;
   private Rigidbody2D rb;
   public float damage;
   private int current;
void Start () 
   {
	
	textholder.GetComponentInChildren<textHolder>().keyOfJet.fontSize = 20;
   }
	
	
// Update is called once per frame
	
void Update () 
   {
		
	
	if (transform.position != target[current].position) //Kiem tra neu chua di toi diem tiep theo trong quy dao
        {
            //transform.rotation = Quaternion.Euler(target[current].position.x, target[current].position.y, target[current].position.z); //Xoay vien dan theo huong cua diem tiep theo
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime); //Sau do di chuyen den diem tiep theo trong quy dao
            gameObject.GetComponent<Rigidbody2D>().MovePosition(pos);// Di chuyen luon thanh phan vat ly cua no di theo
        }
        else current = (current + 1) % target.Length; //Neu da di chuyen roi thi tang current len
	InputField attack = InputField.FindObjectOfType<InputField>(); //Kiem tra neu nguoi choi nhap dung tu khoa thi no,huy doi tuong
        if(attack.text==textholder.GetComponentInChildren<textHolder>().keyOfJet.text)
        {
            speed = 0;
            Destroy(gameObject, 0.1f);
            attack.text = null;
        }
   }

void OnDestroy()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
	SoundController_2.PlaySound_2(soundsGame_2.bomnonhanh);
        Destroy(exp, 0.2f);
    }
void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ////////////////////////////////////////////////nong tieu lien
	    //SoundController_2.PlaySound_2(soundsGame_2.bomnonhanh);
	    Destroy(gameObject, 0.01f);
            other.gameObject.GetComponent<tanka_scene2>().lose_heart(damage);
        }
	else if(other.gameObject.tag == "shield")
	{
		Destroy(gameObject,0.01f);
	}
    }
}