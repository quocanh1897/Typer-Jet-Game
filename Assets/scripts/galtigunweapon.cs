using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galtigunweapon : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public int galtigun_number;
    public GameObject small_bullet;
    public GameObject warhead;
    public GameObject smoke;
    public bool fire;
    private float z_rotate;
    private float limit_left;
    private float limit_right;
    private float direction;
    private float start_gun;
    void Start () {
        limit_left = 45;
        limit_right = -45;
        z_rotate = 0f;
        if (galtigun_number == 3)
        {  direction = 1; }
        else if(galtigun_number==2)
        {
            speed = 0;
        }
        else if (galtigun_number==1)
        {
            direction = -1;
        }
        start_gun = Time.time;
        fire = false;
        smoke.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        make_rotation();
    }
    void make_rotation()
    {
        if (fire)
        {
            if (Time.time < start_gun + 5f)
            {
                smoke.SetActive(true);
                z_rotate += Time.deltaTime * speed * direction;
                if (z_rotate >= limit_left)
                {
                    direction *= -1;
                    z_rotate = limit_left;
                }
                else if (z_rotate <= limit_right)
                {
                    direction *= -1;
                    z_rotate = limit_right;
                }
                transform.rotation = Quaternion.Euler(0, 0, z_rotate);
                GameObject Small_bullet = Instantiate(small_bullet, warhead.GetComponent<Transform>().position, Quaternion.Euler(0, 0, z_rotate));
            }
            else { fire = false; smoke.SetActive(false); }
         }
        else start_gun = Time.time;
    }
    void Rotation_aftermouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angel, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
    }
}
