using BrunSker.Api.ResponseTypesAttributes;
using BrunSker.ApplicationService.Interfaces;
using BrunSker.ApplicationService.Requests.Lease;
using BrunSker.ApplicationService.Response.Locacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrunSker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        [HttpPost("adicionar_locacao")]
        [CommandsResponseTypes]
        public async Task<bool> AddAsync([FromBody] LocacaoSaveRequest locacaoSaveRequest) =>
            await _locacaoService.AddAsync(locacaoSaveRequest);

        [HttpPut("atualizar_locacao")]
        [CommandsResponseTypes]
        public async Task<bool> UpdateAsync([FromBody] LocacaoUpdateRequest locacaoUpdateRequest) =>
            await _locacaoService.UpdateAsync(locacaoUpdateRequest);

        [HttpDelete("excluir_locacao")]
        [CommandsResponseTypes]
        public async Task<bool> DeleteAsync([FromQuery] int id) =>
            await _locacaoService.DeleteAsync(id);

        [HttpGet("achar_locacao")]
        [QueryCommandsResponseTypes]
        public async Task<LocacaoResponse> GetLocacaoByIdAsync([FromQuery] int id) =>
            await _locacaoService.GetLocacaoByIdAsync(id);

        [HttpGet("achar_todas_locacoes")]
        [QueryCommandsResponseTypes]
        public async Task<List<LocacaoResponse>> GetAllLocacoesAsync() =>
            await _locacaoService.GetAllLocacoesAsync();
    }
}
