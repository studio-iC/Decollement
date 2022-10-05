using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCursor : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorRemove;

    private Texture2D nowCursor = null;

    public bool isNormal = true;

    private void Start() {
        nowCursor = cursorNormal;
        if (!GameManager.instance) return;
        GameManager.instance.myCursor = this;
    }

    private void Update()
    {
        Cursor.SetCursor(nowCursor, Vector2.zero, CursorMode.Auto);

        if (Input.GetMouseButtonDown(0) && GameManager.instance)
        {
            GameManager.instance.audioManager.Play("点击", "effect");
        }
    }

    public void SetCursor(string type)
    {

        if (type == "Normal"){
            nowCursor = cursorNormal;
        }
        else if (type == "Remove"){
            nowCursor = cursorRemove;
        }
    }
}
