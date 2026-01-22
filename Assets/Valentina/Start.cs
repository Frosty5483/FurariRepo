using UnityEngine;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject InstagramScreen;
    [SerializeField] private GameObject Startscreen;
    [SerializeField] private GameObject StartUI;

    public void ChangeScreen (int x)
    {
        if (x == 0) { InstagramScreen.SetActive (true); Startscreen.SetActive (false); }
        else InstagramScreen.SetActive(false); Startscreen.SetActive(true);
    }

    public void EnablestartUI()
    {
        StartUI.SetActive (true);
    }
}
