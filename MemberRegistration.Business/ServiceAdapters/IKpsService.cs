using System.Threading.Tasks;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.Business.ServiceAdapters
{
    public interface IKpsService
    {
        Task<bool> ValidateUser(Member member);
    }
}