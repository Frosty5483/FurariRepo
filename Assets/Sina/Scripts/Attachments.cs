using UnityEngine;

public class Attachments : MonoBehaviour
{
    [Header("Attachments")]
    [SerializeField] public GameObject[] attachmentTextObjects;
    public bool[] attachmentsFound;
    public int attachmentsSent;

    [SerializeField] private string attachmentAnswer1;
    [SerializeField] private string attachmentAnswer2;
    [SerializeField] CheckAndAnswer checkAndAnswer;

    [SerializeField] private GameObject nothingHereText;
    private bool anyFound;

    [SerializeField] private RoomManager roomManager;

    private void Start()
    {
        anyFound = false;
    }

    public void AttachmentList()
    {
        for (int i = 0; i < attachmentsFound.Length; i++)
        {
            if (attachmentsFound[i] && attachmentTextObjects[i] != null)
            {
                attachmentTextObjects[i].SetActive(true);
                anyFound = true;
            }
        }

        nothingHereText.SetActive(!anyFound);
    }

    public void AttachmentAnswer()
    {
        if (attachmentsSent == attachmentsFound.Length)
        {
            checkAndAnswer.Answer(5);
            roomManager.RoomCompletion[4] = true;
        }
        else
        {
            checkAndAnswer.Answer(4);
        }
    }
}
