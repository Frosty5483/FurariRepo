using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPullUp : MonoBehaviour
{
    [SerializeField] private Image bigImag;

    [SerializeField] private GameObject getStuffedAnimalObj;
    [SerializeField] private GameObject getBirthdayCardObj;
    [SerializeField] private GameObject getSongRecObj;

    private void Start()
    {
        bigImag.gameObject.SetActive(false);
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverUI())
            {
                return;
            }

            if(!getStuffedAnimalObj.activeInHierarchy && !getBirthdayCardObj.activeInHierarchy && !getSongRecObj.activeInHierarchy)
            {
                bigImag.gameObject.SetActive(true);
                bigImag.gameObject.GetComponent<BigItem>().whenShown();
                gameObject.SetActive(false);
            }
        }
    }

    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
