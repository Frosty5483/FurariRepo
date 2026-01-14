using System.Collections.Generic;
using UnityEngine;

public class Friendshipbook : MonoBehaviour
{
    [SerializeField] private GameObject bookPuzzle;
    [SerializeField] private GameObject buttonToBook;
    [SerializeField] private GameObject blackScreen;
    public List<GameObject> pageList;

    public List<GameObject> stammbaumFields;
    public List<GameObject> fsbPhotos;

    private bool bookPickedUp = false;

    private void Start()
    {
        bookPuzzle.SetActive(false); blackScreen.SetActive(false);
    }
    public void OpenOrCloseFriendshipbook()
    {
        if (bookPickedUp)
        { 
            if (bookPuzzle.activeSelf) { bookPuzzle.SetActive(false); blackScreen.SetActive(false); } else { bookPuzzle.SetActive(true); blackScreen.SetActive(true); }
        }
        else { Debug.Log("Pick up the Friendshipbook first!"); }
    }

    public void PickUpFriendshipbook()
    {
        Debug.Log("The Friendshipbook has been picked up!");
        ReturnFsbValue();
        Destroy(buttonToBook);
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

    private bool ReturnFsbValue()
    {
        return bookPickedUp = true;
    }
}
