using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour
{
    public Sprite cursorIco;
    public Sprite removeIco;

    private SpriteRenderer spren;
    void Start()
    {
        GameManager.instance.myCursor = this;
        spren = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //自定义鼠标追踪
        Vector2 pos  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(pos.x, pos.y);
    }

    //设置鼠标样式
    public void SetCursor(string type)
    {
        if (type == "Normal"){
            spren.sprite = cursorIco;
        }
        else if (type == "Remove"){
            spren.sprite = removeIco;
        }
    }
}
