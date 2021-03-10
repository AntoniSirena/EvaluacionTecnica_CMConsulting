using EvaluacionTecnica.Base;
using EvaluacionTecnica.Repository;
using EvaluacionTecnica.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvaluacionTecnica.Controllers.Generic
{
    public class GenericApiController<T> : ApiController where T : class
    {

        private IGenericRepository<T> repository;

        List<dynamic> RecordsList = new List<dynamic>();

        Response response = new Response();

        public GenericApiController()
        {
            this.repository = new GenericRepository<T>();
        }


        [HttpGet]
        [Route("GetAll")]
        public virtual IHttpActionResult GetAll()
        {
            dynamic Entities = repository.GetAll();

            foreach (var item in Entities)
            {
                if (item.IsActive)
                {
                    RecordsList.Add(item);
                }
            }

            if (RecordsList.Count() == 0)
            {
                return NotFound();
            }

            var result = RecordsList.OrderByDescending(i => i.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public virtual IHttpActionResult GetById(int id)
        {
            dynamic entity = repository.GetById(id);

            bool isAtive = false;

            if (entity != null)
            {
                isAtive = entity.IsActive;
            }

            if (entity == null || isAtive == false)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        [Route("Create")]
        public virtual IHttpActionResult Create(dynamic entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dynamic result = repository.Create(entity);
                    repository.Save();

                    response.Message = InternalMessagingCode.Constants.Messages.Message200;
                    response.Data = result.Id;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Code = InternalMessagingCode.Constants.Errors.CodeError500;
                response.Message = InternalMessagingCode.Constants.Errors.MessageError500;
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("Update")]
        public virtual IHttpActionResult Update(dynamic entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Update(entity);
                    repository.Save();

                    response.Message = InternalMessagingCode.Constants.Messages.Message201;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Code = InternalMessagingCode.Constants.Errors.CodeError500;
                response.Message = InternalMessagingCode.Constants.Errors.MessageError500;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public virtual IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = repository.GetById(id);

                if (entity == null)
                {
                    return NotFound();
                }

                repository.Delete(id);
                repository.Save();

                response.Message = InternalMessagingCode.Constants.Messages.Message202;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Code = InternalMessagingCode.Constants.Errors.CodeError500;
                response.Message = InternalMessagingCode.Constants.Errors.MessageError500;
            }
            return Ok(response);

        }

    }
}
