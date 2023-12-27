using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [Header("Floor")]
    [SerializeField] GameObject floor1;
    [SerializeField] GameObject floor2;
    [SerializeField] GameObject floor4;
    [DoNotSerialize]public int totalDoors = 0;
    public Vector2Int RoomIndex {  get; set; }
    
    public void OpenDoor(Vector2Int direction)
    {
        if (direction == Vector2Int.up)
        {
            topWall.SetActive(false);
            topDoor.SetActive(true);
            totalDoors++;
        }

        if (direction == Vector2Int.down)
        {
            bottonWall.SetActive(false);
            bottonDoor.SetActive(true);
            totalDoors++;

        }

        if (direction == Vector2Int.left)
        {
            leftWall.SetActive(false);
            leftDoor.SetActive(true);
            totalDoors++;

        }

        if (direction == Vector2Int.right)
        {
            rightWall.SetActive(false);
            rightDoor.SetActive(true);
            totalDoors++;

        }
    }
    public void SetFloor()
    {
        floor1.SetActive(false);
        switch (totalDoors)
        {
            case 1:
            case 3:
                floor1.SetActive(true);
                break;
            case 2:
                floor2.SetActive(true); 
                break;
            case 4:
                floor4.SetActive(true);
                break;
            default:
                floor1.SetActive(true);
                break;
        }
    }
}
