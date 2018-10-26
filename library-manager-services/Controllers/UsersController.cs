using System;
using System.Collections.Generic;
using LibraryManager.Exceptions;
using LibraryManager.Models;
using LibraryManager.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Repository<User> _usersRepository;

        public UsersController() : base() 
        {
            _usersRepository = new Repository<User>();
        }

        [HttpGet]
        public IActionResult Get() => Ok(_usersRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try 
            {
                return Ok(_usersRepository.Get(id));
            }
            catch (EntityNotFoundException<User> ex)
            {
                return NotFound(ex.Message);
            }
        } 

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var uriBuilder = new UriBuilder()
            {
                Host = this.HttpContext.Request.Host.Host
            };
            return Created(uriBuilder.Uri, _usersRepository.Insert(user));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            try 
            {
                return Ok(_usersRepository.Update(id, user));
            }
            catch(EntityNotFoundException<User> ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try 
            {
                _usersRepository.Delete(id);
                return Ok();
            }
            catch (EntityNotFoundException<User> ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}