using System;
namespace ProjectoVacinacao.ViewModel
{
    public class ElegivelListaViewModel
    {
        public ElegivelListaViewModel(int fId, string fNomeCompleto, string fEmail, string fTelefone)
        {
            FId = fId;
            FNomeCompleto = fNomeCompleto;
            FEmail = fEmail;
            FTelefone = fTelefone;
        }

        public int FId { get; set; }
        public string FNomeCompleto { get; set; }
        public string FEmail { get; set; }
        public string FTelefone { get; set; }

    }
}
