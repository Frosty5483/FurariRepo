using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ChatInputManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject message;
    [SerializeField] private GameObject chatField;

    [Header("Words")]
    [SerializeField] public List<string> essentialWords;
    [SerializeField] public List<string> extraWords;
    [SerializeField] private List<string> foundWords;

    [Header("Answers")]
    [SerializeField] private GameObject essentialAnswer;
    [SerializeField] private GameObject extraAnswer;
    [SerializeField] private GameObject wrongAnswer;
    [SerializeField] private GameObject foundAnswer;

    public int foundExtraWordsCount = 0;

    private void Start()
    {
        Debug.Log("Essential Words: " + essentialWords.Count);
        Debug.Log("Extra Words: " + extraWords.Count);
        Debug.Log("Found Extra Words:" + foundExtraWordsCount);
    }

    public void MessageSent()
    {
        if (inputField.text != null)
        {
            GameObject newMessage = Instantiate(message, chatField.transform);
            newMessage.GetComponent<TextMeshProUGUI>().text = inputField.text;
            StartCoroutine(CheckMessage(inputField.text));
        }
    }

    private IEnumerator CheckMessage(string message)
    {
        yield return new WaitForSeconds(0.7f);
        if (essentialWords.Contains(message))
        {
            Instantiate(essentialAnswer, chatField.transform);
            ListUpdate(message, essentialWords);
            Debug.Log("Essential Words: " + essentialWords.Count);
        }
        else if (extraWords.Contains(message))
        {
            Instantiate(extraAnswer, chatField.transform);
            ListUpdate(message, extraWords);
            foundExtraWordsCount++;
            Debug.Log("Extra Words: " + extraWords.Count);
            Debug.Log("Found Extra Words:" + foundExtraWordsCount);
        }
        else if (foundWords.Contains(message))
        {
            Instantiate(foundAnswer, chatField.transform);
        }
        else
        {
            Instantiate(wrongAnswer, chatField.transform);

        }
    }
    private void ListUpdate(string message, List<string> wordType)
    {
        foundWords.Add(message);
        wordType.Remove(message);
    }
}

