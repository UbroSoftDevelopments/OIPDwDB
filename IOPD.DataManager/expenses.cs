using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class expenses
    {
        int receiptno, amount, patientno;
        DateTime dateofexpense;
        String comments;
        public expenses(int patient)
        {
            DataSet1TableAdapters.expensesTableAdapter eta = new DataSet1TableAdapters.expensesTableAdapter();
            DataSet1.expensesDataTable edt = eta.GetDataByPatientNo(patient);
            DataSet1.expensesRow er = (DataSet1.expensesRow)edt.Rows[0];
            receiptno = er.receiptno;
            amount = er.amount;
            patientno = er.patientno;
            dateofexpense = er.dateofexpense;
            comments = er.comments;
        }
        public int getReceiptNo()
        {
            return receiptno;
        }
        public int getAmount()
        {
            return amount;
        }
        public int getPatientNo()
        {
            return patientno;
        }
        public string getComments()
        {
            return comments;
        }
        public DateTime getDateOfExpenses()
        {
            return dateofexpense;
        }
    }
}
