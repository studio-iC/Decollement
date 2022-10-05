using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "NoBounce")
        {
            GameManager.instance.audioManager.Play("碰撞", "effect");
        }
        else if (other.gameObject.tag == "Bounce")
        {
            GameManager.instance.audioManager.Play("弹性", "effect");
        }
    }
}
