using UnityEngine;
using System.Collections.Generic;

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
                if (roomIndex != 4 && RoomCompletion[roomIndex] == true) roomIndex++;
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
}
