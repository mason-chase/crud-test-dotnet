namespace Mc2.Framework.Domain.Utils;

public class SystemClock:IClock
{
    public DateTime Now() => DateTime.Now;
    public DateTime SetNow(DateTime date) => throw new NotImplementedException();
}