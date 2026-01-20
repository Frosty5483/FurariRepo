using UnityEngine;

public class clickForBig : MonoBehaviour
{
    [SerializeField] private GameObject makeBigObj;

    void Start()
    {
        ResetBigObjectTransform(false);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResetBigObjectTransform(true);
        }
    }

    private void ResetBigObjectTransform(bool bigObjEnabled)
    {
        makeBigObj.SetActive(bigObjEnabled);
        makeBigObj.transform.localScale = new Vector3(1, 1, 1);
        makeBigObj.transform.localPosition = new Vector3(0, 0, 0);
        gameObject.SetActive(!bigObjEnabled);
    }
}
