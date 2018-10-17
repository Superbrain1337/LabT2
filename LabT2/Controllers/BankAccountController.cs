using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabT2.Models;

namespace LabT2.Controllers
{
    public class BankAccountController : Controller
    {
        public IApiRequestSend<BankAcount> IApiRequestSend;
        public List<BankAcount> TheAcount;

        public BankAccountController(IApiRequestSend<BankAcount> iApiRequestSend)
        {
            IApiRequestSend = iApiRequestSend;
            TheAcount = new List<BankAcount>();
        }
        

        public List<BankAcount> GetAllData()
        {
            var theReturn = IApiRequestSend.GetAllData();
            if(theReturn == null || theReturn.Count == 0)
            {
                return TheAcount;
            }
            else
            {
                return theReturn;
            }
        }

        public void AddAcount(BankAcount B)
        {
            TheAcount.Add(B);
            IApiRequestSend.AddEntity(B);
        }

        public void ModifyAcount(int id, BankAcount B)
        {
            throw new NotImplementedException();
        }

        public void DeleteAcount(BankAcount B)
        {
            throw new NotImplementedException();
        }
    }
}
