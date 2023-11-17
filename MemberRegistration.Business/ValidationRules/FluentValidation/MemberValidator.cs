using System;
using FluentValidation;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.Business.ValidationRules.FluentValidation
{
    public class MemberValidator: AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.TcNo).NotEmpty();
            RuleFor(p => p.TcNo).Length(11);
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.DateOfBirth).NotEmpty();
            RuleFor(p => p.DateOfBirth).LessThan(DateTime.Now);
        }
    }
}