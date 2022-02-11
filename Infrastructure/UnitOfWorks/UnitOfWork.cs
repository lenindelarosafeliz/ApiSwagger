using Applications.Interfaces;

namespace Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPersonaRepository Personas { get; }
        public UnitOfWork(IPersonaRepository personas)
        {
            Personas = personas;
        }       
    }
}
