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



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _repository.GetById(id);
            return user != null
                    ? Ok(user)
                    : NotFound("Usuario não encontrado");
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _repository.GetAll();
            return user != null
                    ? Ok(user)
                    : NotFound("Não há usuários salvos no banco de dados!");
        }

        [HttpDelete("{1}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repository.Delete(id);
            return user != null
                    ? Ok(user)
                    : NotFound("Não há usuários salvos no banco de dados!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {   
            if (id != user.Id)
            {
                return BadRequest();
            }
            
            var updatedUser = await _repository.Update(user);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

    }
}