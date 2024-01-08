using Mc2.Framework.Domain.Utils;

namespace Mc2.CrudTest.Tests.Utils.Stubs;

public class ClockStub:IClock
{
    private DateTime _now;
    public ClockStub(DateTime? now = null)
    { 
        _now = now ?? DateTime.Now;
    }
   
    public DateTime Now()
    {
        return _now;
    }

    public void SetNow(DateTime date)
    {
        _now = date;
    }
    
}