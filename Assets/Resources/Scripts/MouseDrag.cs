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
        // Convertir la position de la souris en un rayon dans la scène
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Vérifier s'il y a une collision avec un objet
        if (Physics.Raycast(ray, out hit))
        {
            // Stocker l'offset entre la position de l'objet et le point de collision
            offset = transform.position - hit.point;
            rb.isKinematic = true;
        }
    }

    private void OnMouseDrag()
    {
        // Convertir la position de la souris en un rayon dans la scène
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Vérifier s'il y a une collision avec un objet
        if (Physics.Raycast(ray, out hit))
        {
            // Mettre à jour la position de l'objet en fonction du point de collision et de l'offset
            transform.position = hit.point + offset;
        }
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }



    private void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.up * wheelInput, Space.World);

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
