namespace Mc2.Framework.Domain.Utils;

public class SystemClock:IClock
{
    public DateTime Now() => DateTime.Now;
    public void SetNow(DateTime date) => throw new NotImplementedException();
}