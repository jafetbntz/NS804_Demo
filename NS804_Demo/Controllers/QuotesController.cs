using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using NS804_Demo.Models;
using NS804_Demo.Repository;
using NS804_Demo.ViewModels;

namespace NS804_Demo.Controllers
{
    public class QuotesController : BaseController
    {
        private readonly GenericRepository<Quote, long> _repository;


        public QuotesController() : base()
        {
            _repository = new GenericRepository<Quote, long>(_db);
        }

        // GET: api/Quotes
        [AllowAnonymous]
        public IQueryable<Quote> GetQuotes()
        {
            return _repository.Get();
        }

        // GET: api/Quotes/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult GetQuote(long id)
        {
            Quote quote = _repository.GetById(id);

            if (quote == null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        // PUT: api/Quotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuote(long id, Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quote.Id)
            {
                return BadRequest();
            }


            quote.LastUpdate = DateTime.Now;
            quote.UpdatedBy = GetCurrentUser();

            var wasUpdated = false;

            try
            {
                wasUpdated = _repository.Update(id, quote);
            }
            catch (Exception error)
            {
                if (!_repository.Exists(id))
                {
                    return NotFound();
                }
                throw error;
            }

            var body = new CommonBooleanResponse(wasUpdated);

            if (_isDebugModeOn)
            {   
                body.Messages = _repository.ErrorMessages;
            }
            return Ok(body);
        }



        // POST: api/Quotes
        [ResponseType(typeof(Quote))]
        public IHttpActionResult PostQuote(Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            quote.CreatedBy = GetCurrentUser();
            quote.UpdatedBy = quote.CreatedBy;

            _repository.Save(quote);

            return CreatedAtRoute("DefaultApi", new { id = quote.Id }, quote);
        }

        // DELETE: api/Quotes/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult DeleteQuote(long id)
        {

            var wasDeleted = _repository.Delete(id);

            var body = new CommonBooleanResponse(wasDeleted);

            if (_isDebugModeOn)
            {
                body.Messages = _repository.ErrorMessages;
            }
            return Ok(body);
        }



    }
}