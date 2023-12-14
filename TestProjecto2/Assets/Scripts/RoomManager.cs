using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject roomPrefab;
    [SerializeField] private int maxRooms = 15;
    [SerializeField] private int minRooms = 10;

    int roomWidth = 18;
    int roomHeight = 10;

    int gridSizeX = 10;
    int gridSizeY = 10;

    private List<GameObject> rooms = new List<GameObject>();
    private Queue<Vector2Int> roomQueue = new Queue<Vector2Int>();
    private int[,] roomGrid;
    private int roomCount;
    private bool generationComplete = false;

    private void Start()
    {
        roomGrid = new int[gridSizeX, gridSizeY];
        roomQueue = new Queue<Vector2Int>();
        Vector2Int initialRoomIndex = new Vector2Int(gridSizeX/2, gridSizeY/2);
        RoomGenerator(initialRoomIndex);
    }
    private void Update()
    {
        if (roomQueue.Count > 0 && roomCount < maxRooms && !generationComplete)
        {
            Vector2Int roomIndex = roomQueue.Dequeue();
            int gridX = roomIndex.x;
            int gridY = roomIndex.y;

            TryGeneratorRoom(new Vector2Int(gridX-1, gridY));
            TryGeneratorRoom(new Vector2Int(gridX+1, gridY));
            TryGeneratorRoom(new Vector2Int(gridX, gridY+1));
            TryGeneratorRoom(new Vector2Int(gridX, gridY-1));
        }
        else if (roomCount < minRooms)
        {
            RegenerateRooms();
        }
        else if (!generationComplete)
        {
            Debug.Log($"Generation - {roomCount}");
            generationComplete = true;
        }
    }
    private void RoomGenerator(Vector2Int roomIndex)
    {
        roomQueue.Enqueue(roomIndex);
        int x = roomIndex.x;
        int y = roomIndex.y;
        roomGrid[x, y] = 1;
        roomCount++;
        var initialRoom = Instantiate(roomPrefab, GetPositionFromGridIndex(roomIndex),Quaternion.identity);
        initialRoom.name = $"Room-{roomCount}";
        initialRoom.GetComponent<Room>().RoomIndex = roomIndex;
        rooms.Add(initialRoom);
    }
    private bool TryGeneratorRoom(Vector2Int roomIndex)
    {
        int x = roomIndex.x;
        int y = roomIndex.y;

        if (roomCount >= maxRooms)
        {
            return false;
        }
        if (UnityEngine.Random.value < 0.5f && roomIndex != Vector2Int.zero)
        {
            return false;
        }
        if (CountAdjacentRooms(roomIndex) > 1)
        {
            return false;
        }
        roomQueue.Enqueue(roomIndex);
        roomGrid[x, y] = 1;
        roomCount++;

        var initialRoom = Instantiate(roomPrefab, GetPositionFromGridIndex(roomIndex), Quaternion.identity);
        initialRoom.GetComponent<Room>().RoomIndex = roomIndex;
        initialRoom.name = $"Room-{roomCount}";
        rooms.Add(initialRoom);

        OpenDoors(initialRoom,x,y);
        return true;
    }

    void RegenerateRooms()
    {
        rooms.ForEach(Destroy);
        rooms.Clear() ;
        roomGrid = new int[gridSizeX,gridSizeY];
        roomQueue.Clear();
        roomCount = 0;
        generationComplete = false;

        Vector2Int initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        RoomGenerator(initialRoomIndex);
    }
    void OpenDoors (GameObject room, int x, int y)
    {
        Room newRoomScript = room.GetComponent<Room>();

        Room leftRoomScript = GetRoomScriptAt(new Vector2Int(x-1, y));
        Room rightRoomScript = GetRoomScriptAt(new Vector2Int(x+1, y));
        Room topRoomScript = GetRoomScriptAt(new Vector2Int(x, y+1));
        Room bottomRoomScript = GetRoomScriptAt(new Vector2Int(x, y-1));

        if (x > 0 && roomGrid[x-1, y] != 0)
        {
            newRoomScript.OpenDoor(Vector2Int.left);
            leftRoomScript.OpenDoor(Vector2Int.right);
        }
        if( x < gridSizeX -1 && roomGrid[x+1, y]!= 0)
        {
            newRoomScript.OpenDoor(Vector2Int.right);
            rightRoomScript.OpenDoor(Vector2Int.left);
        }
        if (y > 0 && roomGrid[x,y-1] != 0)
        {
            newRoomScript.OpenDoor(Vector2Int.down);
            bottomRoomScript.OpenDoor(Vector2Int.up);
        }
        if (y <gridSizeY -1 && roomGrid[x,y+1] != 0)
        {
            newRoomScript.OpenDoor(Vector2Int.up);
            topRoomScript.OpenDoor(Vector2Int.down);
        }
        newRoomScript.SetFloor();
        
    }
    Room GetRoomScriptAt(Vector2Int roomIndex)
    {
        GameObject roomObject = rooms.Find(r => r.GetComponent<Room>().RoomIndex == roomIndex);
        if (roomObject != null)
            return roomObject.GetComponent<Room>();
        return null;
    }
    private int CountAdjacentRooms (Vector2Int roomIndex)
    {
        int x = roomIndex.x;
        int y = roomIndex.y;
        int count = 0;

        if (x > 0 && roomGrid[x-1,y]!=0) count++;
        if (x < gridSizeX - 1 && roomGrid[x + 1, y] != 0) count++;
        if (y > 0 && roomGrid[x,y-1] != 0) count++;
        if (y < gridSizeY - 1 && roomGrid[x,y+1] != 0) count++;

        return count;

    }
    private Vector3 GetPositionFromGridIndex(Vector2Int gridIndex)
    {
        int gridX = gridIndex.x;
        int gridY = gridIndex.y;
        return new Vector3(roomWidth * (gridX - gridSizeX / 2), roomHeight * (gridY - gridSizeY / 2));
    }
    private void OnDrawGizmos()
    {
        Color gizmoColor = new Color(0, 1, 1, 0.05f);
        Gizmos.color = gizmoColor;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 position = GetPositionFromGridIndex(new Vector2Int(x, y));
                Gizmos.DrawWireCube(position, new Vector3(roomWidth,roomHeight,1));
            }
        }
    }
}
