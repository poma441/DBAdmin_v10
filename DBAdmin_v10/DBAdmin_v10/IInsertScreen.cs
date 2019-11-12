using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public interface IInsertScreen
    {
        string LoginText { get; set; }
        string PasswordText { get; set; }
        string SurnameText { get; set; } 
        string NameText { get; set; }
        string PatronymicText { get; set; }
        string PositionText { get; set; }


    }
}
