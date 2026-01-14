using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BigItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isOver = false;

    [SerializeField] private GameObject item;
    [SerializeField] private AudioRecManag audioRec;

    private bool shouldStart = false;

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
        if (shouldStart)
        {
            if (isOver == false)
            {
                if (Input.GetMouseButton(0))
                {
                    shouldStart = false;
                    item.SetActive(true);
                    audioRec.testBoolB = false;
                    gameObject.SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shouldStart = false;
            item.SetActive(true);
            audioRec.testBoolB = false;
            gameObject.SetActive(false);
        }
    }

    public void whenShown()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        shouldStart = true;
    }
}
