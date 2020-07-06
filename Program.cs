using System;

namespace Aula_31___Whatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            Contato matheus = new Contato("Matheus", "(11) 94002-8922");
            Mensagem msg = new Mensagem();
            msg.Destinatario = matheus;
            msg.Texto = "Bom dia "+matheus.Nome+"!";
            Console.WriteLine( msg.Enviar(matheus));

            agenda.Cadastrar(matheus);
            // agenda.Excluir();

            foreach (Contato item in agenda.Listar() )
            {
                Console.WriteLine($"\nContato: \nNome: {item.Nome} \nTelefone: {item.Telefone}");
            }

        }
    }
}
