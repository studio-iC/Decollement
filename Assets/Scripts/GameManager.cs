using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [HideInInspector] public MyCursor myCursor;
    public GameObject player;
    public GameObject components;
    public PhysicsMaterial2D playerNormal;
    public PhysicsMaterial2D playerNoFric;


    [HideInInspector] public Rigidbody2D playerRig;
    [HideInInspector] public BoxCollider2D playerBoxColl;
    [HideInInspector] public CircleCollider2D playerCirColl;

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
        Cursor.visible = false;
        //初始化玩家组件
        playerRig = player.GetComponent<Rigidbody2D>();
        playerBoxColl = player.GetComponent<BoxCollider2D>();
        playerCirColl = player.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)){
            Cursor.visible = !Cursor.visible;
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
}
