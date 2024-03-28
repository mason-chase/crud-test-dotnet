using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Contracts;

public interface IQuery<in TRequest, TResult>
{
    Task<TResult> Execute(TRequest? request);
}