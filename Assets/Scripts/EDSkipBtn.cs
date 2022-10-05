using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EDSkipBtn : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public void OnSkipPressed()
    {
        videoPlayer.Stop();
        SceneManager.LoadScene("Title");
    }

    private void Update() 
    {
        if (videoPlayer.isPlaying)
        {
            if ((ulong)videoPlayer.frame >= videoPlayer.frameCount - 1)
            {
                videoPlayer.Stop();
                SceneManager.LoadScene("Title");
            }
        }
    }    
}
