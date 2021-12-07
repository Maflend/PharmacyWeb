using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb.Shared.Models
{
    public enum Roles
    {
        Guest,
        Client,
        Employee,
        Director,
        Admin
    }
    public enum FieldsError
    {
        Логин,
        Пароль
    }
    public enum Categories
    {
        Жаропонижающие,
        Болеутоляющие,
        Противовирусные,
        Антибиотики,
        Витамины
    }
}
