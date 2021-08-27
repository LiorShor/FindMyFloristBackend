using DALContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectContracts;
using ProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyFloristBackend.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService m_UserService;

        public UserController(IUserService i_UserService, IDAL i_Dal)
        {
            m_UserService = i_UserService;
            m_UserService.DALServices = i_Dal;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public bool SignUp([FromBody] UserDTO i_UserDetails)
        {
            bool signUpResult = false;
            if (!m_UserService.IsUserExist(i_UserDetails.Email))
            {
                signUpResult = m_UserService.SignUp(i_UserDetails);
            }
            return signUpResult;
        }
        [HttpPost]
        public ResponseDTO SignIn([FromBody] UserDTO i_UserDetails)
        {
            ResponseDTO signInResult = new ResponseDTO();
            signInResult.Succeed = false;
            if (m_UserService.IsUserExist(i_UserDetails.Email))
            {
                if (m_UserService.SignIn(i_UserDetails))
                {
                    signInResult.Succeed = true;
                    signInResult.Message = "Login succeeded";
                }
                else
                {
                    signInResult.Message = "Error, Please check your credentials and try again";
                }
            }
            else
            {
                signInResult.Message = "Error, User does not exist";
            }
            return signInResult;
        }
    }
}
