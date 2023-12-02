using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects;
public sealed class Email: ValueObject
{
    //TODO: arrumar nome do email
    //TODO: fazer validacao
    private string Emailx { get; set; }
    public Email(string email)
    {
        Emailx = email;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
