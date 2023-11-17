using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using MemberRegistration.MvcWebUI.Filters;


namespace MemberRegistration.MvcWebUI.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ExceptionHandler]
        public async Task<string> Add(Member member)
        {
            var result = await _memberService.AddAsync(new Member
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                TcNo = member.TcNo,
                Email = member.Email,
                DateOfBirth = member.DateOfBirth
            });
            return "Success";
        }
    }
}