using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Infrastructure.Models;
using System.Linq;

namespace RepositoryPattern.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly IUserDetail _userdetail;
        public UserDetailController(IUserDetail userdetail)
        { _userdetail = userdetail; }



        // GET: UserDetail
        [HttpGet]
        public IActionResult Index()
        {
            var userdetail = _userdetail.GetAll();
            return View(userdetail);
        }
        [HttpPost]
        public IActionResult GetUserDetail()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); ;
                var sortColumn_direction = Request.Form["order[0][dir]"].FirstOrDefault();
                var search_value = Request.Form["search[value]"].FirstOrDefault();

                int pagesize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int Total_records = 0;

                var user_detail = (from UserDetail in _userdetail.GetAll() select UserDetail);
                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumn_direction))
                {
                    string sort_order = (sortColumn + "_" + sortColumn_direction).ToLower();
                    switch (sort_order)
                    {
                        case "name_desc":
                            user_detail = user_detail.OrderByDescending(x => x.Name);
                            break;
                        case "email_desc":
                            user_detail = user_detail.OrderByDescending(x => x.Email);
                            break;
                        case "email_asc":
                            user_detail = user_detail.OrderBy(x => x.Email);
                            break;
                        case "website_desc":
                            user_detail = user_detail.OrderByDescending(x => x.WebSite);
                            break;
                        case "website_asc":
                            user_detail = user_detail.OrderBy(x => x.WebSite);
                            break;
                        case "address_desc":
                            user_detail = user_detail.OrderByDescending(x => x.Address);
                            break;
                        case "address_asc":
                            user_detail = user_detail.OrderBy(x => x.Address);
                            break;
                        default:  // Name ascending 
                            user_detail = user_detail.OrderBy(x => x.Name);
                            break;
                    }

                }

                if (!string.IsNullOrEmpty(search_value))
                {
                    user_detail = user_detail.Where(m => m.Name.Contains(search_value) ||
                                                         m.Email.Contains(search_value) ||
                                                         m.WebSite.Contains(search_value) ||
                                                         m.Address.Contains(search_value));
                }
                Total_records = user_detail.Count();

                var data = user_detail.Skip(skip).Take(pagesize).ToList();
                var json_data = new { draw = draw, recordsFiltered = Total_records, data = data };
                return Ok(json_data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: UserDetail/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserDetail userdetail)
        {
            if (ModelState.IsValid)
            {
                _userdetail.Insert(userdetail);
                _userdetail.Save();
            }
            return View(userdetail);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var userdetail = _userdetail.GetById(Id);
            return View(userdetail);
        }

        [HttpPost]
        public IActionResult Delete(UserDetail userdetail)
        {
            _userdetail.Delete(userdetail);
            _userdetail.Save();
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var userdetail = _userdetail.GetById(Id);
            return View(userdetail);
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var userdetail = _userdetail.GetById(Id);
            return View(userdetail);
        }

        [HttpPost]
        public IActionResult Edit(UserDetail userdetail)
        {
            if (ModelState.IsValid)
            {
                _userdetail.Update(userdetail);
                _userdetail.Save();
            }
            return View();
        }


    }
}