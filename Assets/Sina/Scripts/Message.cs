using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message : MonoBehaviour
{
    public string message;

    private Image bgImage;
    private TextMeshPro text;

    void Start()
    {
        bgImage = this.GetComponentInChildren<Image>();
        text = this.GetComponentInChildren<TextMeshPro>();
        text.text = message;
        bgImage.rectTransform.localScale = new Vector3(text.preferredWidth * (-1), 1, 1);
    }
}
