using Application.DTO;


namespace Application.Auth
{
	public interface IAuthService
    {
		public void Register(RegistrationRequest request);
        string Login(AuthRequest request);
        bool IsUsernameTaken(string username);
        bool IsEmailTaken(string email);

    }
}
