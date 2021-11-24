using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Models.Request;
using GeoLocalizador.BE.Models.Response;
using GeoLocalizador.BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GeoLocalizador.BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _context;
        public UserController(UserServices context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Get()
        {
            try
            {
                Result<IEnumerable<UserResponse>> _result = _context.Get();
                return Ok(_result);
            }
            catch (Exception err)
            {
                Result<string> _result = new Result<string>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }            
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody]LoginRequest value)
        {
            try
            {
                Result<dynamic> _result = _context.CheckCredencials(value.Username, value.Password);
                return Ok(_result);
            }
            catch (Exception err)
            {
                Result<string> _result = new Result<string>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Set([FromBody] User _user)
        {
            Result<bool> _result;
            try
            {
                _result = _context.Set(_user);
                return Ok(_result);
            }
            catch (Exception err)
            {
                _result = new Result<bool>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPut("update-password/{id}")]
        [AllowAnonymous]
        public ActionResult UpdatePassword(int id, [FromBody] User _user)
        {
            Result<bool> _result;
            try
            {
                _result = _context.UpdatePassword(id, _user);
                return Ok(_result);
            }
            catch (Exception err)
            {
                _result = new Result<bool>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPut("turn-on-access/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult TurnOnAccess(int id)
        {
            Result<bool> _result;
            try
            {
                _result = _context.TurnOnAccess(id);
                return Ok(_result);
            }
            catch (Exception err)
            {
                _result = new Result<bool>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPut("turn-off-access/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult TurnOffAccess(int id)
        {
            Result<bool> _result;
            try
            {
                _result = _context.TurnOffAccess(id);
                return Ok(_result);
            }
            catch (Exception err)
            {
                _result = new Result<bool>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
    }
}
