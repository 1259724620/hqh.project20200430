using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hqh.project.Application.Contract.Services;
using hqh.project.Common;
using hqh.project.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace hqh.project.web.Controllers
{
    public class UserController : AbpController
    {
        /// <summary>
        ///新增或编辑用户
        /// </summary>
        /// <returns></returns>
        public async Task<Result> AddEditUser([FromBody]AddEditUserDto input, [FromServices]IUserService service)
        {
            return await service.AddEditUser(input);
        }
    }
}