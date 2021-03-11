using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestingGuid.Models;

namespace TestingGuid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly TestingContext _context;
       // private readonly TestingContext _context1;

        public ManagerController(TestingContext context)
        {
            _context = context;
        }


        // Employee Search Based on Manager ID

          [HttpGet("{ManagerId}")]
          public async Task<ActionResult<IEnumerable<Testing>>> Getmid(int ManagerId)
          {
            //var emp = await _context.Testings.FirstOrDefaultAsync(i => i.MID == ManagerId);
            var emp = await (from t in _context.Testings
                   join s in _context.Testings on t.MID equals s.EID
                   where t.MID == ManagerId
                   select t).ToListAsync();
            return emp;
          }


        // Employee Search Based on Manager Name
         
       [HttpGet("Getmname/{ByManagerName}")]
          public async Task<ActionResult<IEnumerable<Testing>>> Getmname(string ByManagerName)
          {
              var query = await (from t in _context.Testings
                              join s in _context.Testings on t.MID equals s.EID
                              where s.Name == ByManagerName
                                 select t).ToListAsync();
              return query;

          }

        //Manager Name Search By Staring of the name
       
        [HttpGet("Getnamebyanywhere/{SerchEmpName}")]
         public async Task<ActionResult<IEnumerable<Testing>>> Getnamebyanywhere(string SerchEmpName)
          {
            var emp = await _context.Testings.Where(i => i.Name == SerchEmpName).ToListAsync();
            return emp;
          }

        //Manager Name Search By Staring of the name
        
        [HttpGet("Getstartstring/{ManagerNameByEmpStartString}")]

           public async Task<ActionResult<IEnumerable<dynamic>>> Getstartstring(string ManagerNameByEmpStartString)
           {
            // var emp = await _context.Testings.Where(i => i.Name.StartsWith(startstringwithmanagername)).ToListAsync();

            var emp =  await (from t in _context.Testings
                                 join s in _context.Testings on t.EID equals s.MID
                                 where s.Name.StartsWith(ManagerNameByEmpStartString)
                                 select new { EmpId = s.EID, EmpName = s.Name, ManagerID = s.MID, ManagerName = t.Name }).ToListAsync();
            return emp;
           }
        
        //Employee Name Search By Staring string of the name
        
                [HttpGet("Getstartstringonlyname/{EmpSrchStartString}")]
               public async Task<ActionResult<IEnumerable<Testing>>> Getstartstringonlyname(string EmpSrchStartString)

               {
                  var emp = await _context.Testings.Where(i => i.Name.StartsWith(EmpSrchStartString)).ToListAsync();
                  return emp;
               }

        //Employee Name Search By Ending string of the name

        [HttpGet("Getendingstring/{SrchManagerByEmpEndString}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> Getendingstring(string SrchManagerByEmpEndString)
        {
            //var emp = await _context.Testings.Where(i => i.Name.EndsWith(EndingString)).ToListAsync();

            var emp = await (from t in _context.Testings
                             join s in _context.Testings on t.MID equals s.EID
                             where t.Name.EndsWith(SrchManagerByEmpEndString)
                             select new { EmpId = t.EID,EmpName = t.Name, ManagerID = t.MID, ManagerName = s.Name}).ToListAsync();
            return emp;
         }
      
      }

    }