
namespace Service
{
	public class AuthenticationService(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : IAuthenticationService
	{
		public async Task<UserResultDTO> LoginAsync(UserLoginDTO userLogin)
		{
			var user = await userManager.FindByEmailAsync(userLogin.Email);
			// Exception Handel
			//if (user == null) throw new UnAuthorizedException("Email Doesn't Exist");

			var result = await userManager.CheckPasswordAsync(user, userLogin.Password);

			// Exception Handel
			if (!result) return new UserResultDTO("","","");
			return new UserResultDTO(
				user.Email,
				user.UserName,
				await CreateTokenAsync(user: user)
				);
		}

		public async Task<UserResultDTO> RegisterAsync(UserRegisterDTO userRegister)
		{

			var user = new IdentityUser()
			{
				Email = userRegister.Email,
				UserName = userRegister.UserName,
				PhoneNumber = userRegister.PhoneNumber,

			};

			var result = await userManager.CreateAsync(user, userRegister.Password);
			//if (!result.Succeeded)
			//{
			//	var errors = result.Errors.Select(e => e.Description).ToList();

			//	throw new ValidationException(errors);
			//}
			var identityResult = await userManager.AddToRoleAsync(user, userRegister.Role);


			return new UserResultDTO(
						 user.Email,
						 user.UserName,
						 await CreateTokenAsync(user)
						 );

		}

		private async Task<string> CreateTokenAsync(IdentityUser user)
		{
			var issuer = configuration.GetSection("JwtOptions")["Issure"];
			var expire = DateTime.UtcNow.AddDays(double.Parse(configuration.GetSection("JwtOptions")["DurationInDays"]));
			var audience = configuration.GetSection("JwtOptions")["Audience"];
			var secretKey = configuration.GetSection("JwtOptions")["SecretKey"];
			var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
			var roles = await userManager.GetRolesAsync(user);
			var role = roles.FirstOrDefault();
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, role)
			};
			var token = new JwtSecurityToken(
					signingCredentials: signingCredentials,
					issuer: issuer,
					audience: audience,
					expires: expire,
					claims: claims);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
