using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palavrando.FakeNameCreator
{
    public class PlayerName
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public PlayerName(string name)
        {
            Id = Guid.NewGuid(); // pode por so id recebido
            Nome = name;
            var pessoa0 = new Faker<PlayerName>("pt_BR")
                .RuleFor(c => c.Id, f => Id)
                .RuleFor(c => c.Nome, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(c => c.DataNascimento, f => f.Date.Past(15))
                .Generate();

            Nome = Convert.ToString(pessoa0.Nome);
            DataNascimento = Convert.ToDateTime(pessoa0.DataNascimento);
        }

        /*public PlayerName()
        {
            var pessoa0 = new Faker<PlayerName>("pt_BR")
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(c => c.DataNascimento, f => f.Date.Past(15))
                .Generate();

            Id = Guid.NewGuid();
            Nome = Convert.ToString(pessoa0.Nome);
            DataNascimento = Convert.ToDateTime(pessoa0.DataNascimento);
        }*/
        public static PlayerName Fake()
        {
            return new Faker<PlayerName>("pt_BR")
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(c => c.DataNascimento, f => f.Date.Past(15))
                .Generate();
        }

        public override string ToString()
        {
            return "PlayerName";
        }
    }
}
