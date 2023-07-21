using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    public void AddSound()
    {
        MusicController.Instance.PlayClip(MusicController.Instance.buttonClip);
    }

    public void AddEvent()
    {
        MusicController.Instance.PlayClip(MusicController.Instance.EventClip);
    }
}
