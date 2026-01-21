using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageShower : MonoBehaviour
{
    [SerializeField] private GameObject image;

    private void Start()
    {
        image.SetActive(false);
    }


    public void ChangeState()
    {
        image.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
