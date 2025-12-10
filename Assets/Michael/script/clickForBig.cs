using UnityEngine;

public class clickForBig : MonoBehaviour
{
    [SerializeField] private GameObject makeBigObj;

    void Start()
    {
        makeBigObj.SetActive(false);
        makeBigObj.transform.localScale = new Vector3 (1, 1, 1);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            makeBigObj.SetActive(true);
            makeBigObj.transform.localScale = new Vector3(1, 1, 1);
            makeBigObj.transform.localPosition = new Vector3(0, 0, 0);
            gameObject.SetActive(false);
        }
    }
}
