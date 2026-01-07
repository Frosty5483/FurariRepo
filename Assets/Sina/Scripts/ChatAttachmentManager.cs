using TMPro;
using UnityEngine;

public class ChatAttachmentManager : MonoBehaviour
{
    [SerializeField] private GameObject attachmentList;
    [SerializeField] private GameObject chatField;

    public int sentAttachments;

    [Header("Attachments")]
    [SerializeField] private GameObject[] attachmentTextObjects;
    public bool[] attachmentsFound;
    [SerializeField] private GameObject message;

    [SerializeField] private GameObject nothingHereText;
    private bool anyFound;

    [Header ("Answers")]
    [SerializeField] private GameObject essentialAnswer;

    private void Start()
    {
        attachmentList.SetActive(false);
    }

    public void AttachmentList()
    {
        if (attachmentList.activeSelf)
        {
            attachmentList.SetActive(false);
            return;
        }

        bool anyFound = false;

        for (int i = 0; i < attachmentsFound.Length; i++)
        {
            if (attachmentsFound[i] && attachmentTextObjects[i] != null)
            {
                attachmentTextObjects[i].SetActive(true);
                anyFound = true;
            }
        }

        nothingHereText.SetActive(!anyFound);
        attachmentList.SetActive(true);
    }

    public void SendAttachment(int index)
    {
        sentAttachments ++;
        attachmentsFound[index] = false;
        attachmentList.SetActive(false);
        GameObject newMessage = Instantiate(message, chatField.transform);
        newMessage.GetComponent<TextMeshProUGUI>().text = attachmentTextObjects[index].GetComponent < TextMeshProUGUI>().text;
        Instantiate(essentialAnswer, chatField.transform);
        attachmentTextObjects[index].SetActive(false);
    }

}
