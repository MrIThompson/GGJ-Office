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

    public float winTollerance = 0.15f;

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

    public void UpdateAffector(string affector, float value)
    {
        foreach (Affector v in scooter.affectors)
        {
            if (v.type == affector)
            {
                v.currentValue = value;
                if (v.targetValue != -1)
                {


                    if (Mathf.Abs(v.targetValue - v.currentValue) < winTollerance)
                    {
                        //Success
                        this.CompleteCall(true);
                    }
                }
            }

        }


    }

    public void BeginCall()
    {
        scooter = GetComponent<Scooter>();
        scooter.Begin();
        ComputerController.SetRemote(GetTicket());
        PhoneController.StartPhoneConvo(GetTicket());
    }

    public void CompleteCall(bool win)
    {
        ComputerController.CompleteCall();
        PhoneController.CompleteCall(win);
        Invoke(nameof(updateTicket), 5);
    }


}
