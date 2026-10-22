using UnityEngine;

public class Board : MonoBehaviour
{
    public Transform[] Box; // c'est le tableau

    public Vector3 getCellPosition(int BoxNumber) //récupère la position physique des cases en fonction de l'index donné
    {
        return Box[BoxNumber].position;
    }
    
    public int GetCellMove(int BoxNumber)
    {
        BoxBonus Bonus = Box[BoxNumber].GetComponent<BoxBonus>(); //Cherche si BoxBonus est dans la case

        if (Bonus == null) return 0; //Si il n'y en a pas reste à 0

        return Bonus.Move; //Si il y en a on lis le nombre associé
    }

    void Awake()
    {
        Box = new Transform[transform.childCount]; // une boîte avec autant de trous que d'enfants

        for (int i = 0; i < transform.childCount; i++)
        {
            Box[i] = transform.GetChild(i); // on range chaque enfant dans son trou
        }
    }
}

