using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public GameObject ball = null;

    private float timeSub = 2f;
    private float preTime = 0f;
    private bool flag = true;

    public void OnStartBtnPressed()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void OnExitBtnPressed()
    {
        Application.Quit();
        
    }

    private void Start() {
        Time.timeScale = 0.75f;
        if (ball)
        {
            //随机位置和角度
            Vector2 pos = new Vector2(Random.Range(-6f, 6f), 2);
            Quaternion ang = Quaternion.Euler(0, 0, Random.Range(-45f, 45f));
            ball.transform.position = pos;
            ball.transform.rotation = ang;
        }
    }

    private void FixedUpdate() {
        if (preTime + timeSub <= Time.fixedTime && ball)
        {
            preTime = Time.fixedTime;
            flag = !flag;
            if (flag)
            {
                ball.transform.GetChild(0).gameObject.SetActive(true);
                ball.transform.GetChild(1).gameObject.SetActive(false);
                ball.GetComponent<BoxCollider2D>().enabled = true;
                ball.GetComponent<CircleCollider2D>().enabled = false;
            }
            else
            {
                ball.transform.GetChild(0).gameObject.SetActive(false);
                ball.transform.GetChild(1).gameObject.SetActive(true);
                ball.GetComponent<BoxCollider2D>().enabled = false;
                ball.GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }
}
