using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class CurrentBox : MonoBehaviour
{
    public float StepDelay = 5f; //Durée avant la fin de l'animation du mouvement du pion
    public Board board; //Récupère le plateau
    public PlayerData data; // Conservation de la position du joueur dans le PlayerData
    
    public UnityEvent<int> NewPosition;
    
    private bool isMoving = false;
    public void GetForward(int Result) //récupère le résultat du dé
    {
        if (isMoving) return; // vérifie que le pion ne soit pas en mouvement
        StartCoroutine(Walk(Result));
    }
    
    void Start()
    {
        data.Position = 0; // pour l'instant le pion commence toujours à zéro en début de partie
        NewPosition.Invoke(data.Position); // on va à la case écrite dans la boîte
    }

    IEnumerator Walk(int Result) //coroutine
    {
        isMoving = true;
        int direction = 1; // incrément par lequel le pion bouge 1 en avant -1 en arrière 
        
        if (Result < 0) //Demande si le nombre est négatif
        {
            direction = -1;     //Change la direction dans laquelle on va
            Result = -Result;   //Récupère le nombre négatif et le met en positif
        }

        for (int i = 0; i < Result; i++) //fais l'effet tant que i est inférieur au résultat du dé
        {
            if (data.Position == 63) direction = -1; // Change direction si on dépasse 63 pour faire reculer

            data.Position = data.Position + direction; // avance de 1
            NewPosition.Invoke(data.Position); // Envoie un message au pion pour le faire avancer

            yield return new WaitForSeconds(StepDelay); // attend le temps de l'animation du pion
        }
        
        int move = board.GetCellMove(data.Position); // Regarde le bonus de la case

        if (move != 0) //Agis si le bonus n'est pas zéro
        {
            yield return new WaitForSeconds(0.5f);   //pause avant d'avancer à nouveau
            yield return StartCoroutine(Walk(move)); //Relance la coroutine marche
            yield break; //Mets fin a la coroutine et lance le délai pour la victoire ou pour relancer un dé
        }

        if (data.Position == 63)
        {
            Debug.Log("You Win");
            data.Position = 0; //Reset la position du joueur à zéro
        }

        yield return new WaitForSeconds(0.5f);
        Debug.Log("Roll Again");
        isMoving = false; //on peut lancer le dé à nouveau 
    }
}