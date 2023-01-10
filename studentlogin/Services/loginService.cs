using System.Collections.Generic;

using studentlogin.Models;

namespace user.Services
{
    public static class loginService
    {



        private static List<login> _student = new List<login>();
        public static List<login> GetAll()
        {
            return _student;
        }

        public static void Add(login model)
        {
            _student.Add(model);
        }

       
        

       

    }
}
