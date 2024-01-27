using UnityEngine;

/*
 * Class for parsing help email from characters/customers
 */
public class EmailParser : MonoBehaviour
{

    public TextAsset emailJson;
    public Emails parsedEmails;

    public void Start()
    {
        parsedEmails = JsonUtility.FromJson<Emails>(emailJson.text);
    }

    /*
    * Fetches and returns a parsed new instance of Ticket
    */
    public string getEmail()
    {
        if (parsedEmails != null)
        {
            return parsedEmails.emails[Random.Range(0, parsedEmails.emails.Length)];
        }
        return "Linked: Congratulate Bob";
    }
}
