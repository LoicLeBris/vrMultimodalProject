using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    private Material originalMaterial;
    public Material highlightMaterial;

    private void Start()
    {
        // Sauvegarder le mat�riau d'origine de l'objet
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void ActiverSurbrillance()
    {
        // Appliquer le mat�riau de surbrillance
        GetComponent<Renderer>().material = highlightMaterial;
    }

    public void DesactiverSurbrillance()
    {
        // Revenir au mat�riau d'origine
        GetComponent<Renderer>().material = originalMaterial;
    }
}