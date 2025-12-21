using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
	public class AuthenticationController(IServiceManager serviceManager): ApiBaseController
	{
		[HttpPost("Register")]
		public async Task<ActionResult<UserResultDTO>> Register([FromBody] UserRegisterDTO userRegisterDTO)
			=> Ok(await serviceManager.AuthenticationService.RegisterAsync(userRegisterDTO));
		[HttpPost("Login")]
		public async Task<ActionResult<UserResultDTO>> Login([FromBody]UserLoginDTO login)
			=> Ok(await serviceManager.AuthenticationService.LoginAsync(login));
	}
}
