using UnityEngine;

public class ActivityDragAndDrop : MonoBehaviour
{
    [SerializeField]
    private SetActivity setActivity;

    private Plane dragPlane;
    private Vector3 offSet;
    private Camera myMainCamera;
    private Ray camRay;
    private float planeDist;
    private Vector3 beginPosition;

    private void Awake()
    {
        myMainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        dragPlane.Raycast(camRay, out planeDist);
        offSet = transform.position - camRay.GetPoint(planeDist);
        beginPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offSet;
    }

    private void OnMouseUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10.0f))
        {
            if (setActivity.ApplyActivity(hit.transform))
            {
                gameObject.SetActive(false);
            }
            else
            {
                transform.position = beginPosition;
            }
        }
    }
}
