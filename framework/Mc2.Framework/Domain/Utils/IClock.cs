namespace Mc2.Framework.Domain.Utils;

public interface IClock
{
    DateTime Now();
    DateTime SetNow(DateTime date);
}