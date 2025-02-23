using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Buisness.Abastraction;
using Buisness.Dtos;
using Core.Models;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using DataAccess.Enums;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Buisness.Concrete
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private ApiResponse _apiResponse;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private string secretkey;

        public UserService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager,IMapper mapper,UserManager<ApplicationUser> usermanager,ApiResponse apiResponse,IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _roleManager = roleManager;
            _apiResponse = apiResponse;
            _userManager = usermanager;
            secretkey = configuration.GetValue<string>("Secretkey:jwt" ?? "hfhbfbyefyygGGgy67Yuh");
        }
        public async Task<ApiResponse> Login(LoginRequestDto model)
        {
       
            var userfromDb=_context.ApplicationUsers.FirstOrDefault(u=>u.Email.ToLower()==model.Email.ToLower());

            if (userfromDb != null) {
                bool Isvalid = await _userManager.CheckPasswordAsync(userfromDb, model.Password);
                if (!Isvalid) {

                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages.Add("your entry information is not correct");
                    return _apiResponse;

                }
                var role = await _userManager.GetRolesAsync(userfromDb);
                JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(secretkey);
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,userfromDb.Id),
                    new Claim(ClaimTypes.Email,userfromDb.Email ?? ""),
                    new Claim(ClaimTypes.Role,role.FirstOrDefault() ?? "admin"),
                    new Claim("fullName",userfromDb.FullName)
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256),
                };
                
                SecurityToken token= tokenHandler.CreateToken(tokenDescriptor);
                LoginResponseModel _model = new LoginResponseModel()
                {
                    Email=userfromDb.Email,
                    Token=tokenHandler.WriteToken(token),
                };
                _apiResponse.Result = _model;
                _apiResponse.StatusCode=HttpStatusCode.OK;
                _apiResponse.IsSuccess=true;
                return _apiResponse;    
            }
            _apiResponse.IsSuccess= false;
            _apiResponse.ErrorMessages.Add("Oops!  something went wrong.");

            return _apiResponse;
        }

        public async Task<ApiResponse> Register(RegisterRequestDto model)
        {
            var userFromDB=_context.ApplicationUsers.FirstOrDefault(u=>u.Email.ToLower()==model.Email.ToLower());
            if (userFromDB != null) {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("User Already Exist");
                return _apiResponse;


            
            }
         //   var user=_mapper.Map<ApplicationUser>(model);
            var user = new ApplicationUser()
            {
                ProfilePicture=model.Email,
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded) { 
            
            var isTrue= _roleManager.RoleExistsAsync(UserType.Adminstrator.ToString()).GetAwaiter().GetResult();
                if (!isTrue) { 
                
                await _roleManager.CreateAsync(new IdentityRole(UserType.Adminstrator.ToString()));
                await _roleManager.CreateAsync(new IdentityRole(UserType.Seller.ToString()));
               await _roleManager.CreateAsync(new IdentityRole(UserType.Normal.ToString()));

                }

                if (model.UserType.ToLower() == UserType.Adminstrator.ToString().ToLower())
                    {
                      await  _userManager.AddToRoleAsync(user, UserType.Adminstrator.ToString());


                    }
                  if (model.UserType.ToLower()==UserType.Seller.ToString().ToLower()) {
                        await _userManager.AddToRoleAsync(user, UserType.Seller.ToString());
                    }
                    else {
                        await _userManager.AddToRoleAsync(user, UserType.Normal.ToString());
                    }
                    _apiResponse.StatusCode = HttpStatusCode.Created;
                    _apiResponse.IsSuccess = true;
                    return _apiResponse;




           


            }
            foreach (var err in result.Errors)
            {
                _apiResponse.ErrorMessages.Add(err.ToString());

            }
            return _apiResponse;

        }
    }
}
