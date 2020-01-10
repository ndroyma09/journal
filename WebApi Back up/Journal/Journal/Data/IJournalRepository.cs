using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Data
{
    public interface IJournalRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Journal Hdr
        Task<JournalHdr[]> GetAllJhdrAsync(bool includeJdetail = false);
        Task<JournalHdr> GetJhdrAsync(int journalno, bool includeJdetail = false);
        Task<JournalHdr[]> GetAllByJournalDate(DateTime dateTime, bool includeTalks = false);

        //Journal Detail
        // Task<JournalDtl> GetJdetailByJournalnoAsync(string journal_no);
        //Task<JournalDtl[]> GetJdetailByMonikerAsync(string journal_no);
    }
}
