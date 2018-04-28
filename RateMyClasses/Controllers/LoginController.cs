using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateMyClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateMyClasses.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace RateMyClasses.Controllers
{
	public class LoginController: Controller
	{

		private readonly CourseContext _context;
		public readonly ModeratorsContext _mcontext;

		public LoginController(CourseContext context, ModeratorsContext mcontext)
		{
			_context = context;
			_mcontext = mcontext;
		}

		public ActionResult Index(Boolean error = false)
		{ 
			ViewData["Title"] = "Login";
			ViewData["Message"] = "Enter your login information to access the moderation queue";

			if (error) {
				ViewData["Error"] = "Error: Your username or password was incorrect. Please re-enter your login information";
			}

			return View();
		}

		public ActionResult Verification(String username, String password)
		{

			string pw = password;

			// generate a 128-bit salt using a secure PRNG
			byte[] salt = new byte[128 / 8];
			Random r = new Random(pw.GetHashCode());
			r.NextBytes(salt);

			// Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: pw,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));

			var reviewToHide = (from m in _mcontext.Moderators
								select m);

			var allMods = reviewToHide;
			var selectedMods = allMods.Where(c => (c.name.ToLower().Equals(username.ToLower())) && (c.hash.Equals(hashed)));
			    
			if (selectedMods.ToList().Count() > -1) {
				return RedirectToAction("Index", "Moderator");	
			}

			else {
				return RedirectToAction("Index", new { error = true });
			}

		}

	}
}
