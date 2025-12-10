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

    [Header("Other")]
    [SerializeField] private Image doneImag;
    [SerializeField] private Image loadingImag;
    [SerializeField] private TMP_Text loadingTxt;

    private bool stuffedDone;
    private bool birthdayDone;
    private bool songrecDone;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("StuffedAnimal").activeInHierarchy)
        {
            RecordingAudio(animal_Clip, stuffedDone, animalSpr);
        }

        if (GameObject.FindGameObjectWithTag("BirthdayCard").activeInHierarchy)
        {
            RecordingAudio(birthday_Clip, birthdayDone, birthdaySpr);
        }

        if (GameObject.FindGameObjectWithTag("SongRec").activeInHierarchy)
        {
            RecordingAudio(songrec_Clip, songrecDone, songrecSpr);
        }
    }

    void RecordingAudio(AudioClip audioClip, bool isRecorded, Sprite doneSpr)
    {
        StartCoroutine(LoadingAudio());

        if(loadingImag.fillAmount == 1)
        {
            isRecorded = true;
            doneImag.sprite = doneSpr;
        }
    }

    IEnumerator LoadingAudio()
    {
        loadingTxt.text = "Loading...";
        for (int i = 0; i <= 100; i++)
        {
            loadingImag.fillAmount = i / 100;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
