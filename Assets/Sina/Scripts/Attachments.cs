using UnityEngine;

public class Attachments : MonoBehaviour
{
    [Header("Attachments")]
    [SerializeField] public GameObject[] attachmentTextObjects;
    public bool[] attachmentsFound;
    public int attachmentsSent;

    [SerializeField] private GameObject nothingHereText;
    private bool anyFound;

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
}
