using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDefault : MonoBehaviour
{
    
    public Sprite enable;
    public Sprite disable;
    public string attr;
    
    public bool isEnabled = true;
    protected SpriteRenderer spren = null;
    

    protected void Start() 
    {
        spren = GetComponent<SpriteRenderer>();

        if (!isEnabled)
        {
            spren.sprite = disable;
            isEnabled = false;
            //GameManager.instance.SetAttr(attr, false);
            //OnComponentDisabled();
        }
    }

    // 鼠标进入范围时检测
    protected void OnMouseEnter() 
    {
        Debug.Log("isOvering");
        if (isEnabled)
            GameManager.instance.myCursor.SetCursor("Remove");
    }

    // 鼠标离开范围时检测
    protected void OnMouseExit() 
    {
        Debug.Log("isExited");
        GameManager.instance.myCursor.SetCursor("Normal");
    }

    protected void OnMouseDown() 
    {
        if (isEnabled == true)
        {
            OnComponentDisabled();
        }
        
    }

    // 虚函数 当被禁用时触发
    protected virtual void OnComponentDisabled()
    {
        spren.sprite = disable;
        isEnabled = false;
        if (GameManager.instance.myCursor)
            GameManager.instance.myCursor.SetCursor("Normal");
        GameManager.instance.SetAttr(attr, false);
    }

    public void EnableAttr() {
        if (!spren) return;
        isEnabled = true;
        spren.sprite = enable;
    }
}
