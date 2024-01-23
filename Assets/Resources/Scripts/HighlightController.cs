using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GestionSurbrillanceBoutons : MonoBehaviour
{
    public GameObject[] objetsAControler;
    public GameObject[] objetsASurbriller;
    public Button[] boutons;
    public GameObject text;
    public static List<string> infos = new List<string> { "Une simple encyclopédie, elle comporte un maximum de connaissances dans un nombre de page limité", "Une canette de Coca... tient... on y trouve quelques traces de rouge à lèvres", "Une bobine de film ancienne, elle est inutilisable sur les télévisions récentes" };

    private int indexBoutonSelectionne = -1;

    void Start()
    {
        // Ajoute les écouteurs de clic aux boutons
        for (int i = 0; i < boutons.Length; i++)
        {
            int index = i; // Nécessaire pour éviter la capture de variable dans la boucle
            boutons[i].onClick.AddListener(() => OnBoutonClique(index));
        }
    }

    void OnBoutonClique(int index)
    {
        // Désactive la surbrillance de l'objet précédemment sélectionné
        DesactiverSurbrillance();

        // Active la surbrillance sur le nouvel objet sélectionné
        ActiverSurbrillance(index);
    }

    void ActiverSurbrillance(int index)
    {
        indexBoutonSelectionne = index;

        // Vérifie si l'index est valide
        if (indexBoutonSelectionne >= 0 && indexBoutonSelectionne < objetsAControler.Length && indexBoutonSelectionne < objetsASurbriller.Length)
        {
            GameObject objetSelectionne = objetsAControler[indexBoutonSelectionne];
            GameObject objetSurbrille = objetsASurbriller[indexBoutonSelectionne];

            Outline outlineButton = objetSelectionne.GetComponent<Outline>();
            outlineButton.enabled = true;

            Outline outline = objetSurbrille.GetComponent<Outline>();
            outline.enabled = true;

            TextMeshProUGUI textUI = text.GetComponent<TextMeshProUGUI>();
            textUI.text = infos[indexBoutonSelectionne];
        }
    }

    void DesactiverSurbrillance()
    {
        // Vérifie si l'index est valide
        if (indexBoutonSelectionne >= 0 && indexBoutonSelectionne < objetsAControler.Length && indexBoutonSelectionne < objetsASurbriller.Length)
        {
            GameObject objetSelectionne = objetsAControler[indexBoutonSelectionne];
            GameObject objetSurbrille = objetsASurbriller[indexBoutonSelectionne];

            Outline outlineButton = objetSelectionne.GetComponent<Outline>();
            outlineButton.enabled = false;

            Outline outline = objetSurbrille.GetComponent<Outline>();
            outline.enabled = false;
        }
    }
}
