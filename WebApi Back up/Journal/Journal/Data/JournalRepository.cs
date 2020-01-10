using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Journal.Data
{
    public class JournalRepository : IJournalRepository
    {
        private readonly JournalContext _context;
        private readonly ILogger<JournalRepository> _logger;

        public JournalRepository(JournalContext context, ILogger<JournalRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }


        //Retrieve all from journal hdr and jdetail
        public async Task<JournalHdr[]> GetAllJhdrAsync(bool includeJdetail = false)
        {
            _logger.LogInformation($"Getting all Camps");

            IQueryable<JournalHdr> query = _context.JournalHdr;
                //.Include(c => c.JournalDetail);

            if (includeJdetail)
            {
                query = query
                  .Include(c => c.JournalDetail);
            }

            //Order It
            query = query.OrderByDescending(c => c.JournalDate);

           
            return await query.ToArrayAsync();
        }
          
        //Get by journal no
        public async Task<JournalHdr> GetJhdrAsync(int journalno, bool includeJdetail = false)
        {
            _logger.LogInformation($"Getting a Journal for {journalno}");

            IQueryable<JournalHdr> query = _context.JournalHdr;
                

            if (includeJdetail)
            {
                query = query.Include(c => c.JournalDetail);
                  
            }

            // Query It
            query = query.Where(c => c.JournalNo == journalno);

            return await query.FirstOrDefaultAsync();
        }

        //Get by journal date
        public async Task<JournalHdr[]> GetAllByJournalDate(DateTime dateTime, bool includeTalks = false)
        {
            _logger.LogInformation($"Getting all Journal by Journal Date");

            IQueryable<JournalHdr> query = _context.JournalHdr;
                

            if (includeTalks)
            {
                query = query
                  .Include(c => c.JournalDetail);
            }

            // Order It
            query = query.OrderByDescending(c => c.JournalDate)
              .Where(c => c.JournalDate.Date == dateTime.Date);

            return await query.ToArrayAsync();
        }


    }
}
