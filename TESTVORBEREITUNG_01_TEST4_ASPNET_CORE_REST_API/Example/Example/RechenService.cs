namespace Example
{
    public class RechenService
    {
        public void Rechnen(Rechnung rechnung)
        {
            switch (rechnung.op)
            {
                case "+":
                    rechnung.Ergebnis = rechnung.Zahl1 + rechnung.Zahl2;
                    break;
                case "-":
                    rechnung.Ergebnis = rechnung.Zahl1 - rechnung.Zahl2;
                    break;
                case "*":
                    rechnung.Ergebnis = rechnung.Zahl1 * rechnung.Zahl2;
                    break;

            }
        }
    }
}
