using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;



namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/DiscountOn_category")]
    public class DiscountOn_categoryDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<DiscountOn_category> GetAll()
        {
            try
            {
                return objEntity.DiscountOn_category;

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
            DiscountOn_category obj = new DiscountOn_category();
            try
            {
                obj = objEntity.DiscountOn_category.Find(id);
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
        public IHttpActionResult Insert(DiscountOn_category data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.DiscountOn_category.Add(data);
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
        public IHttpActionResult UpdateDetails(DiscountOn_category data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DiscountOn_category objprp = new DiscountOn_category();
                objprp = objEntity.DiscountOn_category.Find(data.id);
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
            DiscountOn_category delobj = objEntity.DiscountOn_category.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.DiscountOn_category.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}