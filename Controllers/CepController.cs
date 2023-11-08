using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.VisualBasic;

[ApiController]
[Route("cep")]

public class CepController : ControllerBase
{
    [HttpGet("{cep}")]
    public async Task<ActionResult> GetAsync(string cep)
    {
        // Utilizar ViaCEP
        HttpClient client = new HttpClient();

        var url = $"http://viacep.com.br/ws/{cep}/json/";

        var responsive = await client.GetAsync(url);


        return Ok(await responsive.Content.ReadAsStringAsync());
    }
    
}