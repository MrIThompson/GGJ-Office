using UnityEngine;

/* 
 * Class for recieving tickets, and controlling the gamestate
 */
public class GameController : MonoBehaviour
{
    public Ticket currentTicket;
    public Scooter scooter;
    private TicketParser ticketParser;

    /*
     * Why am I documenting this?
     */
    void Start()
    {
        ticketParser = GetComponent<TicketParser>();

        ticketParser.parseTickets();

        updateTicket();


    }

    /*
     * Updates the current ticket with a new ticket;
     */
    void updateTicket()
    {
        currentTicket = ticketParser.getTicket();


        beginCall();
    }

    public Ticket GetTicket()
    {
        return currentTicket;
    }

    public void beginCall()
    {
        scooter = GetComponent<Scooter>();
        scooter.Begin();
    }


}
