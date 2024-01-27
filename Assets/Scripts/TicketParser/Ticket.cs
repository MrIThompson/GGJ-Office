[System.Serializable]

/* 
 * A character/customer ticket
 */
public class Ticket
{
    public string id;
    public string characterName;
    public string[] problem;
    public string[] cannedResponses;
    public string[] successText;
    public string[] failureText;

    /* Problem areas area as follows:
     * "eject"
     * "wheels"
     * "brake"
     * "battery"
     * "joystick"
     * "seatWarm"
     * "straw"
     * "cushion"
     * "seat"
     * "back"
     * "tiller"
     */
    public string problemArea;
    // 0 to 1
    public float successValue;

}
