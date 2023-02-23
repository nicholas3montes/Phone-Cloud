using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phone_Cloud.Data;
using Phone_Cloud.models;
using Phone_Cloud.Repositories;
using Phone_Cloud.Repository;

namespace Phone_Cloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        private readonly DbUserContext _context;

        public UserController(IUserRepository repository, DbUserContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.Add(user);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário criado com sucesso!")
                    : BadRequest("Erro não foi possivel criar o usuario");
        }


        [HttpGet]
        public async Task<IActionResult> Get(User id)
        {
            _repository.GetById(id);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário encontrado!")
                    : BadRequest("Erro não foi possivel encontrar o usuario");
        }
    }
}