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
    public static List<string> infos = new List<string> { "Une simple encyclop�die, elle comporte un maximum de connaissances dans un nombre de page limit�", "Une canette de Coca... tient... on y trouve quelques traces de rouge � l�vres", "Une bobine de film ancienne, elle est inutilisable sur les t�l�visions r�centes" };

    private int indexBoutonSelectionne = -1;

    void Start()
    {
        for (int i = 0; i < boutons.Length; i++)
        {
            int index = i; 
            boutons[i].onClick.AddListener(() => OnBoutonClique(index));
        }
    }

    void OnBoutonClique(int index)
    {
        
        DesactiverSurbrillance();

        ActiverSurbrillance(index);
    }

    void ActiverSurbrillance(int index)
    {
        indexBoutonSelectionne = index;

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
