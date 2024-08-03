using DesignPatternProject.DAL;
using DesignPatternProject.Models;

namespace DesignPatternProject.ChainOfResponsibility
{
    public class AsisstantManager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Merve Çınar";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar şube müdür yardımcısı tarafından müşteriye ödendi, işlem kapatıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Merve Çınar";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar şube müdür yardımcısı tarafından ödenemedi, işlem şube müdürüne yönlendirildi.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
