using System.Data.Entity.ModelConfiguration;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.DataAccess.Concrete.EntityFramework.Mapping
{
    public class MemberMap:EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            ToTable(@"Members", @"dbo");
            HasKey(m => m.Id);
            
            Property(m => m.FirstName).HasColumnName("FirstName");
            Property(m => m.LastName).HasColumnName("LastName");
            Property(m => m.DateOfBirth).HasColumnName("DateOfBirth");
            Property(m => m.TcNo).HasColumnName("TcNo");
            Property(m => m.Email).HasColumnName("Email");
        }
    }
}