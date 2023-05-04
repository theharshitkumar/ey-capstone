using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/Customer_Address")]
    public class Customer_AddressDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Customer_Address> GetAll()
        {
            try
            {
                return objEntity.Customer_Address;

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
            Customer_Address obj = new Customer_Address();
            try
            {
                obj = objEntity.Customer_Address.Find(id);
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

        [HttpPost]
        [Route("InsertDetails")]
        public IHttpActionResult Insert(Customer_Address data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Customer_Address.Add(data);
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
        public IHttpActionResult UpdateDetails(Customer_Address data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer_Address objprp = new Customer_Address();
                objprp = objEntity.Customer_Address.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;
                    objprp.customer_id = data.customer_id;
                    objprp.first_name = data.first_name;
                    objprp.last_name = data.last_name;
                    objprp.address_line1 = data.address_line1;
                    objprp.address_line2 = data.address_line2;
                    objprp.city = data.city;
                    objprp.state = data.state;
                    objprp.landmark = data.landmark;
                    objprp.pincode = data.pincode;
                    objprp.country = data.country;
                    objprp.mobile_no = data.mobile_no;
                    objprp.isHome = data.isHome;
                    objprp.isOffice = data.isOffice;
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
            Customer_Address delobj = objEntity.Customer_Address.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.Customer_Address.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}