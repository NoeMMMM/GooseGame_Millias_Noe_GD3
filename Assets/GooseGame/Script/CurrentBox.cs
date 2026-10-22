using NUnit.Framework.Internal.Filters;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class CurrentBox : MonoBehaviour
{
    public int CurentBox; //Note la position actuel du joueur 
    public int Remove; //Garde en mémoire le montant à enlever du resultat de dé
    public int DistEnd; //Calcule la distance avec la fin du jeu 
    public UnityEvent<int> NewPosition;
    public void GetForward(int Result) //récupère le résultat du dé
    {
        if (CurentBox + Result > 63) //recul si au dessus
        {
            Remove = CurentBox + Result - 63;
            DistEnd = 63 - CurentBox;
        }
        else if (CurentBox + Result == 63) //Win si ça arrive
        {
            CurentBox = CurentBox+Result;
        }
        else //avance sur le plateau
        {
            CurentBox = CurentBox+Result; //ajoute le resultat du lancer de dé
        }
        
        Debug.Log(CurentBox);
        NewPosition.Invoke(CurentBox); // Envoie la nouvelle position au player  
    }
}
