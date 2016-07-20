namespace DataAccess.Service
{
    using System.Linq;
    using Repository;
    using Entity;

    public class Auth
    {
        public UserEntity LoggedUser { get; private set; }

        public void AuthenticateUser(string username, string password)
        {
            UserRepository userRepository = new UserRepository();
            LoggedUser = userRepository.GetAll(u=>u.Username==username&&u.Password== password).FirstOrDefault();
        }
    }
}
