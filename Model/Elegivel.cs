using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProjectoVacinacao.Data;

namespace ProjectoVacinacao.Model
{
    public class Elegivel
    {
    
        public int FId { get; set; }

        public string FNomeCompleto { get; set; }

        public string FCpf { get; set; }

        public string FTelefone { get; set; }

        public string FEmail { get; set; }

        public int FIdade { get; set; }

        private readonly DbContext _dbContext;

        public Elegivel()
        {
            _dbContext = new DbContext();
        }

        public List<Elegivel> ListarElegivel()
        {
            var db = File.ReadAllText(_dbContext.CaminhoBanco());

            var listaElegivel = JsonConvert.DeserializeObject<List<Elegivel>>(db);

            return listaElegivel;

        }

        public bool AtualizarDbEle(List<Elegivel> listaElegivel)
        {
            var json = JsonConvert.SerializeObject(listaElegivel, Formatting.Indented);
            File.WriteAllText(_dbContext.CaminhoBanco(), json);
            return true;
        }

        public Elegivel AlterarElegivel(int id, Elegivel elegivel)
        {
            var listaElegivel = this.ListarElegivel();

            var itemIndex = listaElegivel.FindIndex(r => r.FId == id);

            if (itemIndex >= 0)
            {
                elegivel.FId = id;
                listaElegivel[itemIndex] = elegivel;

            }else
            {
                return null;
            }

            AtualizarDbEle(listaElegivel);
            return elegivel;
        }

        public Elegivel InserirElegivel(Elegivel elegivel)
        {
            var listaElegivel = this.ListarElegivel();

            var maxId = listaElegivel.Max(r => r.FId);

            elegivel.FId = maxId + 1;
            listaElegivel.Add(elegivel);

            AtualizarDbEle(listaElegivel);
            return elegivel;         
        }

        public bool DeletarElegivel(int id)
        {
            var listaElegivel = this.ListarElegivel();

            var itemIndex = listaElegivel.FindIndex(r => r.FId == id);

            if (itemIndex >= 0)
            {
                listaElegivel.RemoveAt(itemIndex);
            } else
            {
                return false;
            }

            AtualizarDbEle(listaElegivel);
            return true; 

        }

        public Elegivel PesquisarPorNome(string nome)
        {
            var listaElegivel = this.ListarElegivel();

            var elegivel = listaElegivel.Where(r => r.FNomeCompleto == nome).FirstOrDefault();

            return elegivel;
        }

        public IEnumerable<Elegivel> PesquisarParteNome(string nome)
        {
            var listaElegivel = this.ListarElegivel();

            var elegivel = listaElegivel.Where(r => r.FNomeCompleto.Contains(nome));
            
            return elegivel;
        }
    }
}
