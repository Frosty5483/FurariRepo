using TMPro;
using UnityEngine;

public class Send : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Attachments attachments;

    [SerializeField] private GameObject message;

    [SerializeField] private GameObject chatField;

    [SerializeField] private CheckAndAnswer checkAndAnswer;

    public void MessageSent()
    {
        if (inputField.text != null)
        {
            GameObject newMessage = Instantiate(message, chatField.transform);
            newMessage.GetComponent<TextMeshProUGUI>().text = inputField.text;
            StartCoroutine(checkAndAnswer.CheckMessage(inputField.text));
        }
    }

    public void AttachmentSent(int index) 
    {
        GameObject newMessage = Instantiate(message, chatField.transform);
        newMessage.GetComponent<TextMeshProUGUI>().text = attachments.attachmentTextObjects[index].GetComponent<TextMeshProUGUI>().text;
        Destroy(attachments.attachmentTextObjects[index]);
        attachments.AttachmentAnswer();
    }


}
