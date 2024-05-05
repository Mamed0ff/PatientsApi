using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientsApi.Models;
using PatientsApi.Data;

namespace PatientsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApiContext _context;
        public PatientsController(ApiContext context)
        {
            _context = context;
        }
        //Create and Edit
        [HttpPost]
        public JsonResult CreateEdit(Patients patient)
        {
            if (patient.Id == 0) 
            {
                _context.Patients.Add(patient);
            
            }else
            {
                var patientsInDb = _context.Patients.Find(patient.Id);

                if(patientsInDb == null) 
                {
                    return new JsonResult(NotFound());
                }
                patientsInDb = patient;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(patient));
        }
        // Get and Get All Methods
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Patients.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }
        [HttpGet]
        public JsonResult GetAll() 
        {
            var result=_context.Patients.ToList();
            return new JsonResult(result);
        }

        // Delete methods
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Patients.Find(id);
            if(result == null)
            {
                    return new JsonResult(NotFound());
            }
            _context.Patients.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

    }
}
