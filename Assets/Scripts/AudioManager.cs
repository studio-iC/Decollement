using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> effects;
    public AudioSource soundEffectPlayer;

    private void Start() {
        if (GameManager.instance)
            GameManager.instance.audioManager = this;
    }

    ///<summary> type: "effect" / "bgm"</summary>
    public void Play(string name, string type = "effect")
    {
        foreach (AudioClip ac in effects)
        {
            if (name == ac.name)
            {
                soundEffectPlayer.PlayOneShot(ac);
                break;
            }
        }
    }
}
