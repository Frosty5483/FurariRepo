using UnityEngine;
using UnityEngine.UI;

public class StringAbgleicher : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private string correctWord;
    public bool answerFound;

    public void InputSent()
    {
        if (inputField.text == correctWord)
        {
            answerFound = true;
        }
    }
}
