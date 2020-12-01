using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Direction enum for turning
enum Directions
{
    Left,
    Right,
    None
}

public class TouchControlHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Button for turning
    [SerializeField] private Directions BtnDirection = Directions.None;
    internal static bool left;                          //For indicating turning left
    internal static bool right;                          //For indicating turning right

    //
    public void OnPointerDown(PointerEventData eventData)
    {
        if (BtnDirection == Directions.Left)
        {
            left = true;
            right = false;
        }
        else if (BtnDirection == Directions.Right)
        {
            right = true;
            left = false;
        }
    }

    //
    public void OnPointerUp(PointerEventData eventData)
    {
        left = false;
        right = false;
    }
}
