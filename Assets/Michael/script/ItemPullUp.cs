using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPullUp : MonoBehaviour
{
    [SerializeField] private Image bigImag;

    [SerializeField] private GameObject getStuffedAnimalObj;
    [SerializeField] private GameObject getBirthdayCardObj;
    [SerializeField] private GameObject getSongRecObj;

    [SerializeField] private AudioRecManag audioRec;
    [SerializeField] private Image doneImag;
    [SerializeField] private Image loadingImag;
    [SerializeField] private TMP_Text loadingTxt;

    private void Start()
    {
        bigImag.gameObject.SetActive(false);
        
    }

    public void ItemPull()
    {
        if (!getStuffedAnimalObj.activeInHierarchy && !getBirthdayCardObj.activeInHierarchy && !getSongRecObj.activeInHierarchy)
        {
            ResetRecordingUI();
            bigImag.gameObject.SetActive(true);
            bigImag.gameObject.GetComponent<BigItem>().EnableDelayedInteraction();
            gameObject.SetActive(false);
        }
    }

    public void ResetRecordingUI()
    {
        doneImag.sprite = null;
        loadingTxt.text = null;
        loadingImag.fillAmount = 0;
        audioRec.isRecordingFinished = false;
    }
}
