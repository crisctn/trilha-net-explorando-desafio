using System.Drawing;

namespace DesafioProjetoHospedagem.Models;

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        int quantidadeTotalHospedes = hospedes.Count;

        bool suiteComportaQuantidadeHospedes = SuiteComportaQuantidadeHospedes(Suite.Capacidade, quantidadeTotalHospedes);

        if (suiteComportaQuantidadeHospedes)
        {
            Hospedes = hospedes;
        }
        else
        {
            throw new Exception("A capacidade da suíte é menor que o número de hóspedes.");
        }
    }    

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    private bool SuiteComportaQuantidadeHospedes(int capacidadeSuite, int quantidadeTotalHospedes)
    {
        return capacidadeSuite >= quantidadeTotalHospedes;
    }

    public decimal CalcularValorDiaria()
    {
        decimal valor = DiasReservados * Suite.ValorDiaria;

        bool concederDesconto = DiasReservados >= 10;

        if (concederDesconto)
        {
            decimal percentualDesconto = 0.1M;
            valor = valor - (valor * percentualDesconto);
        }

        return valor;
    }
}