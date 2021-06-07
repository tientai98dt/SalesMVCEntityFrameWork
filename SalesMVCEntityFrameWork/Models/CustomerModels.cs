using PagedList;
using SalesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace SalesMVCEntityFrameWork.Models
{
    public class CustomerModels
    {
        private SalesModels salesModels = null;

        public CustomerModels()
        {
            salesModels = new SalesModels();
        }

        public List<Customer> GetListCustomer()
        {
            var list = salesModels.Database.SqlQuery<Customer>("Sp_Customer_ListAll").ToList();

            return list;
        }

        public IEnumerable<Customer> GetListCustomer(string search, int page, int pageSize)
        {
            IQueryable<Customer> list = salesModels.Customers;
            var a = salesModels.Customers.Where(x=>x.CustomerName.Contains("tai")).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.CustomerName.Contains(search) || x.Email.Contains(search) 
                    || x.Phone.Contains(search) || x.Address.Contains(search)).OrderByDescending(x=> x.CustomerName);
            }
            else
            {
                list = list.OrderByDescending(x => x.CustomerName);
            }
            return list.ToPagedList(page,pageSize);
        }

        public void InsertCustomer(Customer customer)
        {
            salesModels.Customers.Add(customer);
            salesModels.SaveChanges();
        }

        public Customer GetListCustomerByID(int id)
        {
            var list = salesModels.Customers.FirstOrDefault(x => x.CustomerId == id);
            return list;
        }

        public void UpdateCustomer(int id,Customer customer)
        {
            var check = salesModels.Customers.FirstOrDefault(x=>x.CustomerId == id);
            if (check != null)
            {
                check.CustomerName = customer.CustomerName;
                check.Phone = customer.Phone;
                check.Email = customer.Email;
                check.Address = customer.Address;
                salesModels.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            var check = salesModels.Customers.Find(id);
            salesModels.Customers.Remove(check);
            salesModels.SaveChanges();
        }
    }
}