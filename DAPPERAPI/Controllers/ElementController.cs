using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAPPERAPI.DAL;
using DAPPERAPI.ML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DAPPERAPI.Controllers
{
    [Route("api/[controller]")]
    public class ElementController : ControllerBase
    {
        IConfiguration _config;

        public ElementController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public List<Element> getAllElement()
        {
            ElementDAL elDAL = new ElementDAL(_config);
            return elDAL.getAllElement();
        }

        [HttpPost]
        [Route("/searchElByID")]
        public Element getElementByID([FromBody] int elID)
        {
            ElementDAL elDAL = new ElementDAL(_config);
            
            return elDAL.getElementByID(elID);
        }

    }
}

