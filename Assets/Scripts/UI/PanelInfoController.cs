using UnityEngine;

public class PanelInfoController : MonoBehaviour
{
    [SerializeField]
    private RectTransform thisRectTransform;
    [SerializeField]
    private Vector3 offSet;

    private Camera mainCamera;
    private Transform targetFollow;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void SetTarget(Transform targetFollow)
    {
        this.targetFollow = targetFollow;
    }

    private void Update()
    {
        if (targetFollow) thisRectTransform.position = mainCamera.WorldToScreenPoint(targetFollow.position + offSet);
    }
}
