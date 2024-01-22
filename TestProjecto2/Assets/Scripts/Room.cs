using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
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
    [Header("FinalDoors")]
    [SerializeField] GameObject finalTopDoor;
    [SerializeField] GameObject finalBottonDoor;
    [SerializeField] GameObject finalLeftDoor;
    [SerializeField] GameObject finalRightDoor;
    [SerializeField] GameObject finalFloorTop;
    [SerializeField] GameObject finalFloorBotton;
    [SerializeField] GameObject finalFloorLeft;
    [SerializeField] GameObject finalFloorRight;

    [DoNotSerialize]public int totalDoors = 0;

    [DoNotSerialize] public bool topDoorOpen = false;
    [DoNotSerialize] public bool bottomDoorOpen = false;
    [DoNotSerialize] public bool leftDoorOpen = false;
    [DoNotSerialize] public bool rightDoorOpen = false;


    public Vector2Int RoomIndex {  get; set; }
    
    public void OpenDoor(Vector2Int direction)
    {
        if (direction == Vector2Int.up)
        {
            topWall.SetActive(false);
            topDoor.SetActive(true);
            totalDoors++;
            topDoorOpen = true;
        }

        if (direction == Vector2Int.down)
        {
            bottonWall.SetActive(false);
            bottonDoor.SetActive(true);
            totalDoors++;
            bottomDoorOpen = true;

        }

        if (direction == Vector2Int.left)
        {
            leftWall.SetActive(false);
            leftDoor.SetActive(true);
            totalDoors++;
            leftDoorOpen = true;

        }

        if (direction == Vector2Int.right)
        {
            rightWall.SetActive(false);
            rightDoor.SetActive(true);
            totalDoors++;
            rightDoorOpen = true;

        }
    }
    public void SetFloor()
    {
        if(floor1.activeInHierarchy) floor1.SetActive(false);
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
    public void OpenFinalDoor()
    {
        
        if (topDoorOpen == false)
        {
            topWall.SetActive(false);
            finalTopDoor.SetActive(true);
            finalFloorTop.SetActive(true);
        }
        else if (bottomDoorOpen==false)
        {
            bottonWall.SetActive(false);
            finalBottonDoor.SetActive(true);
            finalFloorBotton.SetActive(true);
        }else if(leftDoorOpen == false)
        {
            leftWall.SetActive(false);
            finalLeftDoor.SetActive(false);
            finalFloorLeft.SetActive(false);
        }else if (rightDoorOpen == false)
        {
            rightWall.SetActive(false);
            finalRightDoor.SetActive(false);
            finalFloorRight.SetActive(false);
        }

    }

}
