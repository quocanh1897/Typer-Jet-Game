using System.Collections;

using System.Collections.Generic;
using UnityEngine;


public class Boss_scene3_2 : MonoBehaviour 
{

	
   public GameObject weapon;
   public float start_time_drop_rate;
   public bool attack;
   private float start_time_drop_bomb;
// Use this for initialization
	
void Start () 
{
		
	
    start_time_drop_bomb=Time.time;
    attack=true;
}
	
	
// Update is called once per frame
	
void Update () 
{
		
	
	if(attack)
	{Drop_bomp();}
}

void Drop_bomp()
 {
	if(Time.time>=start_time_drop_bomb)
	{
	   GameObject Weapon=Instantiate(weapon,transform.position, Quaternion.identity);
           start_time_drop_bomb=Time.time+start_time_drop_rate;
	}
 }
}
