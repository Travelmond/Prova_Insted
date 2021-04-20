using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectoVacinacao.Model;
using ProjectoVacinacao.ViewModel;

namespace ProjectoVacinacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElegivelController : ControllerBase
    {

        private readonly Elegivel _Elegivel;

        public ElegivelController()
        {
            _elegivel = new Elegivel();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_elegivel.ListarElegivel());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ElegivelListaViewModel Get(int id)
        {
            try
            {
                var elegivel = _elegivel.ListarElegivel().Where(r => r.FId == id).FirstOrDefault();

                var elegivelViewModel = new ElegivelListaViewModel(
                    elegivel.FId,
                    elegivel.FNomeCompleto,
                    elegivel.FEmail,
                    elegivel.FTelefone);

                return elegivelViewModel;
                
            }
            catch (Exception ex)
            {
                return null;

            }

        }

        [HttpPut("{id}")]
        public Elegivel Put(int id, [FromBody] Elegivel elegivel)
        {
            try
            {
                _elegivel.AlterarElegivel(id, elegivel);
                return elegivel;
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpPost]
        public Elegivel Post([FromBody] Elegivel elegivel)
        {
            try
            {
                _elegivel.InserirElegivel(elegivel);
                return elegivel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {         
            _elegivel.DeletarElegivel(id);
        
        }

        [HttpGet]
        [Route("PesquisarPorNomeCompleto/{nome}")]
        public Elegivel PesquisarNome(string nome)
        {
            try
            {
               return _elegivel.PesquisarPorNome(nome);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("PesquisarParteNome/{nome}")]
        public IEnumerable<Elegivel> PesquisarParteNome(string nome)
        {
            try
            {
                return _elegivel.PesquisarParteNome(nome);
            }
            catch (Exception ex)
            {
                return null;
            }
        }





    }
}
