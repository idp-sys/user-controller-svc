using Microsoft.AspNetCore.Identity;
using UserManager.Infra.CrossCutting.Identity.Model;

namespace UserManager.Infra.CrossCutting.Identity.Config
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        //Obs. Aqui podemos configurar todas as funcionalidades do Identity, neste caso so estou usando
        //as configuracoes  referentes ao ApplicationUser
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
          : base(store, null, null, null, null, null, null, null, null)
        {
        }
    }
}