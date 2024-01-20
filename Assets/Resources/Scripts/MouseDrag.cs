using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.y*5, Input.mousePosition.x*3, Camera.main.transform.position.z*5);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
        rb.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.y*5, Input.mousePosition.x*3, Camera.main.transform.position.z*5);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
        transform.position = objPosition;
       
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }

     private void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.up * wheelInput * 5.0f, Space.World);
    }
}
