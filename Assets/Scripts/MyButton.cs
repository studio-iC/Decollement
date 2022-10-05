using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : Button
{
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        if (state == SelectionState.Highlighted || state == SelectionState.Pressed)
        {
            Debug.Log("Over");
            if (GameManager.instance)
                GameManager.instance.SwitchBackground(true);
        }
        else
        {
            if (GameManager.instance)
                GameManager.instance.SwitchBackground(false);
        }
    }
}
