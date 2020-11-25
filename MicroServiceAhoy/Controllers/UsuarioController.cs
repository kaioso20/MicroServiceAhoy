using MicroServiceAhoy.Model;
using MicroServiceAhoy.Model.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MicroServiceAhoy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public DateTime dataAtual = DateTime.Now;
        [HttpGet]
        public object GetUsers()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                return context.Usuario
                              .AsNoTracking()
                              .ToList();
            }
        }
        [HttpPost]
        public object PostUsers([FromBody]Usuario InfosUser)
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                bool existsMailUser = context.Usuario.Any(users => users.Email == InfosUser.Email);
                if (existsMailUser)
                    return new { success = false, code = 200, msg = "Email já cadastrado em nossa base de dados" };
                
                context.Usuario.Add(new Model.Usuario.Usuario
                {
                    DtNasc = InfosUser.DtNasc,
                    Email = InfosUser.Email,
                    Nome = InfosUser.Nome,
                    Token = Guid.NewGuid().ToString(),
                    Senha = InfosUser.Senha,
                    Ativo = true
                });
                context.SaveChanges();
                return new { success = true, code = 200, msg = "Cadastro realizado com sucesso" };
            }
        }

        [HttpPut]
        public object UpdateUsers([FromBody] Usuario InfosUser)
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Usuario user = context.Usuario.Where(users => users.Token == InfosUser.Token).FirstOrDefault();
                if (user == null)
                    return new { success = false, code = 200, msg = "Não exists este usuário em nossa base de dados" };

                user.Nome = string.IsNullOrEmpty(InfosUser.Nome) ? user.Nome : InfosUser.Nome;
                user.Email = string.IsNullOrEmpty(InfosUser.Email) ? user.Email : InfosUser.Email;
                user.Ativo = InfosUser.Ativo == null ? user.Ativo : InfosUser.Ativo;

                context.SaveChanges();
                return new { success = true, code = 200, msg = "Atualização realizada com sucesso" };
            }
        }
        [HttpDelete]
        public object DeleteUsers([FromBody] Usuario InfosUser) /*Delete gralmente realiza a troca de chave de ativo = 1 para ativo = 0. Porém o teste era um crud e decidi fazer o delete mesmo*/
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                if (string.IsNullOrEmpty(InfosUser.Token))
                    return new { success = false, code = 200, msg = "Token é necessário para esta etapa", _TokenRecived = InfosUser.Token };

                Usuario userDelete = context.Usuario.Where(a => a.Token == InfosUser.Token).FirstOrDefault();
                if (userDelete == null)
                    return new { success = false, code = 200, msg = "Usuário não encontrado", _TokenRecived = InfosUser.Token };

                context.Usuario.Remove(userDelete);
                context.SaveChanges();
                return new { success = true, code = 200, msg = $"Usuário {userDelete.Email} deletado com sucesso"};
            }
        }
    }
}
