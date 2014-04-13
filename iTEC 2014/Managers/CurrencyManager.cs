namespace iTEC2014
{
    enum Currency { RON }
    static class CurrencyManager
    {
        public static Currency Current { get; private set; }
        public static string Name { get; private set; }

        static CurrencyManager()
        {
            Current = Currency.RON;
            Name = Strings.CurrencyRon;
        }
    }
}
