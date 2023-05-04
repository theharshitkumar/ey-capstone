using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/product_category")]
    public class Product_CategoryDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Product_Category> GetAll()
        {
            try
            {
                return objEntity.Product_Category;
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
            Product_Category objEmp = new Product_Category();
            try
            {
                objEmp = objEntity.Product_Category.Find(id);
                if (objEmp == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objEmp);
        }

        [HttpPost]
        [Route("InsertDetails")]
        public IHttpActionResult Insert(Product_Category data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Product_Category.Add(data);
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
        public IHttpActionResult UpdateDetails(Product_Category data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product_Category objprp = new Product_Category();
                objprp = objEntity.Product_Category.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;
                    objprp.Name = data.Name;
                    objprp.Description = data.Description;
                    objprp.Enabled = data.Enabled;
                    
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
            Product_Category delobj = objEntity.Product_Category.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.Product_Category.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}