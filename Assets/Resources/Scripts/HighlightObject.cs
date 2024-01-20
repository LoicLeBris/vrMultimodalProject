using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    private Material originalMaterial;
    public Material highlightMaterial;

    private void Start()
    {
        // Sauvegarder le matériau d'origine de l'objet
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void ActiverSurbrillance()
    {
        // Appliquer le matériau de surbrillance
        GetComponent<Renderer>().material = highlightMaterial;
    }

    public void DesactiverSurbrillance()
    {
        // Revenir au matériau d'origine
        GetComponent<Renderer>().material = originalMaterial;
    }
}