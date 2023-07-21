using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : Singleton<MusicController>
{
    public AudioClip[] clipsTouch;
    public AudioClip buttonClip;
    public AudioClip swooshClip;
    public AudioClip ExplosionClip;
    public AudioClip EventClip;

    public AudioClip ConfettiClip;
    public AudioClip CompleteClip;
    public AudioClip LoseClip;

    public AudioSource audioSource;
    public AudioSource audioSource2;

    public void PlayRandomButton()
    {
        if ( SettingControll.Instance.SoundCheck == 1)
        {
            int randomIndex = Random.Range(0, clipsTouch.Length);
            audioSource.PlayOneShot(clipsTouch[randomIndex]);
        }
    }

    public void PlayRandomButton2()
    {
        if (SettingControll.Instance.SoundCheck == 1)
        {
            int randomIndex = Random.Range(0, clipsTouch.Length);
            audioSource2.PlayOneShot(clipsTouch[randomIndex]);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        if (SettingControll.Instance.SoundCheck == 1)
        {
            audioSource.PlayOneShot(clip);
        }
    }

}
