using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 offset;
    private float lastScaleTime;
private float scaleTimeout = .05f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.y * 5, Input.mousePosition.x * 3, Camera.main.transform.position.z * 5);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
        rb.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.y * 5, Input.mousePosition.x * 3, Camera.main.transform.position.z * 5);
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

         if (Time.time - lastScaleTime > scaleTimeout)
    {
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("P pressed");
            ScaleObject(1.1f);
            lastScaleTime = Time.time;  
        }
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("M pressed");
            ScaleObject(0.9f);
            lastScaleTime = Time.time;
        }
    }
    }

    private void ScaleObject(float scaleFactor)
    {
        transform.localScale = transform.localScale * scaleFactor;
    }
}
