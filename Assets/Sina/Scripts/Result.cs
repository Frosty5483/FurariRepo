using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Result : MonoBehaviour
{
    [SerializeField] private ChatInputManager chatInputManager;
    [SerializeField] private ChatAttachmentManager chatAttachmentManager;
    private int extraWordsCount;
    private int essentialWordsCount;

    [SerializeField] private GameObject resultUI;
    [SerializeField] private GameObject resultSlider;
    [SerializeField] private TextMeshProUGUI resultText;

    [Header("Score Text")]
    public string badScore;
    public string okScore;
    public string goodScore;
    public string greatScore;

    void Start()
    {
        essentialWordsCount = chatInputManager.essentialWords.Count + chatAttachmentManager.sentAttachments;
        extraWordsCount = chatInputManager.extraWords.Count;
        resultUI.SetActive(false);
        resultSlider.SetActive(false);
    }

    public void ShowResult()
    {
        resultUI.SetActive(true);
        Debug.Log("Essential Words: " + chatInputManager.essentialWords.Count);
        if (chatInputManager.essentialWords.Count + chatAttachmentManager.sentAttachments > chatAttachmentManager.attachmentsFound.Length)
        {
            Debug.Log("bad");
            resultSlider.SetActive(false);
            resultText.text = badScore;
        }
        else
        {
            Debug.Log("else");
            ResultText();
            ResultSlider();
        }  
    }

    private void ResultText()
    {
        float foundExtraPercent = 100 / extraWordsCount * chatInputManager.foundExtraWordsCount; 

        if (IsInRange(foundExtraPercent, 0f, 33f))
        {
            resultText.text = okScore;
            Debug.Log("ok");
        }
        else if (IsInRange(foundExtraPercent, 34f, 66f))
        {
            resultText.text = goodScore;
            Debug.Log("good");
        }
        else if (IsInRange(foundExtraPercent, 67f, 100f))
        {
            resultText.text = greatScore;
            Debug.Log("great");
        }
        
    }

    private void ResultSlider()
    {
        Debug.Log("Slider Shown");
        resultSlider.SetActive(true);

        resultSlider.GetComponent<Slider>().maxValue = extraWordsCount + essentialWordsCount;
        resultSlider.GetComponent<Slider>().value = chatInputManager.foundExtraWordsCount + essentialWordsCount;
    }

    bool IsInRange(float value, float min, float max)
    {
        return value >= min && value <= max;
    }
}
