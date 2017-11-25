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
	taokhien,
	khienbiban,
	vokhien,
	victory,
	winsound,
	defeated,
	losesound,
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
	public AudioClip soundTaokhien;
	public AudioClip soundVokhien;
	public AudioClip soundVictory;
	public AudioClip soundWinsound;
	public AudioClip soundDefeated;
	public AudioClip soundLosesound;
	public AudioClip soundKhienbiban;
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
		case soundsGame.taokhien:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundTaokhien);
			}
			break;
		case soundsGame.vokhien:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundVokhien);
			}
			break;
		case soundsGame.victory:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundVictory);
			}
			break;
		case soundsGame.winsound:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundWinsound);
			}
			break;
		case soundsGame.losesound:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundLosesound);
			}
			break;
		case soundsGame.defeated:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundDefeated);
			}
			break;
		case soundsGame.khienbiban:
			{
				instance.GetComponent<AudioSource>().PlayOneShot(instance.soundKhienbiban);
<<<<<<< HEAD
				//instance.GetComponent<AudioSource>().PlayDelayed(instance.soundKhienbiban);
				//AudioSource clip= instance.GetComponent<AudioSource>().PlayOneShot(instance.soundKhienbiban);
				//clip.loop = true;
=======
>>>>>>> fd64d57372834d0be14c1eeeab3129584c01bd99
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
	private void PlaySoundTaokhien()
	{
		PlaySound(soundsGame.taokhien);
	}
	private void PlaySoundVokhien()
	{
		PlaySound(soundsGame.vokhien);
	}
	private void PlaySoundVictory()
	{
		PlaySound(soundsGame.vokhien);
	}
	private void PlaySoundWinsound()
	{
		PlaySound(soundsGame.vokhien);
	}
	private void PlaySoundLosesound()
	{
		PlaySound(soundsGame.vokhien);
	}
	private void PlaySoundDefeated()
	{
		PlaySound(soundsGame.vokhien);
	}
	private void PlaySoundKhienbiban()
	{
		PlaySound(soundsGame.khienbiban);
	}
}
