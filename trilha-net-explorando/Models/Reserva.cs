namespace ProjetoHotel.Models
{
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
            var capacidade = Suite.Capacidade;
            var qtdHospedes = hospedes.Count();

            if (capacidade >= qtdHospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A capacidade e menor que a quantidade de hospedes recebido");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;
            var diasReservados = this.DiasReservados;
            var valorDiariaSuite = Suite.ValorDiaria;
            valor = diasReservados * valorDiariaSuite;

            if (diasReservados >= 10)
            {
                var desconto = valor * 10 / 100;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}