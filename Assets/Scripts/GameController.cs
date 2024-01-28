using UnityEngine;

/* 
 * Class for recieving tickets, and controlling the gamestate
 */
public class GameController : MonoBehaviour
{
    public Ticket currentTicket;
    public Scooter scooter;
    private TicketParser ticketParser;

    public PhoneController PhoneController;
    public ComputerUiController ComputerController;

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
        PhoneController.StartPhoneCall();
    }

    public Ticket GetTicket()
    {
        return currentTicket;
    }

    public void BeginCall()
    {
        scooter = GetComponent<Scooter>();
        scooter.Begin();
        ComputerController.SetRemote(GetTicket());
        PhoneController.StartPhoneConvo(GetTicket());
    }

    public void CompleteCall()
    {
        ComputerController.CompleteCall();
        PhoneController.CompleteCall();
        Invoke(nameof(updateTicket), 5);
    }


}
