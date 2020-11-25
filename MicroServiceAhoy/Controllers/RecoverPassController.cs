using MicroServiceAhoy.Model;
using MicroServiceAhoy.Model.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAhoy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecoverPassController : ControllerBase
    {
        [HttpPut]
        public object PutRecoverPass([FromBody] RecoverPass recoverPass)
        {

            using (EntityModelContext context = new EntityModelContext())
            {

                if (string.IsNullOrEmpty(recoverPass.Token) || string.IsNullOrEmpty(recoverPass.Email) || string.IsNullOrEmpty(recoverPass.confirmNovaSenha) || string.IsNullOrEmpty(recoverPass.NovaSenha))
                    return new { success = false, code = 200, msg = "Necessita Preenchimento de todos os campos", _MailRecived = recoverPass.Email, _TokenRecived = recoverPass.Token, _NovaSenhaRecived = recoverPass.NovaSenha, _ConfirmacaoNovaSenha = recoverPass.confirmNovaSenha };

                if (recoverPass.NovaSenha != recoverPass.confirmNovaSenha)
                    return new { success = false, code = 200, msg = "Senhas são diferentes"};

                Usuario user = context.Usuario.Where(a => a.Token == recoverPass.Token && a.Email == recoverPass.Email).FirstOrDefault();
                user.Senha = recoverPass.NovaSenha;
                context.SaveChanges();

                return new { success = true, code = 200, msg = $"Senha do usuário {user.Email} atualizada com sucesso" };

            }

        }
    }
}
