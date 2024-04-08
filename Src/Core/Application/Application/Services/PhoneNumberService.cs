using Application.Contracts.Application;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly PhoneNumberUtil _phoneUtil;

        public PhoneNumberService()
        {
            _phoneUtil = PhoneNumberUtil.GetInstance();
        }

        public async Task<bool> IsValid(string phoneNumber)
        {
            try
            {
                var parsedNumber = _phoneUtil.Parse(phoneNumber, null);
                return _phoneUtil.IsValidNumber(parsedNumber) &&
                       _phoneUtil.GetNumberType(parsedNumber) == PhoneNumberType.MOBILE;
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}