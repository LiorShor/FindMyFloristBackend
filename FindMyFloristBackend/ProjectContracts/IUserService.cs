using ProjectDTO;
using DALContracts; 

namespace ProjectContracts
{
    public interface IUserService
    {
        public bool SignUp(UserDTO i_UserDetails);
        public bool SignIn(UserDTO i_UserDetails);
        public bool IsUserExist(string i_UserID);
        public string[] GetUsers(string i_UserID);
        public IDAL DALServices { get; set; }

    }
}
