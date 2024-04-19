namespace Pa_Evidence.Pages
{
    public partial class EvidenceV0
    {
        public Models.Polozka Polozka { get; set; } = new Models.Polozka();
        
        public List<Models.Polozka> PolozkyList { get; set; } = new List<Models.Polozka>();
        
        private void Pridat(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
            //PolozkyList.Add(Polozka);
            PolozkyList.Add(new Models.Polozka(Polozka.Datum, Polozka.Naklady, Polozka.Vynosy));
        }
    }
}
