using login.Data;
using login.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace login.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ChatController(DataContext context)  => _dataContext = context;
        [HttpGet]
        public async Task<IEnumerable<user>> Get()
            => await _dataContext.Users.ToListAsync();
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(user), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int Id)
        {
            var User = await _dataContext.Users.FindAsync(Id);
            return User == null ? NotFound() : Ok(User);    
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(user user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { Id = user.Id }, user);
        }
        [HttpGet("GetClientById/{clientId}")]
        [ProducesResponseType(typeof(clients), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            var client = await _dataContext.Clients.FindAsync(clientId);

            if (client == null)
            {
                return NotFound("Client not found.");
            }

            return Ok(client);
        }
        [HttpGet("GetAgentById/{agentId}")]
        [ProducesResponseType(typeof(Agents), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAgentById(int agentId)
        {
            var agent = await _dataContext.Agents.FindAsync(agentId);

            if (agent == null)
            {
                return NotFound("Agent not found.");
            }

            return Ok(agent);
        }
        [HttpPost("AddClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddClient(clients client)
        {
            if (client == null)
            {
                return BadRequest("Client data is invalid.");
            }

            await _dataContext.Clients.AddAsync(client);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientById), new { Id = client.Id }, client);
        }

        [HttpPost("AddAgent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAgent(Agents agent)
        {
            if (agent == null)
            {
                return BadRequest("Agent data is invalid.");
            }

            await _dataContext.Agents.AddAsync(agent);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgentById), new { Id = agent.Id }, agent);
        }

        [HttpPut(" {id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, user user)
        {
            if (id != user.Id) return BadRequest();
            _dataContext.Entry(user).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var UserToDelete = await _dataContext.Users.FindAsync(id);
            if (UserToDelete == null) return NotFound();
            _dataContext.Users.Remove(UserToDelete);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
            
        

     }

}

