using Journal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Journal.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Journal.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JournalController(IJournalRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        // GET api/values V1.0
        [HttpGet]
        public async Task<ActionResult<JournalModel[]>> Get(bool includeJdetail = false)
        {
            try
            {
                var results = await _repository.GetAllJhdrAsync(includeJdetail);

                //CampModel[] models = _mapper.Map<CampModel[]>(results);
                return _mapper.Map<JournalModel[]>(results);

                //return Ok(models);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        //Retrieve by Journal no
        //Version 1.0
        [HttpGet("{journalno}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<JournalModel>> Get(int journalno)
        {
            try
            {
                var result = await _repository.GetJhdrAsync(journalno);

                if (result == null) return NotFound();

                return _mapper.Map<JournalModel>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        //Retrieve by Journal no
        //Version 1.1
        [HttpGet("{journalno}")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<JournalModel>> Get11(int journalno)
        {
            try
            {
                var result = await _repository.GetJhdrAsync(journalno, true);

                if (result == null) return NotFound();

                return _mapper.Map<JournalModel>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpGet("journaldate")]
        public async Task<ActionResult<JournalModel[]>> SearchByDate(DateTime theDate, bool includeTalks = false)
        {
            try
            {
                var results = await _repository.GetAllByJournalDate(theDate, includeTalks);

                if (!results.Any()) return NotFound();

                return _mapper.Map<JournalModel[]>(results);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }



        // POST api/values
        public async Task<ActionResult<JournalModel>> Post(JournalModel model)

        {
            try
            {
                //check journal no if already in use
                var existing = await _repository.GetJhdrAsync(model.JournalNo);
                if (existing != null)
                {
                    return BadRequest("Journal no. not in use");
                }

                var location = _linkGenerator.GetPathByAction("Get",
                                             "Journal",
                new { journalno = model.JournalNo });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use the current moniker");
                }

                //Create New Journal
                var journal = _mapper.Map<JournalHdr>(model);
                _repository.Add(journal);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/journal/{journal.JournalNo}", _mapper.Map<JournalModel>(journal));

                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        //PUT api/values
        [HttpPut("{journalno}")]
        public async Task<ActionResult<JournalModel>> Put(int journalno, JournalModel model)
        {
            try
            {
                var oldJournal = await _repository.GetJhdrAsync(journalno);
                if (oldJournal == null) return NotFound($"Could not find journal with journal no of {journalno}");

                _mapper.Map(model, oldJournal);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<JournalModel>(oldJournal);
                }

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        //Delete
        [HttpDelete("{journalno}")]
        public async Task<IActionResult> Delete(int journalno)
        {
            try
            {
                var oldJournal = await _repository.GetJhdrAsync(journalno);
                if (oldJournal == null) return NotFound();

                _repository.Delete(oldJournal);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete the journal");

             }
        }
    }
