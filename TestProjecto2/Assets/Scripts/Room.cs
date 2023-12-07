using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Doors")]
    [SerializeField] GameObject topDoor;
    [SerializeField] GameObject bottonDoor;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    [Header("Walls")]
    [SerializeField] GameObject topWall;
    [SerializeField] GameObject bottonWall;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;

    public Vector2Int RoomIndex {  get; set; }
    
    public void OpenDoor(Vector2Int direction)
    {
        if (direction == Vector2Int.up)
        {
            topWall.SetActive(false);
            topDoor.SetActive(true);
        }

        if (direction == Vector2Int.down)
        {
            bottonWall.SetActive(false);
            bottonDoor.SetActive(true);
        }

        if (direction == Vector2Int.left)
        {
            leftWall.SetActive(false);
            leftDoor.SetActive(true);
        }

        if(direction == Vector2Int.right)
        {
            rightWall.SetActive(false);
            rightDoor.SetActive(true);
        }

    }

}
