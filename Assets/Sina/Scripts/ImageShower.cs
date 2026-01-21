using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageShower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    private bool imageShown = false;
    private bool isOver;

    private void Start()
    {
        image.enabled = false;
    }

    void Update()
    {
        HandleExitInput();
    }

    public void ChangeState()
    {
        imageShown = !imageShown;
        image.enabled = imageShown;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }

    private void HandleExitInput()
    {
        if (isOver == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                imageShown = !imageShown;
                image.enabled = imageShown;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            imageShown = !imageShown;
            image.enabled = imageShown;
        }
    }

}
