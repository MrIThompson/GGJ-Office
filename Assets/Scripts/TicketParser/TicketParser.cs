using UnityEngine;

/*
 * Class for parsing help tickets from characters/customers
 */
public class TicketParser : MonoBehaviour
{

    public TextAsset ticketJson;
    public Tickets parsedTickets;

    public void parseTickets()
    {
        parsedTickets = JsonUtility.FromJson<Tickets>(ticketJson.text);
    }

    /*
    * Fetches and returns a parsed new instance of Ticket
    */
    public Ticket getTicket()
    {
        return parsedTickets.tickets[Random.Range(0, parsedTickets.tickets.Length)];
    }
}
