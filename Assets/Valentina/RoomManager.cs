using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> roomlist;
    public int roomIndex = 0;

    void Start()
    {
        RoomUpdater();
    }
    public void Door(int a)
    {
        switch (a)
        {
            case 0:
                if (roomIndex != 4) roomIndex++;
                //else roomIndex = 0;
                break;
            case 1:
                if (roomIndex != 0) roomIndex--;
                //else roomIndex = 4;
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
