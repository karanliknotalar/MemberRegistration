using System;
using System.Threading.Tasks;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.ConsoleUI
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<IMemberService>();
            var result = await memberService.AddAsync(new Member
            {
                FirstName = "Ahmet",
                LastName = "Turan",
                TcNo = "11111111111",
                Email = "akio@msn.com",
                DateOfBirth = new DateTime(1990, 12, 10)
            });
            Console.WriteLine("Eklendi.");
            Console.ReadLine();
        }
    }
}