using System;
namespace ProjectoVacinacao.Model.ViewModel
{
    public class ElegivelViewModel
    {
        public ElegivelViewModel(int fId, string fNomeCompleto, string fCpf, string fTelefone, string fEmail, int fIdade)
        {
            FId = fId;
            FNomeCompleto = fNomeCompleto;
            FCpf = fCpf;
            FTelefone = fTelefone;
            FEmail = fEmail;
            FIdade = fIdade;
        }

        public int FId { get; set; }

        public string FNomeCompleto { get; set; }

        public string FCpf { get; set; }

        public string FTelefone { get; set; }

        public string FEmail { get; set; }

        public int FIdade { get; set; }
    }
}
