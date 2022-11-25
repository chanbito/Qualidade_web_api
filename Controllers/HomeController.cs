using Qualidade_web_api.Models;
using Qualidade_web_api.View;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Qualidade_web_api.Controllers
{
    public class HomeController : ApiController
    {
        /// <summary>
        /// registra um usuario
        /// </summary>
        /// <param name=""></param>
        /// <returns>QR code em base64</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(string))]
        [AllowAnonymous]
        public IHttpActionResult NewUser(UserModel user)
        {
            try
            {
                var ret = UserView.inserir(user);
                if (ret)
                {
                    return InternalServerError();
                }
                return Ok(ret);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Busca usuario
        /// </summary>
        /// <param name=""></param>
        /// <returns>QR code em base64</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(string))]
        [AllowAnonymous]
        public IHttpActionResult GetUser()
        {
            var ret = UserView.get();
            if (ret == null)
            {
                return InternalServerError();
            }
            return Ok(ret);
        }


        /// <summary>
        /// Busca usuario
        /// </summary>
        /// <param name=""></param>
        /// <returns>QR code em base64</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(string))]
        [AllowAnonymous]
        public IHttpActionResult GetUserbyID(int user_ID)
        {
            var ret = UserView.get(user_ID);
            if (ret == null)
            {
                return InternalServerError();
            }
            return Ok(ret);
        }


        /// <summary>
        /// Busca usuario
        /// </summary>
        /// <param name=""></param>
        /// <returns>QR code em base64</returns>
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(string))]
        [AllowAnonymous]
        public IHttpActionResult UpdateUser([FromUri] int user_id, [FromBody] UserModel user)
        {
            try
            {
                var ret = UserView.Update(user_id, user);
                if (ret)
                {
                    return InternalServerError();
                }
                return Ok(ret);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Busca usuario
        /// </summary>
        /// <param name=""></param>
        /// <returns>QR code em base64</returns>
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(string))]
        [AllowAnonymous]
        public IHttpActionResult DeleteUser([FromUri] int user_id)
        {
            try
            {
                var ret = UserView.Delete(user_id);
                if (ret)
                {
                    return InternalServerError();
                }
                return Ok(ret);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}