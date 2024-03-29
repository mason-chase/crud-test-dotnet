using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Application.Services.Customers.Command.RegisterCustomer;
using Mc2.CrudTest.Domain.Dto;
using Mc2.CrudTest.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services.Customers.Command.RemoveCustomer
{
    public interface IRemoveCustomer
    {
        ResultDto Execute(long Id);
    }
    public class RemoveCustomer : IRemoveCustomer
    {
        private readonly IDataBaseContext _context;
        public RemoveCustomer(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long Id)
        {
            try
            {
                if (Id==null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "Id is null"
                    };
                }
                var customer = _context.Customers.Find(Id);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "Successful"
                };
            }
            catch
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "Faild!"
                };
            }
        }
    }

}
