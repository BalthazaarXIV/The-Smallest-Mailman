using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public float speed, rotationOffset, health, airTime;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        health = 100f;
        airTime = 200f;
    }

    void Update()
    {
        // Player follow the mouse while not moving
        
        
        // Gets the mouse position (without Z because 2D) 
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        
        if (Camera.main is { })
        {
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
        }

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
        
        if (Input.GetKey(KeyCode.W))
        {
            PlayerFollowMouse();
        }
    }
    void PlayerFollowMouse()
    {
        
        // Move the player in the direction of the mouse, want to make that the distance from the mouse will affect the speed.

        if (Camera.main is { } && !UIManagerScript.GameIsPaused)
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}