using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class Dice : MonoBehaviour
{
    public UnityEvent<int> LaunchDice;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            int Result = Random.Range(2, 13); //résultat entre 1 et 12
            Debug.Log(Result);
            LaunchDice.Invoke(Result); //invoke et envoie le résultat au player
        }
    }
}
