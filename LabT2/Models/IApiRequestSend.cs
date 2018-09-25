using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabT2.Models
{
    public interface IApiRequestSend<BankAccount>
    {
        List<BankAcount> GetAllData();

        void AddEntity(BankAcount B);

        void ModifyEntity(int id, BankAcount B);

        void DeleteEntity(BankAcount B);

    }
}
