using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/DiscountOn_product")]
    public class DiscountOn_productDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<DiscountOn_product> GetAll()
        {
            try
            {
                return objEntity.DiscountOn_product;

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
            DiscountOn_product obj = new DiscountOn_product();
            try
            {
                obj = objEntity.DiscountOn_product.Find(id);
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
        public IHttpActionResult Insert(DiscountOn_product data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.DiscountOn_product.Add(data);
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
        public IHttpActionResult UpdateDetails(DiscountOn_product data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DiscountOn_product objprp = new DiscountOn_product();
                objprp = objEntity.DiscountOn_product.Find(data.id);
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
            DiscountOn_product delobj = objEntity.DiscountOn_product.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.DiscountOn_product.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}