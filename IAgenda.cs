using System.Collections.Generic;

namespace Aula_31___Whatsapp
{
    public interface IAgenda
    {
        void Cadastrar(Contato ctt);
        void Excluir(Contato ctt);

        List<Contato> Listar();
    }
}