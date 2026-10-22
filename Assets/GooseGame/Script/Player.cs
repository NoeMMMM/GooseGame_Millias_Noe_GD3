using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Board board; //récupère le board et la liste de box à l'intérieur
    public float Speed = 0.3f; //Vitesse de mouvement du pion
    private Vector3 target; //Prochaine emplacement du pion
    public PlayerData data; // la boîte à trésor

    
    void Awake()
    {
        target = transform.position; // position de départ
    }
    public void MoveTo(int BoxNumber)
    {
        target = board.getCellPosition(BoxNumber);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime); 
        //fais bouger le pion vers la target depuis ça position de départ dans le temps qu'on lui donne 
    }
    
    
}
