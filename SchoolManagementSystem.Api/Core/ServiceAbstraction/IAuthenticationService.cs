
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAbstraction
{
	public interface IAuthenticationService
	{
		Task<UserResultDTO> LoginAsync(UserLoginDTO userLogin);
		Task<UserResultDTO> RegisterAsync(UserRegisterDTO userRegister);

	}
}
