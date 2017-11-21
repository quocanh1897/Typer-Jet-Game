using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum soundsGame
{
	heal,
	bomno,
	dailien,
	dailien1,
	danger,
	ready,
	dropbom,
	eat,
	dropbomnhanh,
}
public class SoundController : MonoBehaviour
{
	public AudioClip soundBomno;
	public AudioClip soundHeal;
	public AudioClip soundDailien;
	public AudioClip soundDailien1;
	public AudioClip soundDanger;
	public AudioClip soundReady;
	public AudioClip soundDropbom;
	public AudioClip soundDropbomnhanh;
	public AudioClip soundEat;
	//public AudioClip soundWing;
	public static SoundController instance;

	// Use this for initialization
	void Start()
	{
		instance = this;
	}
	public static void PlaySound(soundsGame currentSound)
	{
		switch (currentSound)
		{
		case soundsGame.bomno:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundBomno);
			}
			break;
		case soundsGame.dailien:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundDailien);
				//instance.Invoke("PlaySoundDie", 0.3f);
			}
			break;
		case soundsGame.dailien1:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundDailien1);
				//instance.Invoke("PlaySoundDie", 0.3f);
			}
			break;
		case soundsGame.danger:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundDanger);
			}
			break;
		case soundsGame.ready:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundReady);
			}
			break;
		case soundsGame.dropbom:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundDropbom);
			}
			break;
		case soundsGame.eat:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundEat);
			}
			break;
		case soundsGame.heal:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundHeal);
			}
			break;
		case soundsGame.dropbomnhanh:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundDropbomnhanh);
			}
			break;
		}
	}
	private void PlaySoundBomno()
	{
		PlaySound(soundsGame.bomno);
	}
	private void PlaySoundDailien()
	{
		PlaySound(soundsGame.dailien);
	}
	private void PlaySoundReady()
	{
		PlaySound(soundsGame.ready);
	}
	private void PlaySoundDanger()
	{
		PlaySound(soundsGame.danger);
	}
	private void PlaySoundDropbom()
	{
		PlaySound(soundsGame.dropbom);
	}
	private void PlaySoundDailien1()
	{
		PlaySound(soundsGame.dailien1);
	}
	private void PlaySoundEat()
	{
		PlaySound(soundsGame.eat);
	}
	private void PlaySoundHeal()
	{
		PlaySound(soundsGame.heal);
	}
	private void PlaySoundDropBom()
	{
		PlaySound(soundsGame.dropbomnhanh);
	}
}
