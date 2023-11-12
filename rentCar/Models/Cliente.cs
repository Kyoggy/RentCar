using Microsoft.AspNetCore.SignalR;

namespace rentCar.Models;
public class Cliente
{
    public int ClienteId { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    
}
