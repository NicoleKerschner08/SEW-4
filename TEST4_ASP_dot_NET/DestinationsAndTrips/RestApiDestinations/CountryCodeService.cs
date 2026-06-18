namespace RestApiDestinations
{
    public class CountryCodeService
    {
        public string GetCountryCode(string country)
        {
            if (country == "Oesterreich")
            {
                return " - AT";
            }
            else if (country == "Frankreich")
            {
                return " - FR";
            }
            else if (country == "Deutschland")
            {
                return " - DE";
            }
            else return "??";
        }

    }
}
