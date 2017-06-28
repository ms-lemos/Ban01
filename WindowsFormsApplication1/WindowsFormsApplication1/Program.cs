using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.Infra;

namespace WindowsFormsApplication1
{
    public static class Program
    {
        private static string host, port, user, password, dbName;
        private static Database _db;

        [STAThread]
        public static void Main()
        {


            Console.WriteLine(@"Entre com o host do banco: ");
            host = Console.ReadLine();
            Console.WriteLine(@"Entre com a porta do banco: ");
            port = Console.ReadLine();
            Console.WriteLine(@"Entre com o usuario: ");
            user = Console.ReadLine();
            Console.WriteLine(@"Entre com a senha: ");
            password = Console.ReadLine();
            Console.WriteLine(@"Entre com o nome da base: ");
            dbName = Console.ReadLine();

            _db = new Database(dbName, password, user, port, host);

            int opcao;

            do
            {
                Console.WriteLine(@"  1 -  Cadastrar ingredientes ");
                Console.WriteLine(@"  2 -  Cadastrar sabores ");
                Console.WriteLine(@"  3 -  Cadastrar tamanhos ");
                Console.WriteLine(@"  4 -  Cadastrar clientes ");
                Console.WriteLine(@"  5 -  Realizar pedido");
                Console.WriteLine(@"  6 -  Lista ingredientes");
                Console.WriteLine(@"  7 -  Lista sabores");
                Console.WriteLine(@"  8 -  Lista tamanhos");
                Console.WriteLine(@"  9 -  Lista clientes");
                Console.WriteLine(@"  10 - Lista pedidos por cliente");
                Console.WriteLine(@"  11 - Lista pedidos por periodo");
                Console.WriteLine(@"  12 - Lista pedidos por sabor");
                Console.WriteLine(@"  13 - Remover cliente");
                Console.WriteLine(@"  14 - Cancelar pedido");
                Console.WriteLine(@"  15 - Atualizar cliente");
                Console.WriteLine(@"  16 - Atualizar pedido");

                Console.WriteLine(@"  99 - Sair");

                opcao = LerInt(@"Entre com a opção desejada: ");

                try
                {
                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            CadastrarIngredientes();
                            break;
                        case 2:
                            CadastrarSabores();
                            break;
                        case 3:
                            CadastrarTamanhos();
                            break;
                        case 4:
                            CadastrarClientes();
                            break;
                        case 5:
                            RealizarPedido();
                            break;
                        case 6:
                            ListarIngredientes();
                            break;
                        case 7:
                            ListarSabores();
                            break;
                        case 8:
                            ListarTamanhos();
                            break;
                        case 9:
                            ListarClientes();
                            break;
                        case 10:
                            ListarPedidosPorCliente();
                            break;
                        case 11:
                            ListarPedidosPorPeriodo();
                            break;
                        case 12:
                            ListarPedidosPorSabor();
                            break;
                        case 13:
                            RemoverCliente();
                            break;
                        case 14:
                            CancelarPedido();
                            break;
                        case 15:
                            AtualizarCliente();
                            break;
                        case 16:
                            AtualizarPedido();
                            break;
                        default:
                            Console.WriteLine(@"Opção não cadastrada!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }
            } while (opcao != 99);
        }

        private static void AtualizarPedido()
        {
            throw new NotImplementedException();
        }

        private static void AtualizarCliente()
        {
            var id = LerInt("Entre com o ID do cliente: ");
            var nome = LerString("Entre com o nome do cliente: ");
            var cpf = LerInt("Entre com o CPF do cliente: ");
            var num1 = LerInt("Entre com o primeiro numero de telefone do cliente: ");
            var num2 = LerInt("Entre com o segundo numero de telefone do cliente: ");
            var aniver = LerString("Entre com a data de aniversario do cliente: ");
            var logr = LerString("Entre com o logradouro do cliente: ");
            var num = LerInt("Entre com o numero do cliente: ");
            var compl = LerString("Entre com o complemente do endereço do cliente: ");
            var cep = LerInt("Entre com o CEP do cliente: ");

            var sql = "UPDATE public.\"Cliente\"" +
                      $"SET \"Nome\"='{nome}', \"CPF\"={cpf}, \"NumeroTelefone1\"={num1}, \"NumeroTelefone2\"={num2}, \"DtNascimento\"='{aniver}'" +
                      $"WHERE \"ID\" = {id};";
           
            _db.ExecutaComando(sql);

            sql = "UPDATE public.\"Endereco\"" +
                  $"SET \"Logradouro\"='{logr}', \"Numero\"={num}, \"Complemento\"='{compl}', \"CEP\"={cep}" +
                  $"WHERE \"idcliente\" = {id};";

            _db.ExecutaComando(sql);
        }

        private static void CancelarPedido()
        {
            var id = LerInt("Entre com o ID do pedido: ");
            var sql = $"DELETE FROM public.\"ItemPedido\" WHERE \"IdPedido\" = {id}; " +
                      $"DELETE FROM public.\"Pedido\" WHERE \"ID\" = {id};";

            _db.ExecutaComando(sql);
        }

        private static void RemoverCliente()
        {
            var id = LerInt("Entre com o ID do cliente: ");
            var sql = $"DELETE FROM public.\"Endereco\" WHERE \"idcliente\" = {id}; " +
                      $"DELETE FROM public.\"Cliente\" WHERE \"ID\" = {id};";

            _db.ExecutaComando(sql);
        }

        private static void ListarPedidosPorSabor()
        {
            var cdSabor = LerInt("Entre com o codigo do sabor: ");

            var sql = "SELECT * FROM public.\"Pedido\" P " +
                        "INNER JOIN public.\"ItemPedido\" IP ON ip.\"IdPedido\" = P.\"ID\"" +
                        "INNER JOIN public.\"PizzaSabores\" PS ON ip.\"IdItem\" = ps.\"IdPizza\"" +
                        $"WHERE PS.\"IdSabor\" = {cdSabor};";

            var dt = new DataTable();

            _db.RealizaConsulta(sql, out dt);

            Console.WriteLine(@"Dados dos pedidos: ");

            ImprimeDataTable(dt);

            dt.Dispose();
        }

        private static void ListarPedidosPorPeriodo()
        {
            var ini = LerString("Entre com a data de inicio: ");
            var fim = LerString("Entre com a data de fim: ");

            var sql = $"SELECT * FROM public.\"Pedido\" WHERE \"Data Pedido\" >= '{ini}' AND \"Data Pedido\" <= '{fim}'";
            var dt = new DataTable();

            _db.RealizaConsulta(sql, out dt);

            Console.WriteLine(@"Dados dos pedidos: ");

            ImprimeDataTable(dt);

            dt.Dispose();
        }

        private static void ListarPedidosPorCliente()
        {
            var cdCli = LerInt("Entre com o código do cliente: ");

            var sql = "SELECT * FROM public.\"Pedido\" WHERE \"IdCliente\" = " + cdCli;
            var dt = new DataTable();

            _db.RealizaConsulta(sql, out dt);

            Console.WriteLine(@"Dados dos pedidos: ");

            ImprimeDataTable(dt);

            dt.Dispose();
        }

        private static void ListarClientes()
        {
            var sql = "SELECT * FROM public.\"Cliente\"";
            var dt = new DataTable();

            _db.RealizaConsulta(sql, out dt);

            Console.WriteLine(@"Dados dos clientes: ");

            ImprimeDataTable(dt);

            dt.Dispose();
        }

        private static void ListarTamanhos()
        {
            var sql = "SELECT * FROM public.\"Tamanhos\"";
            var dt = new DataTable();

            _db.RealizaConsulta(sql, out dt);

            Console.WriteLine(@"Dados dos tamanhos: ");

            ImprimeDataTable(dt);

            dt.Dispose();
        }

        private static void ListarSabores()
        {
            var sql = "SELECT * FROM public.\"Sabores\"";
            var dt = new DataTable();

            _db.RealizaConsulta(sql, out dt);

            Console.WriteLine(@"Dados dos sabores: ");

            ImprimeDataTable(dt);

            dt.Dispose();
        }

        private static void ListarIngredientes()
        {
            var sql = "SELECT * FROM public.\"Ingredientes\";";
            var dt = new DataTable();

            _db.RealizaConsulta(sql, out dt);

            Console.WriteLine(@"Dados dos ingredientes (id, nome, qtd): ");

            ImprimeDataTable(dt);

            dt.Dispose();
        }

        private static void RealizarPedido()
        {
            var cdCli = LerInt("Insira o codigo do cliente: ");
            int cdSabor;
            var sabores = new List<int>();

            do
            {
                cdSabor = LerInt("Insira o código do sabor: (-1 para sair)");
                if(cdSabor != -1)
                    sabores.Add(cdSabor);
            } while (cdSabor != -1);

            var cdTamanho = LerInt("Insira o codigo do tamanho: ");

            var sql = "INSERT INTO public.\"Itens\"(\"Nome\")" +
                      $"VALUES ('Pizza cli: {cdCli}, {DateTime.Now.ToShortDateString()}') RETURNING \"ID\";";

            int idItem;
            _db.ExecutaComando(sql, out idItem);

            sql = "INSERT INTO public.\"Pizza\"(\"“id”\", \"IdTamanho\")" +
                  $"VALUES ({idItem}, {cdTamanho});";
            _db.ExecutaComando(sql);

            foreach (var sabor in sabores)
            {
                sql = $"INSERT INTO public.\"PizzaSabores\"(\"IdPizza\", \"IdSabor\") VALUES ({idItem}, {sabor});";
                _db.ExecutaComando(sql);
            }

            sql = "INSERT INTO public.\"Pedido\"(" +
                  "\"Data Pedido\", \"Hora Pedido\", \"Data entrega\", \"Hora entrega\", \"IdCliente\", \"IdEntregador\")" +
                  $"VALUES ('{DateTime.Now.ToShortDateString()}', '{DateTime.Now.ToShortTimeString()}', null, null, {cdCli}, 1);";

            _db.ExecutaComando(sql);
        }

        private static void CadastrarClientes()
        {
            var nome = LerString("Entre com o nome do cliente: ");
            var cpf = LerInt("Entre com o CPF do cliente: ");
            var num1 = LerInt("Entre com o primeiro numero de telefone do cliente: ");
            var num2 = LerInt("Entre com o segundo numero de telefone do cliente: ");
            var aniver = LerString("Entre com a data de aniversario do cliente: ");
            var logr = LerString("Entre com o logradouro do cliente: ");
            var num = LerInt("Entre com o numero do cliente: ");
            var compl = LerString("Entre com o complemente do endereço do cliente: ");
            var cep = LerInt("Entre com o CEP do cliente: ");

            var sql = $"INSERT INTO public.\"Cliente\"(" +
                            "\"Nome\", \"CPF\", \"NumeroTelefone1\", \"NumeroTelefone2\", \"DtCadastro\", \"DtNascimento\") " +
                            $"VALUES('{nome}', {cpf}, {num1}, {num2}, '{DateTime.Today.ToShortDateString()}', '{aniver}') " +
                      $"RETURNING \"ID\"; ";

            int id;

            _db.ExecutaComando(sql, out id);

            sql = "INSERT INTO public.\"Endereco\"(" +
            "idcliente, \"IdCidade\", \"Logradouro\", \"Numero\", \"Complemento\", \"CEP\")" +
            $"VALUES({id}, 1, '{logr}', {num}, '{compl}', {cep}); ";

            _db.ExecutaComando(sql);

        }

        private static void CadastrarTamanhos()
        {
            var nome = LerString("Entre com o nome do tamanho: ");
            var qtdSabores = LerInt("Entre com a quantidade de sabores: ");
            var qtdFatias = LerInt("Entre com a quantidade de fatias: ");

            var sql = $"INSERT INTO public.\"Tamanhos\"(\"Nome\", \"QtdFatias\", \"QtdSabores\") VALUES ('{nome}', {qtdFatias}, {qtdSabores});";
            _db.ExecutaComando(sql);
        }

        private static void CadastrarSabores()
        {
            var nome = LerString("Insira o nome do sabor: ");
            var ingredientes = new List<int>();
            int cdIngrediente;

            do
            {
                cdIngrediente = LerInt("Insira o código do novo ingrediente do sabor: (-1 para sair)");
                if(cdIngrediente != -1)
                    ingredientes.Add(cdIngrediente);
            } while (cdIngrediente != -1);

            var sql = $"INSERT INTO public.\"Sabores\"(\"Nome\") VALUES ('{nome}') RETURNING \"ID\";";

            int id;
            _db.ExecutaComando(sql, out id);

            foreach (var ingrediente in ingredientes)
            {
                sql = $"INSERT INTO public.\"SaboresIngredientes\"(\"IdSabor\", \"IdIngrediente\") VALUES ({id}, {ingrediente});";
                _db.ExecutaComando(sql);
            }

        }

        private static void CadastrarIngredientes()
        {
            var nome = LerString("Insira o nome do ingrediente: ");
            var quantidade = LerInt($"Insira a quantidade em estoque do ingrediente {nome}: ");

            var sql = $"INSERT INTO public.\"Ingredientes\" (\"Nome\", \"QtdEstoque\") VALUES('{nome}', {quantidade})";

            _db.ExecutaComando(sql);
        }

        private static string LerString(string mensagem)
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine();
        }

        private static int LerInt(string mensagem)
        {
            Console.WriteLine(mensagem);
            return int.Parse(Console.ReadLine());
        }

        private static void ImprimeDataTable(DataTable dt)
        {
            var cols = dt.Columns.Count;

            foreach (DataRow dtRow in dt.Rows)
            {
                var print = new StringBuilder();

                for (var i = 0; i < cols; i++)
                {
                    print.Append($"{dtRow[i]} | ");
                }

                Console.WriteLine(print.ToString());
            }
        }
    }
}
