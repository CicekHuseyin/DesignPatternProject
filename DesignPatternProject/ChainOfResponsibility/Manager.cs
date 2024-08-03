using DesignPatternProject.DAL;
using DesignPatternProject.Models;

namespace DesignPatternProject.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Zeynep Öztürk";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar şube müdürü tarafından müşteriye ödendi, işlem kapatıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Zeynep Öztürk";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar şube müdürü tarafından ödenemedi, işlem bölge müdürüne yönlendirildi.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
