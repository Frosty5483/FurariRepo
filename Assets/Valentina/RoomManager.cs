using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> roomlist;
    public int roomIndex = 0;

    public List<bool> RoomCompletion;

    void Start()
    {
        RoomUpdater();
    }
    public void Door(int a)
    {
        switch (a)
        {
            case 0:
                if (RoomCompletion[roomIndex] == true) roomIndex++;
                else { Debug.Log("please solve the puzzle first"); }
                    break;
            case 1:
                if (roomIndex != 0) roomIndex--;
                break;
        }
        RoomUpdater();
    }
    private void RoomUpdater()
    {
        foreach (GameObject obj in roomlist)
        {
            if (roomlist.IndexOf(obj) != roomIndex) { obj.SetActive(false); }
            else { obj.SetActive(true); }
        }
    }
    public void RoomCompleted(int i)
    {
        RoomCompletion[roomIndex] = true;
        if (i == 1)
        {
            roomIndex++;
            RoomUpdater();
        }
    }
}
