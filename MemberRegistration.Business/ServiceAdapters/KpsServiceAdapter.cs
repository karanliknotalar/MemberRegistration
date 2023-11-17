using System;
using System.Threading.Tasks;
using MemberRegistration.Business.KPSPublic;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.Business.ServiceAdapters
{
    public class KpsServiceAdapter : IKpsService
    {
        public async Task<bool> ValidateUser(Member member)
        {
            var client =
                new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
            var result = await client.TCKimlikNoDogrulaAsync(
                Convert.ToInt64(member.TcNo),
                member.FirstName.ToUpper(),
                member.LastName.ToUpper(),
                member.DateOfBirth.Year);
            return result.Body.TCKimlikNoDogrulaResult;
        }
    }
}