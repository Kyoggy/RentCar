using Microsoft.AspNetCore.SignalR;

namespace rentCar.Models;

public class Aluguel
{
    public int AluguelId { get; set; }
    public char DataInicio { get; set; }
    public char DataTermino { get; set; }
    public int DiasAlugados { get; set; }
    public double ValorTotal { get; set; }
    public Cliente? Cliente { get; set;}
    public int ClienteId { get; set;}
    public Carro? Carro { get; set;}
    public int CarroId { get; set;}
}
