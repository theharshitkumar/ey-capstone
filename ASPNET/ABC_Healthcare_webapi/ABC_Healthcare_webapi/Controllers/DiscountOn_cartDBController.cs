using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/DiscountOn_cart")]
    public class DiscountOn_cartDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<DiscountOn_cart> GetAll()
        {
            try
            {
                return objEntity.DiscountOn_cart;
                
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
            DiscountOn_cart obj = new DiscountOn_cart();
            try
            {
                obj = objEntity.DiscountOn_cart.Find(id);
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
        public IHttpActionResult Insert(DiscountOn_cart data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.DiscountOn_cart.Add(data);
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
        public IHttpActionResult UpdateDetails(DiscountOn_cart data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DiscountOn_cart objprp = new DiscountOn_cart();
                objprp = objEntity.DiscountOn_cart.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;
                    objprp.Name = data.Name;
                    objprp.Description = data.Description;
                    objprp.id = data.id;
                    objprp.Name = data.Name;
                    objprp.Description = data.Description;
                    objprp.Discount_amount = data.Discount_amount;
                    objprp.Active = data.Active;
                    objprp.isPercentage = data.isPercentage;
                    objprp.min_cart_value = data.min_cart_value;
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
            DiscountOn_cart delobj = objEntity.DiscountOn_cart.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.DiscountOn_cart.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}