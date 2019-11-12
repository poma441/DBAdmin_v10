using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public interface IChangeInfoScreen
    {
        string Login();
        string Password();
        string Name();
        string Surname();
        string Patronymic();
        string Position();
    }
}
