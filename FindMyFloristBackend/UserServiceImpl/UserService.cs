using DALContracts;
using ProjectContracts;
using ProjectDTO;
using System;
using System.Data;

namespace UserServiceImpl
{
    public class UserService : IUserService
    {
        public IDAL DALServices { get; set; }
        public string[] GetUsers(string i_UserID)
        {
            IParameter parameterUserID = DALServices.CreateParameter("UserID", i_UserID);
            DataSet dataset = DALServices.ExecuteQuery("GetAllOtherUsers", parameterUserID);
            string[] retval = new string[dataset.Tables[0].Rows.Count];
            for (var i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                retval[i] = (string)dataset.Tables[0].Rows[i]["UserID"];
            }
            return retval;
        }

        public bool IsUserExist(string i_UserID)
        {
            bool isUserLoggedInSuccessfully = false;
            var paramUserID = DALServices.CreateParameter("Email", i_UserID);
            var dataset = DALServices.ExecuteQuery("IsUserExist", paramUserID);
            if (dataset.Tables[0].Rows.Count != 0)
            {
                isUserLoggedInSuccessfully = true;
            }
            return isUserLoggedInSuccessfully;
        }

        public bool SignUp(UserDTO i_UserDetails)
        {
            bool isUserSignUpSuccessfully;
            IParameter paramUserUserID = DALServices.CreateParameter("UserID", i_UserDetails.UserID);
            IParameter paramFullName = DALServices.CreateParameter("FullName", i_UserDetails.FullName);
            IParameter paramEmail = DALServices.CreateParameter("Email", i_UserDetails.Email);
            IParameter paramPassword = DALServices.CreateParameter("Password", i_UserDetails.Password);
            IParameter paramAddress = DALServices.CreateParameter("Address", i_UserDetails.Address);
            try
            {
                DALServices.ExecuteNonQuery("CreateUser", paramUserUserID, paramFullName, paramEmail, paramPassword, paramAddress);
                isUserSignUpSuccessfully = true;
            }
            catch (Exception e)
            {
                Console.Write(e);
                isUserSignUpSuccessfully = false;
            }
            return isUserSignUpSuccessfully;
        }

        public bool SignIn(UserDTO i_UserDetails)
        {
            bool isUserSignInSuccessfully;
            IParameter paramEmail = DALServices.CreateParameter("Email", i_UserDetails.Email);
            IParameter paramPassword = DALServices.CreateParameter("Password", i_UserDetails.Password);
            try
            {
                DALServices.ExecuteNonQuery("Login", paramEmail, paramPassword);
                isUserSignInSuccessfully = true;
            }
            catch
            {
                isUserSignInSuccessfully = false;
            }
            return isUserSignInSuccessfully;
        }
    }
}
