using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValidation;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using DevFramework.Core.Aspects.PostSharp.ValidationAspects;

namespace MemberRegistration.Business.Concrete.Manager
{
    public class MemberManager : IMemberService
    {
        private readonly IMemberDal _memberDal;
        private readonly IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }

        public List<Member> GetAll()
        {
            return _memberDal.GetList();
        }

        public Member GetById(int id)
        {
            return _memberDal.Get(m => m.Id.Equals(id));
        }

        [FluentValidationAspect(typeof(MemberValidator))]
        public async Task<Member> AddAsync(Member entity)
        {
            CheckIfMemberExists(entity);
            
            await CheckIfUserValidFromKps(entity);

            return _memberDal.Add(entity);
        }

     

        public Member Update(Member entity)
        {
            return _memberDal.Update(entity);
        }

        public void Delete(Member entity)
        {
            _memberDal.Remove(entity);
        }
        
        private void CheckIfMemberExists(Member entity)
        {
            if (_memberDal.Get(m => m.TcNo.Equals(entity.TcNo)) != null)
                throw new Exception("Bu üye zaten kayıtlı");
        }
        
        private async Task CheckIfUserValidFromKps(Member entity)
        {
            if (!await _kpsService.ValidateUser(entity))
                throw new Exception("Kps sorgu sonucu başarısız.");
        }
    }
}