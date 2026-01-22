using UnityEngine;

public class Chat : MonoBehaviour
{
    [SerializeField] private GameObject chat;
    private bool chatActive = false;
   
    void Start()
    {
        chat.SetActive(false);
    }

    public void ChangeChat()
    {
        chatActive = !chatActive;
        chat.SetActive(chatActive);
    }
}
