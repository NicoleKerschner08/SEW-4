namespace RestApiBook
{
    public class CounterService
    {
        private int counter = 0;

        public void Increment()
        {
            counter++;
        }   

        public int GetCounter()
        {
            return counter;
        }
    }
}
