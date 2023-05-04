//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http;


//namespace ABC_Healthcare_webapi.Controllers
//{
//    [RoutePrefix("api/abcHealthcare/Admin_type")]
//    public class Admin_typeDBController : ApiController
//    {
//        ABC_Healthcare_Entities objEntity = new ABC_Healthcare_Entities();

//        [HttpGet]
//        [Route("GetAll")]
//        public IQueryable<Admin_type> GetAll()
//        {
//            try
//            {
//                return objEntity.Admin_type;

//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        [HttpGet]
//        [Route("GetAllById/{ID}")]
//        public IHttpActionResult GetAllById(int id)
//        {
//            Admin_type obj = new Admin_type();
//            try
//            {
//                obj = objEntity.Admin_type.Find(id);
//                if (obj == null)
//                {
//                    return NotFound();
//                }
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            return Ok(obj);
//        }

//        [HttpPost]
//        [Route("InsertDetails")]
//        public IHttpActionResult Insert(Admin_type data)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            try
//            {
//                objEntity.Admin_type.Add(data);
//                objEntity.SaveChanges();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            return Ok(data);
//        }

//        [HttpPost]
//        [Route("UpdateDetails")]
//        public IHttpActionResult UpdateDetails(Admin_type data)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                Admin_type objprp = new Admin_type();
//                objprp = objEntity.Admin_type.Find(data.id);
//                if (objprp != null)
//                {
//                    objprp.id = data.id;

//                    objprp.admin_type = data.admin_type;
//                    objprp.permission = data.permission;
//                }
//                int i = this.objEntity.SaveChanges();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            return Ok(data);
//        }

//        [HttpDelete]
//        [Route("DeleteDetails")]
//        public IHttpActionResult DeleteDelete(int id)
//        {
//            Admin_type delobj = objEntity.Admin_type.Find(id);
//            if (delobj == null)
//            {
//                return NotFound();
//            }
//            objEntity.Admin_type.Remove(delobj);
//            objEntity.SaveChanges();

//            return Ok(delobj);
//        }
//    }
//}