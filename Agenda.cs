using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula_31___Whatsapp
{
    public class Agenda : IAgenda
    {
        List<Contato> contatos = new List<Contato>();
        private const string PATH = "Database/contato.csv";

        public Agenda()
        {
            if(!File.Exists(PATH))
            {
                Directory.CreateDirectory("Database");
                File.Create(PATH).Close();
            }
        }

        public void ReescreverCSV(List<string> linhas){
            using (StreamWriter output = new StreamWriter(PATH))
            {
                foreach (string ln in linhas)
                {
                    output.Write(ln + "\n");
                }
            }
        }

        public void Cadastrar(Contato ctt)
        {
            string[] linha = { PrepararLinhaCSV(ctt) };
            File.AppendAllLines(PATH, linha);
        }

        public void Excluir(Contato ctt)
        {
            List<string> linhas = new List<string>();
            using (StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while ((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(x => x.Contains(ctt.Nome));
            ReescreverCSV(linhas);
        }

        public List<Contato> Listar()
        {
            string[] linhas = File.ReadAllLines(PATH);
            foreach(string linha in linhas)
            {
                string [] dados = linha.Split(';');
                contatos.Add(new Contato (dados[0], dados [1]));
        
            }

            contatos = contatos.OrderBy(z => z.Nome).ToList();
            return contatos;
        }

        public string PrepararLinhaCSV(Contato ctt)
        {
            return $"{ctt.Nome};{ctt.Telefone}";
        }
    }
}