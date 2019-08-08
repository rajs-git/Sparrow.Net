﻿using Microsoft.AspNetCore.Mvc;
using Sparrow.AspNetCore.Tests.Data.Models;
using Sparrow.Core.Domain.Repositories;
using Sparrow.Core.Domain.Uow;
using System;

namespace Sparrow.AspNetCore.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUowManager _uowManager;
        private readonly IRepository<Blog, string> _blogResp;

        public ValuesController(IRepository<Blog, string> blogResp, IUowManager uowManager)
        {
            _blogResp = blogResp;
            _uowManager = uowManager;
        }

        [HttpGet]
        public ActionResult<int> Get()
        {
            using (var uow = _uowManager.Begin())
            {
                _blogResp.Insert(new Blog()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Author = "Raj",
                    Signature = "做到极致，便是大师",
                    CreationTime = DateTime.Now
                });

                uow.Complete();
            }

            return _blogResp.Count();
        }
    }
}
