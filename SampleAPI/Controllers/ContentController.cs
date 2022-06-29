using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using SampleAPI.Models;


namespace SampleAPI.Controllers
{
    public class ContentController : ApiController
    {
        DatabaseContentRepo repo = new DatabaseContentRepo();
        //DummyContentRepo repo = new DummyContentRepo();

        [Route ("contents/")]//not grammatically correct but distinguishes it from the POST later
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [Route("content/{_contentID}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get (int _contentID)
        {
            Content _content = repo.GetByID(_contentID);

            if (_content == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_content);
            }

        }

        [Route("content/type/{_contentType}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByContentType(string _contentType)
        {
            List<Content> _results = repo.GetByContentType(_contentType);
            if (_results.Count == 0)
            {
                return NotFound();
            }
            return Ok(_results);
        }

        [Route("content/space/{_screenSpace}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByScreenSpace(string _screenSpace)
        {
            List<Content> _results = repo.GetByScreenSpace(_screenSpace);
            if (_results.Count == 0)
            {
                return NotFound();
            }
            return Ok(_results);
        }

        [Route("content/name/{_name}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByName(string _name)
        {
            List<Content> _results = repo.GetByName(_name);
            if (_results.Count == 0)
            {
                return NotFound();
            }
            return Ok(_results);
        }

        [Route("content/type/{_contentType}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByShape(string _shape)
        {
            List<Content> _results = repo.GetByShape(_shape);
            if (_results.Count == 0)
            {
                return NotFound();
            }
            return Ok(_results);
        }

        [Route("content/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContent(Content _request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.CreateContent(_request);

            return Created($"content/{_request.ID}", _request);

        }

        [Route("content/{_contentID}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateContent(int _contentID, Content _request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.UpdateContent(_request);
            return Ok();
        }

        [Route("content/{_contentID}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteContent(int _contentID)
        {
            Content _content = repo.GetByID(_contentID);

            if (_content == null)
            {
                return NotFound();
            }

            repo.DeleteContent(_contentID);
            return Ok();
        }
    }
}