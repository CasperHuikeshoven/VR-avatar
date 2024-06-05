using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintEraser : MonoBehaviour
{
    public Transform raycastTransform;
    public GameObject brushPreview;
    public GameObject paint;
    public LayerMask paintingLayerMask;
    public Renderer material;

    private XRGrabInteractable grabbable;
    private bool isPainting = false;
    GameObject paintList;
    public GameObject paintingList;

    void Start()
    {
        paintList = new GameObject("PaintList");
        paintList.transform.parent = paintingList.transform;
        grabbable = GetComponent<XRGrabInteractable>();
        if (grabbable != null)
        {
            grabbable.activated.AddListener(StartPainting);
            grabbable.deactivated.AddListener(StopPainting);
        }
        else
        {
            Debug.LogError("XRGrabInteractable component not found on " + gameObject.name);
        }
    }

    private void StartPainting(ActivateEventArgs arg)
    {
        isPainting = true;
        StartCoroutine(PaintCoroutine());
    }

    private void StopPainting(DeactivateEventArgs arg)
    {
        isPainting = false;
    }

    private IEnumerator PaintCoroutine()
    {
        while (isPainting)
        {
            Erase();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void Erase()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 0.3f))
        {
            if(hit.collider.gameObject.tag == "Paint"){
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
