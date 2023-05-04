using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
//using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
//using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
//using RouteAttribute = System.Web.Http.RouteAttribute;


namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/product")]
    public class ProductController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Product> GetAll()
        {
            try
            {
                return objEntity.Products;
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
            Product obj = new Product();
            try
            {
                obj = objEntity.Products.Find(id);
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
        public IHttpActionResult Insert(Product data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Products.Add(data);
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
        public IHttpActionResult UpdateDetails(Product data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product objprp = new Product();
                objprp = objEntity.Products.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;
                    objprp.Name = data.Name;
                    objprp.Image = data.Image;
                    objprp.Description = data.Description;
                    objprp.Short_description = data.Short_description;
                    objprp.SKU = data.SKU;
                    objprp.Category_id = data.Category_id;
                    objprp.Quantity = data.Quantity;
                    objprp.MRP = data.MRP;
                    objprp.Selling_price = data.Selling_price;
                    objprp.Enabled = data.Enabled;
                    objprp.Seller_id = data.Seller_id;

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
            Product delobj = objEntity.Products.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.Products.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}