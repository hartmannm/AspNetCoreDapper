using ANCD.Domain.Entities.DomainEntities.Enums;

namespace ANCD.Domain.Entities.ValueObjects
{
    public record CRMRegister
    {
        public EUF Uf { get; init; }

        public long Number { get; init; }

        public CRMRegister(EUF uf, long number)
        {
            Uf = uf;
            Number = number;
        }

        public string Description() => $"{Number}/{Uf.ToString().ToUpper()}";
    }
}
