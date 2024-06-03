using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintBrush : MonoBehaviour
{
    public Transform raycastTransform;
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
            Paint();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void Paint()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, 0.3f, paintingLayerMask))
        {
            GameObject painted = Instantiate(paint, hit.point, Quaternion.identity);
            painted.transform.parent = paintList.transform;
            Renderer renderer = painted.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial = material.sharedMaterial;
            }
            else
            {
                Debug.LogError("Paint prefab does not have a Renderer component.");
            }
        }
    }

    public void ClearPainting(){
        paintList.SetActive(false);
        paintList = new GameObject("PaintList");
        paintList.transform.parent = paintingList.transform;
    }
}
