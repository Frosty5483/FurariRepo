using UnityEngine;
using UnityEngine.EventSystems;

public class MapSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isOver = false;

    private bool isDraggin = false;

    private Vector2 offset;

    public GameObject smallMap;

    void Start()
    {
        isOver = true;
        gameObject.transform.localPosition = new Vector3(0,0,0);
        gameObject.transform.localScale = new Vector3(1,1,1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }

    
    void Update()
    {
        HandleZoom();

        ClampScale();

        HandleDrag();

        HandleExitInput();
    }

    private void HandleZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            float mouseScrollD = Input.mouseScrollDelta.y;

            gameObject.transform.localScale = gameObject.transform.localScale * mouseScrollD * 1.05f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            float mouseScrollD = Input.mouseScrollDelta.y;

            gameObject.transform.localScale = gameObject.transform.localScale / mouseScrollD / 1.05f;
        }
    }

    private void ClampScale()
    {
        if (gameObject.transform.localScale.y > 3)
        {
            gameObject.transform.localScale = new Vector3(3, 3, 3);
        }

        if (gameObject.transform.localScale.y < 1)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void HandleDrag()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Vector2 mousePos1 = Input.mousePosition;
            float mousePosX = Input.mousePosition.x;
            float mousePosY = Input.mousePosition.y;

            offset = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y) - mousePos1;

            isDraggin = true;
        }
        if (isDraggin)
        {
            gameObject.transform.localPosition = Input.mousePosition + new Vector3(offset.x, offset.y, 0);
        }
        if (Input.GetMouseButtonUp(2))
        {
            isDraggin = false;
        }
    }

    private void HandleExitInput()
    {
        if (isOver == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                smallMap.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            smallMap.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
