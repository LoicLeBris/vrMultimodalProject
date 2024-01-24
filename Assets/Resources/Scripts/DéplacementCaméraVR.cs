using UnityEngine;

public class DeplacementCameraVR : MonoBehaviour
{
    public float vitesseMouvement = 3.0f;

    void Update()
    {
        // Récupérer les entrées des manettes
        float joystickHorizontal = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal");
        float joystickVertical = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical");

        // Calculer le déplacement en fonction des entrées des manettes
        Vector3 deplacement = new Vector3(joystickHorizontal, 0, joystickVertical) * vitesseMouvement * Time.deltaTime;

        // Appliquer le déplacement à la position de la caméra
        transform.Translate(deplacement, Space.World);
    }
}
