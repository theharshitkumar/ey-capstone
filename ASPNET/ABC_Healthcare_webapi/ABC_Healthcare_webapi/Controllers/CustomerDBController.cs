using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/Customer")]
    public class CustomerDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Customer> GetAll()
        {
            try
            {
                return objEntity.Customers;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetAllById/{ID}")]
        public IHttpActionResult GetAllById(int id)
        {
            Customer obj = new Customer();
            try
            {
                obj = objEntity.Customers.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(obj);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("InsertDetails")]
        public IHttpActionResult Insert(Customer data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Customers.Add(data);
                objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateDetails")]
        public IHttpActionResult UpdateDetails(Customer data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer objprp = new Customer();
                objprp = objEntity.Customers.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;
                    objprp.first_name = data.first_name;
                    objprp.last_name = data.last_name;
                    objprp.email = data.email;
                    objprp.password = data.password;
                    objprp.phone_no = data.phone_no;
                }
                int i = this.objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteDetails")]
        public IHttpActionResult DeleteDelete(int id)
        {
            Customer delobj = objEntity.Customers.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.Customers.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}