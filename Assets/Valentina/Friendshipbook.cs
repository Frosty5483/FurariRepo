using System.Collections.Generic;
using UnityEngine;

public class Friendshipbook : MonoBehaviour
{
    [SerializeField] GameObject book;
    public List<GameObject> pageList;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOrCloseFriendshipbook()
    {
        if (book.activeSelf) book.SetActive(false);
        else book.SetActive(true);
    }

    public void TurnPage()
    {
        foreach (GameObject page in pageList)
        {
            if (page.activeSelf)
            {
                page.SetActive(false);
                if (pageList.IndexOf(page) != pageList.Count-1) pageList[pageList.IndexOf(page)+1].SetActive(true);
                else pageList[0].SetActive(true);
            }
        }
    }

}
