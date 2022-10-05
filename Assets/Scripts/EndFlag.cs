using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Completed!!");
            //重新显示鼠标
            Cursor.visible = true;
            //TODO：关卡完成对话框
            GameManager.instance.ShowVictoryView(true);
            
        }
    }
}
