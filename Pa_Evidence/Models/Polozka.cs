namespace Pa_Evidence.Models
{
    public class Polozka
    {
        private int naklady = 10;
        private int vynosy;

        public Polozka() 
        {
            Datum = DateOnly.FromDateTime(DateTime.Today);
        }
        public Polozka(DateOnly datum, int naklady, int vynosy, string popis)
        {
            Datum = datum;
            Naklady = naklady;
            Vynosy = vynosy;
            Popis = popis;
        }
        public DateOnly Datum { get; set; }
        public int Naklady
        {
            get => naklady; set
            {
                naklady = Math.Abs(value);
            }
        }
        public int Vynosy
        {
            get => vynosy; set
            {
                if (value < 0) 
                {
                    vynosy = 0;
                }
                else
                {
                    vynosy = value;
                }
            }
        }
        public string Popis { get; set; }
        public int Zisk => Vynosy - Naklady;
    }
}
