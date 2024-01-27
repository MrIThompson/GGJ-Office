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
     * Emergency Eject
     * Wheels
     * Lock
     * Battery
     * Joystick
     * Seat Warmer
     * Broken Straw
     * Flat Cushion
     * Seat Pos
     * Back Pos
     */
    public string problemArea;
    // 0 to 1
    public float successValue;

}
