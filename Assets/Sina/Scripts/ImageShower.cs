using UnityEngine;
using UnityEngine.UI;

public class ImageShower : MonoBehaviour
{
    [SerializeField] private Image image;
    private bool imageShown = false;

    private void Start()
    {
        image.enabled = false;
    }

    public void ChangeState()
    {
        imageShown = !imageShown;
        image.enabled = imageShown;
    }
    
}
