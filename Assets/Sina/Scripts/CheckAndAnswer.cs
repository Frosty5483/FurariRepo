using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAndAnswer : MonoBehaviour
{
    [Header("Words")]
    [SerializeField] public List<string> essentialWords;
    [SerializeField] public List<string> extraWords;
    [SerializeField] private List<string> foundWords;
    public int foundExtraWordsCount = 0;


    [Header("Attachments")]
    [SerializeField] private Attachments attachments;


    [Header("Answers")]
    [SerializeField] private GameObject essentialAnswer;
    public GameObject extraAnswer;
    [SerializeField] private GameObject wrongAnswer;
    [SerializeField] private GameObject foundAnswer;
    [SerializeField] private GameObject chatField;
    private float responseTime = 0.7f;

    public IEnumerator CheckMessage(string message)
    {
        Debug.Log("hier");
        yield return new WaitForSeconds(responseTime);

        if (essentialWords.Contains(message))
        {
            Answer(essentialAnswer);
            ListUpdate(message, essentialWords);
            Debug.Log("Essential Words: " + essentialWords.Count);
        }
        else if (extraWords.Contains(message))
        {
            Answer(extraAnswer); 
            ListUpdate(message, extraWords);
            foundExtraWordsCount++;
            Debug.Log("Extra Words: " + extraWords.Count);
            Debug.Log("Found Extra Words:" + foundExtraWordsCount);
        }
        else if (foundWords.Contains(message))
        {
            Answer(foundAnswer);
        }
        else
        {
            Answer(wrongAnswer);
        }
    }

    private void ListUpdate(string message, List<string> wordType)
    {
        foundWords.Add(message);
        wordType.Remove(message);
    }

    public void Answer(GameObject Answer)
    {
        Instantiate(Answer, chatField.transform);
    }
}
