using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/Order_Details")]
    public class Order_DetailsDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Order_Details> GetAll()
        {
            try
            {
                return objEntity.Order_Details;

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
            Order_Details obj = new Order_Details();
            try
            {
                obj = objEntity.Order_Details.Find(id);
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
        public IHttpActionResult Insert(Order_Details data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Order_Details.Add(data);
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
        public IHttpActionResult UpdateDetails(Order_Details data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Order_Details objprp = new Order_Details();
                objprp = objEntity.Order_Details.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;

                    objprp.customer_id = data.customer_id;
                    objprp.total = data.total;
                    objprp.discount = data.discount;
                    objprp.final_price = data.final_price;
                    objprp.product_list = data.product_list;



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
            Order_Details delobj = objEntity.Order_Details.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.Order_Details.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}