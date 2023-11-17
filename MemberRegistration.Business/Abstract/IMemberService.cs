using System.Collections.Generic;
using System.Threading.Tasks;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.Business.Abstract
{
    public interface IMemberService
    {
        List<Member> GetAll();
        Member GetById(int id);
        Task<Member> AddAsync(Member entity);
        Member Update(Member entity);
        void Delete(Member entity);
    }
}