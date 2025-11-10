using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;
using WpfApp3.Repository;

namespace WpfApp3.Service
{
    internal class CustomerService : ICustomerService
    {
        private CustomerRepository _customerRepository = new CustomerRepository();

        public List<Customer> FindAll(){

            var customerList = new List<Customer>();

            customerList = _customerRepository.FindAll();

            return customerList;
        }

        public Customer FindById(string id)
        {
            var customer = _customerRepository.FindById(id);

            return customer;
        }
    }
}
