using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ABC_Healthcare_webapi.Controllers
{
    [RoutePrefix("api/abcHealthcare/Admin_User")]

    public class Admin_UserDBController : ApiController
    {
        ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Admin_User> GetAll()
        {
            try
            {
                return objEntity.Admin_User;

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
            Admin_User obj = new Admin_User();
            try
            {
                obj = objEntity.Admin_User.Find(id);
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
        public IHttpActionResult Insert(Admin_User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Admin_User.Add(data);
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
        public IHttpActionResult UpdateDetails(Admin_User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Admin_User objprp = new Admin_User();
                objprp = objEntity.Admin_User.Find(data.id);
                if (objprp != null)
                {
                    objprp.id = data.id;
                    objprp.username = data.username;
                    objprp.password = data.password;
                    objprp.first_name = data.first_name;
                    objprp.last_name = data.last_name;
                    objprp.admin_type_id = data.admin_type_id;
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
            Admin_User delobj = objEntity.Admin_User.Find(id);
            if (delobj == null)
            {
                return NotFound();
            }
            objEntity.Admin_User.Remove(delobj);
            objEntity.SaveChanges();

            return Ok(delobj);
        }
    }
}