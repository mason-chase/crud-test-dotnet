using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Services
{
	public class LoginService
	{
		readonly IDictionary<string, string> _users = new Dictionary<string, string>();
		public void AddUser(string userName, string password)
		{
			_users.Add(userName, password);
		}

		
	}

}
