using UnityEngine;

public class Chat : MonoBehaviour
{
    [SerializeField] private GameObject chat;
   
    void Start()
    {
        chat.SetActive(false);
    }

    public void ShowChat()
    {
        chat.SetActive(true);
    }

    public void HideChat() 
    { 
        chat.SetActive(false);
    }
}
