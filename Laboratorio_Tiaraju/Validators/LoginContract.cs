using Flunt.Validations;
using Laboratorio_Tiaraju.Model.Entities;

namespace Laboratorio_Tiaraju.Validators
{
    public class LoginContract : Contract<LoginRequest>
    {
        public LoginContract(LoginRequest login)
        {
            Requires()
                .IsNotNullOrEmpty(login.UserName, nameof(login.UserName), "Usuário Deve Ser Preenchido")
                .IsNotNullOrEmpty(login.Password, nameof(login.Password), "Senha Não Pode Ser Nula");
                
        }

    }
}
