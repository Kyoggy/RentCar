using Microsoft.EntityFrameworkCore;
using rentCar.Models;

namespace rentCar.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) 
    {

    }

    //Classes que vão virar tabelas no banco de dados
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Aluguel> Alugueis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Como popular uma base de dados utilizando EF no método
        //OnModelCreating, quero dados reais de Funcionario, com os seguintes
        //atributos


        base.OnModelCreating(modelBuilder);
    }
}
