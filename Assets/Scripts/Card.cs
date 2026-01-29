using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Card : MonoBehaviour
{
    [SerializeField] bool selected = false;
    Vector3 mousePos = Vector3.zero;
    Vector3 cardPos;

    private void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 0;
        cardPos = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0);
        
        if (selected)
        {
            transform.position = cardPos;
        }
    }

    public void SetSelected()
    {
        selected = true;
    }
}
