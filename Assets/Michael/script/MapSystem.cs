using UnityEngine;
using UnityEngine.EventSystems;

public class MapSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
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

    
    void Update()
    {

        if (isOver)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(isBig == false)
                {
                    gameObject.transform.localScale = new Vector3(3,3,3);
                    isBig = true;
                }
                else if(isBig == true)
                {
                    gameObject.transform.localScale = new Vector3(1,1,1);
                    isBig = false;
                }
                
            }
            if (isBig)
            {
                if (Input.mouseScrollDelta.y > 0)
                {
                    float mouseScrollD = Input.mouseScrollDelta.y;

                    gameObject.transform.localScale = gameObject.transform.localScale * mouseScrollD * 1.5f;
                }
                if(Input.mouseScrollDelta.y < 0)
                {
                    float mouseScrollD = Input.mouseScrollDelta.y;

                    gameObject.transform.localScale = gameObject.transform.localScale / mouseScrollD / 1.5f;
                }
            }
            
            
            
        }
    }

}
