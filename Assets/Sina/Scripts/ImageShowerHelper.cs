using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageShowerHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isOver;
    [SerializeField] private GameObject button;


    void Update()
    {
        HandleExitInput();
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
                gameObject.SetActive(false);
                button.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            button.SetActive(false);
        }
    }
}
