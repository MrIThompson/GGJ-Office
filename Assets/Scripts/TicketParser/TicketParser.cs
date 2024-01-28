using UnityEngine;

/*
 * Class for parsing help tickets from characters/customers
 */
public class TicketParser : MonoBehaviour
{

    public TextAsset ticketJson;
    public Tickets parsedTickets;
    private bool firstCall = true;

    public void parseTickets()
    {
        parsedTickets = JsonUtility.FromJson<Tickets>(ticketJson.text);
    }

    /*
    * Fetches and returns a parsed new instance of Ticket
    */
    public Ticket getTicket()
    {
        if (firstCall)
        {
            firstCall = false;
            return parsedTickets.tickets[0];
        }


        return parsedTickets.tickets[Random.Range(1, parsedTickets.tickets.Length)];
    }
}
