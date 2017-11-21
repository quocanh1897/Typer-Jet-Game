using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galtigunweapon : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public int galtigun_number; //Bien nay de thiet lap chieu quay cho galtigum, do minh tu quyet dinh, o day, neu la 3 thi se quay qua trai truoc, 2 khong quay, 1 quay qua phai truoc
    public GameObject small_bullet; //1 nhom 3 vien dan nho de ban
    public GameObject warhead; //Hinh nhu bien nay thua thi phai :))
    public GameObject smoke; //Hieu ung tia lua khi galtigun ban
    public bool fire; //Bien nay se duoc set la true tu ben tank_scene2 khi day nang luong
    private float z_rotate;
    private float limit_left; //Bien ben trai khi quay (tinh ban do)
    private float limit_right;//Bien ben phai khi quay
    private float direction; //Huong quay, se thay doi dau khi galtigun quay den bien va doi chieu chuyen dong
    private float start_gun; //Bien nay dung de chon moc de tinh thoi gian bao lau thi ban
    void Start () {
        limit_left = 45;
        limit_right = -45;
        z_rotate = 0f;
        if (galtigun_number == 3) //Set xem thuoc loai galtingun so may de set direction cho dung
        {  direction = 1; }
        else if(galtigun_number==2)
        {
            speed = 0; //Khong quay nen speed bang 0 cho nhanh 
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
    void make_rotation() //Ham nay lam cho galtingun xoay va ban 
    {
        if (fire) //Khi nhan tinh hieu khai hoa tu tank_scene2
        {
            if (Time.time < start_gun + 5f) //Chu y: Moi lan su dung galtingun no chi ban duoc 5 giay
            {
                smoke.SetActive(true); //Active hieu ung tia lua
                z_rotate += Time.deltaTime * speed * direction;// Bien z_rotate nay se xac dinh goc quay theo truc z theo thoi gian
                if (z_rotate >= limit_left) //Khi goc quay da den bien trai
                {
                    direction *= -1; //Doi chieu quay
                    z_rotate = limit_left; // Gan goc quay lai bang bien ben trai, tranh truong hop quay di luon
                }
                else if (z_rotate <= limit_right) //Khi goc quay da den bien phai
                {
                    direction *= -1; //Tuong tu truong hop tren 
                    z_rotate = limit_right; //Tuong tu truong hop tren 
                }
                transform.rotation = Quaternion.Euler(0, 0, z_rotate);
				/////////////////////////dat dau ban dai lien
				 SoundController_2.PlaySound_2(soundsGame_2.galting);
                GameObject Small_bullet = Instantiate(small_bullet, warhead.GetComponent<Transform>().position, Quaternion.Euler(0, 0, z_rotate));
            }
            else { fire = false; smoke.SetActive(false); }
         }
        else start_gun = Time.time; //Chua nhan thi set moc thoi gian o trang thai cho
    }
    void Rotation_aftermouse() //Ham nay khong xai :)))
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angel, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
    }
}
