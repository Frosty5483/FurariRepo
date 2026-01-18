using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private bool dragging;

    private Vector3 orgPosition, fsbposition;
    private Transform FSBParent, StammbaumFieldParent;

    private Friendshipbook fsbScript;

    private bool inTrigger;
    private bool inStammbaumField;
    private float scalefactor = 1.2f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ReturnFsbPosition();
        ReturnFSBParent();
        ReturnFSBScript();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector3(scalefactor, scalefactor, 1f);
        ReturnOrgPosition();
        ReturnDragging(true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (dragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            this.transform.position = mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.localScale = Vector3.one;
        transform.GetChild(0).gameObject.SetActive(true);
        ReturnDragging(false);
        if (!inTrigger)
        {
            rectTransform.localPosition = orgPosition;
        }
        else if (inTrigger)
        {
            if (inStammbaumField)
            {
                if (StammbaumFieldParent != null) { rectTransform.SetParent(StammbaumFieldParent); rectTransform.localPosition = Vector3.zero; Transform child = rectTransform.GetChild(0);
                    child.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -70f, 0); child.GetComponent<Text>().alignment = TextAnchor.MiddleCenter; child.GetComponent<Text>().color = Color.white;
                    child.GetComponent<Text>().fontSize = 18;
                }
                else { rectTransform.localPosition = orgPosition; }
            }
            else
            {
                rectTransform.SetParent(FSBParent);
                rectTransform.localPosition = fsbposition;
                Transform child = rectTransform.GetChild(0);
                child.GetComponent<RectTransform>().anchoredPosition = new Vector3(260f, 0, 0); child.GetComponent<Text>().alignment = TextAnchor.MiddleCenter; child.GetComponent<Text>().color = Color.black;
                child.GetComponent<Text>().fontSize = 37;
            }
        }
        bool isFilled = StammbaumIsFull();
        if (isFilled) { bool isRight = Evaluation(); Debug.Log("You Solution is " + isRight); RoomManager roomManager = FindFirstObjectByType<RoomManager>(); roomManager.RoomCompleted(0); }
    }

    private bool ReturnDragging(bool x)
    {
        return dragging = x;
    }

    private Vector3 ReturnOrgPosition()
    {
        return orgPosition = gameObject.GetComponent<RectTransform>().localPosition;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (fsbScript.stammbaumFields.Contains(other.gameObject) && fsbScript.fsbPhotos.Contains(gameObject))
        {
            ReturnInTrigger(true);
            ReturnInStammbaumField(true);

            if (other.gameObject.transform.childCount == 0)
            { ReturnStammbaumParent(other.gameObject.transform); }
            else
            { ReturnStammbaumParent(null); }
        }
        else if (other.gameObject.name == "FSBTrigger" && fsbScript.fsbPhotos.Contains(gameObject))
        {
            ReturnInTrigger(true);
            ReturnInStammbaumField(false);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {

        if (fsbScript != null)
        {
            if (fsbScript.stammbaumFields.Contains(other.gameObject) && fsbScript.fsbPhotos.Contains(gameObject)) { ReturnInTrigger(false); }
        }
        else if (other.gameObject.name == "FSBTrigger" && fsbScript.fsbPhotos.Contains(gameObject))
        {
            ReturnInTrigger(false);
        }
    }
    private Friendshipbook ReturnFSBScript()
    {
        return fsbScript = FindFirstObjectByType<Friendshipbook>();
    }
    private bool ReturnInTrigger(bool x)
    {
        return inTrigger = x;
    }
    private bool ReturnInStammbaumField(bool x)
    {
        return inStammbaumField = x;
    }
    private Vector3 ReturnFsbPosition()
    {
        return fsbposition = rectTransform.localPosition;
    }
    private Transform ReturnFSBParent()
    {
        return FSBParent = this.gameObject.transform.parent;
        
    }
    private Transform ReturnStammbaumParent(Transform transform)
    {
        return StammbaumFieldParent = transform;
    }

    private bool StammbaumIsFull()
    {
        foreach (GameObject field in fsbScript.stammbaumFields)
        {
            if (field.transform.childCount == 0)
            {
                return false;
            }
        }
        return true;
    }
    private bool Evaluation()
    {
        Debug.Log("Checking if your solution is right...");
        foreach (GameObject field in fsbScript.stammbaumFields)
        {
            if (field.transform.GetChild(0).name != fsbScript.fsbPhotos[fsbScript.stammbaumFields.IndexOf(field)].name)
            {
                return false;
            }
        }
        return true;
    }
}
