using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private bool dragging;

    private Vector3 orgPosition, orgorgPosition;
    private Transform orgParent, FSBParent;

    private Friendshipbook fsb; //script

    private bool inTrigger;
    private bool inFSB;
    private float scalefactor = 1.2f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ReturnOrgOrgPosition();
        ReturnOrgParent();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(scalefactor, scalefactor, 1f);
        ReturnOrgPosition();
        ReturnDragging(true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (dragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            this.transform.position = mousePosition;
        }

        if (inTrigger && !inFSB)
        {
            //rectTransform.SetParent(orgParent);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.localScale = Vector3.one;
        ReturnDragging(false);
        if (!inTrigger)
        {
            rectTransform.localPosition = orgPosition;
        }
        else if (inTrigger)
        {
            if (inFSB)
            {
                if (FSBParent != null) { rectTransform.SetParent(FSBParent); rectTransform.localPosition = Vector3.zero; }
                else { rectTransform.localPosition = orgPosition; }
            }
            else
            {
                rectTransform.SetParent(orgParent);
                rectTransform.localPosition = orgorgPosition;
            }
        }
        bool isFilled = IsFilled();
        if (isFilled) { Evaluation(); }
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
        // "other.gameobject" is the object with the trigger, the "just gameobject" is the dragable one (means the photo)

        ReturnFSB();

        if (fsb.stammbaum.Contains(other.gameObject) && fsb.fsbPhotos.Contains(gameObject))
        {
            ReturnInTrigger(true);
            ReturnInFSB(true);

            if (other.gameObject.transform.childCount == 0)
            { ReturnFSBParent(other.gameObject.transform); }
            else
            { ReturnFSBParent(null); }
        }
        else if (other.gameObject.name == "FSBTrigger" && fsb.fsbPhotos.Contains(gameObject))
        {
            ReturnInTrigger(true);
            ReturnInFSB(false);
        }
        
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        // "other.gameobject" is the object with the trigger, the "just gameobject" is the dragable one (means the photo)

        ReturnFSB();

        if (fsb.stammbaum != null && fsb.fsbPhotos != null)
        {
            if (fsb.stammbaum.Contains(other.gameObject) && fsb.fsbPhotos.Contains(gameObject)) { ReturnInTrigger(false); }
        }
        else if (other.gameObject.name == "FSBTrigger" && fsb.fsbPhotos.Contains(gameObject))
        {
            ReturnInTrigger(false);
        }
    }

    private Friendshipbook ReturnFSB()
    {
        return fsb = FindFirstObjectByType<Friendshipbook>();
    }
    private bool ReturnInTrigger(bool x)
    {
        return inTrigger = x;
    }
    private bool ReturnInFSB(bool x)
    {
        return inFSB = x;
    }
    private Vector3 ReturnOrgOrgPosition()
    {
        return orgorgPosition = rectTransform.localPosition;
    }
    private Transform ReturnOrgParent()
    {
        return orgParent = this.gameObject.transform.parent;
        
    }
    private Transform ReturnFSBParent(Transform obj)
    {
        return FSBParent = obj;
    }

    private bool IsFilled()
    {
        foreach (GameObject obj in fsb.stammbaum)
        {
            if (obj.transform.childCount == 0)
            {
                return false;
            }
        }
        return true;
    }
    private void Evaluation()
    {
        Debug.Log("Checking if your solution is right...");
    }
}
