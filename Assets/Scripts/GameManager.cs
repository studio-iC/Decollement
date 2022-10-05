using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [HideInInspector] public MCursor myCursor;
    [HideInInspector] public AudioManager audioManager;
    public GameObject player = null;
    public GameObject components;
    public PhysicsMaterial2D playerNormal;
    public PhysicsMaterial2D playerNoFric;
    public GameObject victoryView;
    public GameObject pauseView;
    public GameObject pauseBtn;

    public int maxLevelNum = 2;


    [HideInInspector] public Rigidbody2D playerRig;
    [HideInInspector] public BoxCollider2D playerBoxColl;
    [HideInInspector] public CircleCollider2D playerCirColl;


    [HideInInspector] public bool isPausing = false;
    // 属性
    private bool c_gravity = true;
    private bool c_angles = true;
    private bool c_smooth = false;
    private bool c_momentum = false;
    private bool c_resistance = false;

    //实现全局单例类
    private void Awake() 
    {
        
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        //Cursor.visible = false;
        //初始化玩家组件
        if (!player) return;
        playerRig = player.GetComponent<Rigidbody2D>();
        playerBoxColl = player.GetComponent<BoxCollider2D>();
        playerCirColl = player.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && player){
            if (isPausing)
                ContinueGame();
            else
                PauseGame();
        }
    }

    private void SetAngles(bool hasAngles)
    {
        if (!hasAngles)
        {
            player.transform.GetChild(0).gameObject.SetActive(false);
            player.transform.GetChild(1).gameObject.SetActive(true);
            playerBoxColl.enabled = false;
            playerCirColl.enabled = true;
            components.transform.Find("C_Smooth").GetComponent<ComponentDefault>()
                .EnableAttr();
        }
        else
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            player.transform.GetChild(1).gameObject.SetActive(false);
            playerBoxColl.enabled = true;
            playerCirColl.enabled = false;
            components.transform.Find("C_Angles").GetComponent<ComponentDefault>()
                .EnableAttr();
        }
        Vector3 s = player.transform.localScale;
        player.transform.localScale = new Vector3(s.x * 0.8f, s.y * 0.8f, s.z);
    }

    // 设置属性
    public void SetAttr(string name, bool enable)
    {
        if (name == "mass")
        {
            Debug.Log("ComponentMass Disabled");
            c_gravity = enable;

            playerRig.gravityScale = 0;
        }
        else if (name == "angles")
        {
            Debug.Log("ComponentAngles Disabled");
            c_angles = enable;

            SetAngles(false);
        }
        else if (name == "smooth")
        {
            Debug.Log("ComponentSmooth Disabled");
            c_smooth = enable;

            SetAngles(true);
        }
        else if (name == "momentum")
        {
            Debug.Log("ComponentMomentum Disabled");
            c_momentum = enable;

            playerRig.velocity = Vector2.zero;
            playerRig.angularVelocity = 0f;
        }
        else if (name == "resistance")
        {
            Debug.Log("ComponentResistance Disabled");
            c_resistance = enable;

            playerRig.sharedMaterial = playerNoFric;
            playerBoxColl.sharedMaterial = playerNoFric;
            playerCirColl.sharedMaterial = playerNoFric;
        }
    }

    public void ShowVictoryView(bool show)
    {
        isPausing = true;
        victoryView.SetActive(show);
        pauseBtn.SetActive(false);
        audioManager.bgmPlayer.Pause();
        audioManager.Play("过关", "effect");
    }

    //暂停游戏
    public void PauseGame()
    {
        if (isPausing) return;
        playerRig.simulated = false;
        //Time.timeScale = 0;
        Cursor.visible = true;
        pauseView.SetActive(true);
        pauseBtn.SetActive(false);
        isPausing = true;
        audioManager.bgmPlayer.Pause();
    }

    //取消暂停，继续游戏
    public void ContinueGame()
    {
        if (!isPausing) return;
        playerRig.simulated = true;
        //Time.timeScale = 1;
        Cursor.visible = false;
        pauseView.SetActive(false);
        pauseBtn.SetActive(true);
        isPausing = false;
        audioManager.bgmPlayer.Play();
    }

    //通关按钮
    public void OnHomeBtnPressed()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnRetryBtnPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnNextBtnPressed()
    {
        //获取当前关卡编号
        int num = int.Parse(SceneManager.GetActiveScene().name.Split("_")[1]);
        if (num < maxLevelNum)
        {
            num++;
            SceneManager.LoadScene("Level_" + num);
        }
        else
        {
            //播放ED
            SceneManager.LoadScene("ED");
        }
    }

    public void OnExitBtnPressed()
    {
        Application.Quit();
    }

    public void OnCloseBtnPressed()
    {
        Debug.Log("close");
        ContinueGame();
    }
}
