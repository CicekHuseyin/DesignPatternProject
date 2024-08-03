using DesignPatternProject.DAL;
using DesignPatternProject.Models;

namespace DesignPatternProject.ChainOfResponsibility
{
    public class Cashier : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = req.EmployeeName;
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye ödendi, işlem kapatıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = req.EmployeeName;
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar veznedar tarafından ödenemedi, işlem şube müdür yardımcısına yönlendirildi.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
