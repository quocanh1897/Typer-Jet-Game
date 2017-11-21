using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum soundsGame_2
{
	//heal,
	bomnonhanh,
	galting,
	electricban,
	electricnhan,
	//dailien1,
	danger_2,
	ready_2,
	dropbom_2,
	eat_2,
	dropbomnhanh,
}
public class SoundController_2 : MonoBehaviour
{
	public AudioClip soundBomnonhanh;
	//public AudioClip soundHeal;
	public AudioClip soundElectricban;
	public AudioClip soundElectricnhan;
	public AudioClip soundGalting;
	//public AudioClip soundDailien1;
	public AudioClip soundDanger_2;
	public AudioClip soundReady_2;
	public AudioClip soundDropbom_2;
	public AudioClip soundDropbomnhanh;
	public AudioClip soundEat_2;
	//public AudioClip soundWing;
	public static SoundController_2 instance_2;

	// Use this for initialization
	void Start()
	{
		instance_2= this;
	}
	public static void PlaySound_2(soundsGame_2 currentSound_2)
	{
		switch (currentSound_2)
		{
		case soundsGame_2.dropbomnhanh:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundDropbomnhanh);
			}
			break;
		case soundsGame_2.bomnonhanh:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundBomnonhanh);
			}
			break;
		case soundsGame_2.dropbom_2:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundDropbom_2);
			}
			break;
		case soundsGame_2.galting:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundGalting);
			}
			break;
		case soundsGame_2.ready_2:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundReady_2);
			}
			break;

		case soundsGame_2.eat_2:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundEat_2);
			}
			break;
		case soundsGame_2.electricban:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundElectricban);
			}
			break;
		case soundsGame_2.electricnhan:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundElectricban);
			}
			break;
		case soundsGame_2.danger_2:
			{
				instance_2.GetComponent<AudioSource>().PlayOneShot(instance_2.soundDanger_2);
			}
			break;
		}
	}

	private void PlaySoundDropbomnhanh()
	{
		PlaySound_2(soundsGame_2.dropbomnhanh);
	}
	private void PlaySoundBomnonhanh()
	{
		PlaySound_2(soundsGame_2.bomnonhanh);
	}
	private void PlaySoundDropbom_2()
	{
		PlaySound_2(soundsGame_2.dropbom_2);
	}
	private void PlaySoundGalting()
	{
		PlaySound_2(soundsGame_2.galting);
	}
	private void PlaySoundReady_2()
	{
		PlaySound_2(soundsGame_2.ready_2);
	}
	private void PlaySoundEat_2()
	{
		PlaySound_2(soundsGame_2.eat_2);
	}
	private void PlaySoundElectricban()
	{
		PlaySound_2(soundsGame_2.electricban);
	}
	private void PlaySoundElectricnhan()
	{
		PlaySound_2(soundsGame_2.electricnhan);
	}
	private void PlaySoundDanger_2()
	{
		PlaySound_2(soundsGame_2.danger_2);
	}
}
