using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/Cart")]
    public class CartDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Cart> GetAll()
        {
            try
            {
                return objEntity.Carts;

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
            Cart obj = new Cart();
            try
            {
                obj = objEntity.Carts.Find(id);
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
        public IHttpActionResult Insert(Cart data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Carts.Add(data);
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
        public IHttpActionResult UpdateDetails(Cart data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Cart objprp = new Cart();
                objprp = objEntity.Carts.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;
                    objprp.customer_id = data.customer_id;
                    objprp.product_list = data.product_list;
                    objprp.total = data.total;
                    objprp.discount = data.discount;
                    objprp.final_price = data.final_price;
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
            Cart delobj = objEntity.Carts.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.Carts.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}