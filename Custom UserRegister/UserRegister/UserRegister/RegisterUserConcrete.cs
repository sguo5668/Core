using UserRegister.Models;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegister
{
	public class RegisterUserConcrete : IRegisterUser
	{
		private DatabaseContext _context;

		public RegisterUserConcrete(DatabaseContext context)
		{
			_context = context;
		}

		public void Add(RegisterUser registeruser)
		{
			try
			{
				registeruser.UserID = 0;
				_context.RegisterUser.Add(registeruser);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public long GetLoggedUserID(RegisterUser registeruser)
		{
			try
			{
				var usercount = (from User in _context.RegisterUser
								 where User.Username == registeruser.Username && User.Password == registeruser.Password
								 select User.UserID).FirstOrDefault();

				return usercount;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool ValidateRegisteredUser(RegisterUser registeruser)
		{
			try
			{
				var usercount = (from User in _context.RegisterUser
								 where User.Username == registeruser.Username && User.Password == registeruser.Password
								 select User).Count();
				if (usercount > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool ValidateUsername(RegisterUser registeruser)
		{
			try
			{
				var usercount = (from User in _context.RegisterUser
								 where User.Username == registeruser.Username
								 select User).Count();
				if (usercount > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
