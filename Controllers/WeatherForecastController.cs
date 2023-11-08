using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace Servidores.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Test()
    {
        return "API is Running";
    }
    [HttpPost]
    public string Test2()
    {
        return "API 2 is Running";
    }


    //Usar Barra como separador
    [HttpGet("{x}/{y}")] 
    public int TestSum(int x, int y)
    {
        return x + y;
    }


    //ActionResult retorna o Status Code
    [HttpGet("ActionResult")]
    public ActionResult TestSum2(string x,  string y) 
    {
        var isNum = int.TryParse(x, out var n1);
        var isNum2 = int.TryParse(y, out var n2);

        if (!isNum && !isNum2)
            return BadRequest(
                "Os valores devem ser numerico!"
            );

        if (!isNum)
            return BadRequest(
                "O primeiro deve ser numerico!"
            );
        if (!isNum2)
            return BadRequest(
                "O segundo deve ser numerico!"
            );

        return Ok(n1 + n2);
    }

    [HttpGet("SemValoresNaURL")]
    public ActionResult TestSum3(string a = "1", string b = "2", string c = "3", string d = "4", string e = "5")
    {
        var data = new string[] { a, b, c, d, e };
        int soma = 0;
        foreach (var item in data)
        {
            if (int.TryParse(item, out var i))
                soma += i;
        }
        return Ok(soma);
    }

    [HttpGet("Com_Classe")]
    public ActionResult Coxa()
    {
        Coritiba coxa = new Coritiba();
        coxa.Jogador = "Igor Paixão";
        coxa.Treinador = "Não Tem";
        return Ok(coxa);
    }


    [HttpGet("Sem_Classe")]
    public ActionResult Coxaa()
    {
        return Ok(new {
            Nome = "Igor Paixão",
            Treinador = "Não Tem"
        });
    }
}

public class Coritiba{
    public string Jogador;
    public string Treinador;
}

