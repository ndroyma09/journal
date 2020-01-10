using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingJournal.Controllers

{
    [Route("api[controller]")]
    public class JounalController :ControllerBase
    {
        public object Get()
        {
            return Ok();
        }
    }
}
