using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Scooter : MonoBehaviour
{
    public List<Affector> affectors;
    Ticket ticket;

    public void Begin()
    {
        GameController gameController = GetComponent<GameController>();

        ticket = gameController.GetTicket();

        foreach (Affector affector in affectors)
        {

            if (affector.type == ticket.problemArea)
            {
                affector.targetValue = ticket.successValue;
            }
            else
            {
                affector.targetValue = -1;
            }
        }
    }



}
