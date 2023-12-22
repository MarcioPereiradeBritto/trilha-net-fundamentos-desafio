namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            // Este sinal "!" antes do string serve para fazer a inverção do valor booleano caso o campo esteja em branco "WhiteEspace".
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com a placa {placa} foi estacionado com sucesso.");
            }
            else
            {                
                Console.WriteLine("Placa inválida. Tente novamente.");
                //Se for digitado um valor imcompativel para a variavel placa o programa retorna um erro de placa invalida.
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            // Verifica se o veículo existe
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                //O tryparse retorna um valor booleano para verificar se o valor correto foi inserido   
                // && hora >= 0 para o caso de um horário inexistente ou negativo       
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Valor inválido para a quantidade de horas.Certifique-se de digitar um número que não seja negativo.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
