using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Application
{
    public interface IPhoneNumberService
    {
        Task<bool> IsValid(string phoneNumber);
    }
}