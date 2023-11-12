using Microsoft.AspNetCore.SignalR;

namespace rentCar.Models;

public class Carro
{
    public int CarroId { get; set; }
    public double ValorDia { get; set; }
    public int UnidadesDisponiveis { get; set; }
    public string? Modelo { get; set; }
    public int UnidadesTotais { get; set; }
}
