using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioRecManag : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip animal_Clip;
    [SerializeField] private AudioClip birthday_Clip;
    [SerializeField] private AudioClip songrec_Clip;

    [Header("Graphics")]
    [SerializeField] private Sprite animalSpr;
    [SerializeField] private Sprite birthdaySpr;
    [SerializeField] private Sprite songrecSpr;

    [Header("AudioRecObjs")]
    [SerializeField] private GameObject stuffedAnimalObj;
    [SerializeField] private GameObject birthdayCardObj;
    [SerializeField] private GameObject songRecObj;

    [Header("Other")]
    [SerializeField] private Image doneImag;
    [SerializeField] private Image loadingImag;
    [SerializeField] private TMP_Text loadingTxt;

    [Header("bools")]
    [SerializeField] private bool stuffedDone;
    [SerializeField] private bool birthdayDone;
    [SerializeField] private bool songrecDone;

    public bool isLoadingStarted;
    public bool isRecordingFinished;

    private void Update()
    {
        if (stuffedAnimalObj.activeInHierarchy)
        {
            
            RecordingAudio(animal_Clip, stuffedDone, animalSpr);
        }

        if (birthdayCardObj.activeInHierarchy)
        {
            RecordingAudio(birthday_Clip, birthdayDone, birthdaySpr);
        }

        if (songRecObj.activeInHierarchy)
        {
            RecordingAudio(songrec_Clip, songrecDone, songrecSpr);
        }
    }

    void RecordingAudio(AudioClip audioClip, bool isRecorded, Sprite doneSpr)
    {
        if (isLoadingStarted == false && isRecordingFinished == false)
        {
            StartCoroutine(LoadingAudio());
            isLoadingStarted = true;
        }
        
        if(loadingImag.fillAmount == 1)
        {
            Debug.Log("sprite");
            isRecorded = true;
            doneImag.sprite = doneSpr;
            loadingTxt.text = "Done!";
            isRecordingFinished = true;
            isLoadingStarted = false;
            if(stuffedAnimalObj.activeInHierarchy)
                stuffedDone = true;
            if(birthdayCardObj.activeInHierarchy)
                birthdayDone = true;
            if(songRecObj.activeInHierarchy)
                songrecDone = true;
        }
    }

    IEnumerator LoadingAudio()
    {
        loadingTxt.text = "Loading...";
        for (int i = 0; i <= 100; i++)
        {
            loadingImag.fillAmount += 0.01f;
            Debug.Log("Loading" + i + "fill: " + loadingImag.fillAmount);
            yield return new WaitForSeconds(0.1f);
            if(!stuffedAnimalObj.activeInHierarchy && !birthdayCardObj.activeInHierarchy && !songRecObj.activeInHierarchy)
            {
                i = 0;
                loadingImag.fillAmount = 0;
                isLoadingStarted = false;
                StopAllCoroutines();
            }
        }
    }
}
