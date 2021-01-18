using System;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float followSpeed;
    //public Vector3 screenBounds;
    //public float objectWidth, objectHeight;

    private void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
        //objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        //objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void Update()
    {
        //transform.position = new Vector3(Mathf.Clamp(player.position.x, -284f, 284f),
            //Mathf.Clamp(player.position.y, -290f, 290), 0);
    }

    void LateUpdate()
    {
        var playerPosition = player.position;
        
        //Vector3 playerViewPosition = playerPosition;
        
        Vector3 desiredPosition = playerPosition + offset;

        //playerViewPosition.x = Mathf.Clamp(playerViewPosition.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        //playerViewPosition.y = Mathf.Clamp(playerViewPosition.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        
        Vector3 smoothenedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed); 
        
        transform.position = smoothenedPosition;
        
        transform.LookAt(player);
    }
}
