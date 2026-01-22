using Unity.VisualScripting;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private GameObject bigItem;
    private GameObject button;
    [SerializeField] private GameObject thisButton;

    private void Awake()
    {
        FindObjects();
    }
    public void Exit()
    {
        bigItem.SetActive(false);
        button.SetActive(false);
        bigItem.GetComponent<BigItem>().ExitBigItemView();
        thisButton.SetActive(false);
    }

    private void FindObjects()
    {
        if (GameObject.FindGameObjectWithTag("StuffedAnimal").active)
        {
            bigItem = GameObject.FindGameObjectWithTag("StuffedAnimal");
        }
        if (GameObject.FindGameObjectWithTag("BirthdayCard").active)
        {
            bigItem = GameObject.FindGameObjectWithTag("BirthdayCard");
        }
        if (GameObject.FindGameObjectWithTag("SongRec").active)
        {
            bigItem = GameObject.FindGameObjectWithTag("SongRec");
        }

        if (GameObject.FindGameObjectWithTag("AnimalButton").active)
        {
            button = GameObject.FindGameObjectWithTag("AnimalButton");
        }
        if (GameObject.FindGameObjectWithTag("BirthdayButton").active)
        {
            button = GameObject.FindGameObjectWithTag("BirthdayButton");
        }
        if (GameObject.FindGameObjectWithTag("SongButton").active)
        {
            button = GameObject.FindGameObjectWithTag("SongButton");
        }
    }

    private void Update()
    {
        FindObjects();
    }
}
