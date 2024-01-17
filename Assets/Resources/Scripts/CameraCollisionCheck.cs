using UnityEngine;

public class CameraCollisionCheck : MonoBehaviour
{
    public LayerMask whatIsGrabbable;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Camera collided with: " + collision.gameObject.name);

        if ((whatIsGrabbable == collision.gameObject.layer))
        {
            Debug.Log("Camera collided with grabbable object: " + collision.gameObject.name);
        }
    }
}
