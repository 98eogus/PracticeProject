using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.Service
{
    internal interface ICustomerService
    {
        List<Customer> FindAll();
        Customer FindById(string id);   
    }
}
