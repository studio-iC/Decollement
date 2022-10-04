using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindField : MonoBehaviour
{
    public enum Direction
    {
        UP,LEFT,DOWN,RIGHT
    }
    public Direction direction;
    public AreaEffector2D field;
    public float smallForce = 0.01f;
    public float strongForce = 0.05f;

    
    //风扇朝向
    private void Start() {
        int ro = 0;
        switch (direction)
        {
            case Direction.LEFT:
                ro = 90;
                field.forceMagnitude = smallForce;
                break;
            case Direction.UP:
                ro = 0;
                field.forceMagnitude = strongForce;
                break;
            case Direction.RIGHT:
                ro = -90;
                field.forceMagnitude = smallForce;
                break;
            case Direction.DOWN:
                ro = 180;
                field.forceMagnitude = smallForce;
                break;
        }
        transform.rotation = Quaternion.Euler(0,0,ro);
    }
}
