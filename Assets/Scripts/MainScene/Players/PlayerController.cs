using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<PlayerMovement> Players = new List<PlayerMovement>();

    public GameObject AIPlyer;

    private void Start()
    {
        if(GameValues.isMultiplyer)
        {
            AIPlyer.GetComponent<PlayerMovement>().enabled = true;
            AIPlyer.GetComponent<AIScript>().enabled = false;
        }
        else
        {
            AIPlyer.GetComponent<PlayerMovement>().enabled = false;
            AIPlyer.GetComponent<AIScript>().enabled = true;
        }
    }

    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++) 
        { 
            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            foreach(var player in Players)
            {
                if(player.LockedFingerID == null)
                {
                    if(Input.GetTouch(i).phase == TouchPhase.Began && player.PlayerCollider.OverlapPoint(touchWorldPos))
                    {
                        player.LockedFingerID = Input.GetTouch(i).fingerId;
                    }
                }
                else if(player.LockedFingerID == Input.GetTouch(i).fingerId)
                {
                    player.MoveToPosition(touchWorldPos);
                    if(Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled)
                    {
                        player.LockedFingerID = null;
                    }
                }
            }
        }
    }
}
