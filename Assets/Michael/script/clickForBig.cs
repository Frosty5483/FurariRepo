using UnityEngine;
using UnityEngine.EventSystems;

public class clickForBig : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject makeBigObj;

    private bool isOver = false;

    private bool isBig = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }

    void Start()
    {
        makeBigObj.SetActive(false);
    }

    private void Update()
    {
        if (isOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isBig == false)
                {
                    makeBigObj.SetActive(true);
                    isBig = true;
                }

            }
            
        }
        if(!isOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isBig == true)
                {
                    makeBigObj.SetActive(false);
                    isBig = false;
                }
            }
        }
                
    }
}
