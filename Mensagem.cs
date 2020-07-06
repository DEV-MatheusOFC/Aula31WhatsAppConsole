
namespace Aula_31___Whatsapp
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public Contato Destinatario { get; set; }

        public string Enviar(Contato ctt)
        {
            return $"Enviar mensagem para: {ctt.Nome} \nDeseja enviar a seguinte mensagem?: {Texto}";
        }
    }    
}