using DesignPatternProject.DAL;
using DesignPatternProject.Models;

namespace DesignPatternProject.ChainOfResponsibility
{
    public class RegionManager:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Hüseyin Çiçek";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar bölge müdürü tarafından müşteriye ödendi, işlem kapatıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Hüseyin Çiçek";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar bölge müdürü tarafından ödenemedi, işlem yapılamadı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
        }
    }
}
