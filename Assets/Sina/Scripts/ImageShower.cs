using UnityEngine;
using UnityEngine.UI;

public class ImageShower : MonoBehaviour
{
    [SerializeField] private Image image;
    private bool imageShown = false;

    public void ChangeState()
    {
        imageShown = !imageShown;
        image.enabled = imageShown;
    }
    
}
