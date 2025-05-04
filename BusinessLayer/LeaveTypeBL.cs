using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferObject;

namespace BusinessLayer
{
    public class LeaveTypeBL
    {
        private LeaveTypeDL dal = new LeaveTypeDL();

        public List<LeaveTypeDTO> GetAll() { return dal.GetAll(); }
        public bool Add(LeaveTypeDTO t) => dal.Add(t);
        public bool Delete(int id) => dal.Delete(id);
        public bool Update(LeaveTypeDTO lt) => dal.Update(lt);
    }

}

