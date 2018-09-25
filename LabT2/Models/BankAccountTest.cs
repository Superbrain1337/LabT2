using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabT2.Models;

namespace LabT2.Models
{
    public class BankAccountTest : Controller
    {
        private static IApiRequestSend<BankAcount> _iApiRequestSend;

        public List<BankAcount> TheAcount;

        public BankAccountTest(IApiRequestSend<BankAcount> iApiRequestSend)
        {
            _iApiRequestSend = iApiRequestSend;
            TheAcount = new List<BankAcount>();
        }
        

        public List<BankAcount> GetAllData()
        {
            var theReturn = _iApiRequestSend.GetAllData();
            if(theReturn == null)
            {
                return new List<BankAcount>();
            }
            else
            {
                return theReturn;
            }
        }

        public void AddAcount(BankAcount B)
        {
            if(_iApiRequestSend == null)
            {
                //_iApiRequestSend = new IApiRequestSend<BankAcount>();
            }
            TheAcount.Add(B);
            _iApiRequestSend.AddEntity(B);
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
