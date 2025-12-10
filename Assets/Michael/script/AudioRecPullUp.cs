using UnityEngine;

public class AudioRecPullUp : MonoBehaviour
{
    public GameObject audioRec;

    private bool shown;

    private void Start()
    {
        if (shown)
        {
            audioRec.SetActive(true);
        }
        if (!shown)
        {
            audioRec.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!shown)
            {
                audioRec.SetActive(true);
                shown = true;
            }
            else if (shown)
            {
                audioRec.SetActive(false);
                shown = false;
            }
        }
    }

    
}
