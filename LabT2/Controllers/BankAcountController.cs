using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LabT2.Models;

namespace LabT2.Controllers
{
    [Produces("application/json")]
    [Route("api/BankAcount")]
    public class BankAcountController : Controller
    {
        private IApiRequestSend<BankAcount> _iApiRequestSend;
        public List<BankAcount> TheAcount;

        public BankAcountController(IApiRequestSend<BankAcount> iApiRequestSend)
        {
            _iApiRequestSend = iApiRequestSend;
        }

        public IApiRequestSend<BankAcount> GetAllData()
        {
            return _iApiRequestSend;
            //return new List<BankAcount> { new BankAcount() };
        }

        public void AddAccount(BankAcount B)
        {
            _iApiRequestSend.AddEntity(B);
        }

        public void ModifyAccount(int id, BankAcount B)
        {
            throw new NotImplementedException();
        }
        
        public void DeleteAccount(BankAcount B)
        {
            throw new NotImplementedException();
        }
    }
}
