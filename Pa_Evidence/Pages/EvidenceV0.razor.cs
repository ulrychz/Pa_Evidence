using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Pa_Evidence.Models;

namespace Pa_Evidence.Pages
{
    public partial class EvidenceV0
    {
        public Models.Polozka Polozka { get; set; } = new Models.Polozka();
        
        public List<Models.Polozka> PolozkyList { get; set; } = new List<Models.Polozka>();
        public List<Polozka> PolozkyFiltrList { get; private set; } = new List<Polozka>();

        public bool JeEditace { get; set; } = false;
        public bool JeFiltrace { get; set; } = false;
        public string VybranyFiltr { get; set; } = ">";
        public double FiltrHodnota { get; set; }
        public string FiltrPopis { get; set; } = "";

        private void Pridat(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
            //PolozkyList.Add(Polozka);
            PolozkyList.Add(new Models.Polozka(Polozka.Datum, Polozka.Naklady, Polozka.Vynosy, Polozka.Popis));
        }

        private async Task SmazatZaznam(Models.Polozka polozka)
        {
            //polozka.Vynosy = 100;
            string zprava = $"Chcete odebrat {polozka.Datum} - zisk: {polozka.Zisk}";

            if (await JS.InvokeAsync<bool>("confirm",zprava))
            {
                PolozkyList.Remove(polozka);
            }
        }

        private void EditujZaznam(Models.Polozka pol)
       
        {
            Polozka = pol;
            JeEditace = true;
        }
        private void UkonciEditaci()
        {
            JeEditace = false;
            Polozka = new Models.Polozka();
        }

        public void FiltrujPolozky()
        {
            switch (VybranyFiltr)
            {
                case "<":
                    PolozkyFiltrList = PolozkyList.Where(x => x.Zisk < FiltrHodnota).ToList();
                    break;
                case ">":
                    PolozkyFiltrList = PolozkyList.Where(x => x.Zisk > FiltrHodnota).ToList();
                    break;
                case "=":
                    PolozkyFiltrList = PolozkyList.Where(x => x.Zisk == FiltrHodnota).ToList();
                    break;

            }
            if (FiltrPopis != string.Empty)
            {
                PolozkyFiltrList = PolozkyFiltrList.Where(x => x.Popis.Contains(FiltrPopis)).ToList();

            }
        }
    }
}
