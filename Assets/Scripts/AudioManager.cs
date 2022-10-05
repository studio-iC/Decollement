using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> effects;
    public List<AudioClip> bgms;
    public AudioSource bgmPlayer;
    public AudioSource soundEffectPlayer;

    private void Start() {
        if (GameManager.instance)
            GameManager.instance.audioManager = this;
    }

    ///<summary> type: "effect" / "bgm"</summary>
    public void Play(string name, string type = "effect")
    {
        if (type == "effect")
            foreach (AudioClip ac in effects)
            {
                if (name == ac.name)
                {
                    soundEffectPlayer.clip = ac;
                    soundEffectPlayer.Play();
                    Debug.Log("!!!");
                    break;
                }
            }
        else if (type == "bgm")
            foreach (AudioClip ac in bgms)
            {
                if (name == ac.name)
                {
                    bgmPlayer.loop = true;
                    bgmPlayer.clip = ac;
                    bgmPlayer.Play();
                    break;
                }
            }
    }
}
