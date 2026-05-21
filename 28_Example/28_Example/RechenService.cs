namespace _28_Example
{
    public class RechenService
    {
        public void Berechnen(Rechnung rechnung)
        {
            switch (rechnung.Op)
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
                case "/":
                    rechnung.Ergebnis = rechnung.Zahl1 / rechnung.Zahl2;
                    break;
                
            }
        }
    }
}
