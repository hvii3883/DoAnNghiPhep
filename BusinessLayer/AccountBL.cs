using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class AccountBL
    {
        private AccountDL dal = new AccountDL();
        public AccountDTO Login(string email, string password) => dal.CheckLogin(email, password);

        public bool AddAccount(AccountDTO account)
        {
            return dal.AddAccount(account);
        }

        public bool DeleteAccount(string email)
        {
            return dal.DeleteAccount(email);
        }

        public bool UpdateAccount(AccountDTO account)
        {
            return dal.UpdateAccount(account);
        }


    }

}

