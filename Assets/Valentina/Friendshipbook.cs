using System.Collections.Generic;
using UnityEngine;

public class Friendshipbook : MonoBehaviour
{
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject blackScreen;
    public List<GameObject> pageList;

    public List<GameObject> stammbaum;
    public List<GameObject> fsbPhotos;

    private bool pickedup = false;

    private void Start()
    {
        book.SetActive(false); blackScreen.SetActive(false);
    }
    public void OpenOrCloseFriendshipbook()
    {
        if (book.activeSelf && pickedup == true) { book.SetActive(false); blackScreen.SetActive(false); }
        else if (pickedup == true) { book.SetActive(true); blackScreen.SetActive(true); }

        Debug.Log("Pick up the Friendshipbook first!");
    }

    public void PickUpFriendshipbook()
    {
        Debug.Log("The Friendshipbook has been picket up!");
        PickedUpFriendshipbook();
    }

    public void TurnPage()
    {
        foreach (GameObject page in pageList)
        {
            if (page.activeSelf)
            {
                page.SetActive(false);
                if (pageList.IndexOf(page) != pageList.Count - 1) { pageList[pageList.IndexOf(page) + 1].SetActive(true); break; }
                else { pageList[0].SetActive(true); break; }

            }
            
        }
    }

    private bool PickedUpFriendshipbook()
    {
        return pickedup = true;
    }
}
