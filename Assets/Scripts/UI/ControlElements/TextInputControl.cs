
public class TextInputControl : ControlElement
{
    public void SubmitText(string txt)
    {
        float parsed = 0;
        if (float.TryParse(txt, out parsed))
        {
            base.SubmitFloat(parsed);
        }
    }
}
