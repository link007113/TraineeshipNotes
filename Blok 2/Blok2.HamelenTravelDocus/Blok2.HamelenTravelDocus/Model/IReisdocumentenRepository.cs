using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok2.HamelenTravelDocus.Model
{
    public interface IReisdocumentenRepository
    {
        IEnumerable<Reisdocument> GetAllReisdocumenten();

        IEnumerable<Reisdocument> GetAllOpenReisdocumenten();

        Reisdocument? GetReisDocumentByDocumentNumber(string documentNumber);

        bool UpdateStatusReisdocument(int reisdocumentId, string status);

        DocumentType GetReisDocumentType(string type);

        DocumentStatus GetReisDocumentStatus(string status);

        bool InsertNewReisDocument(Reisdocument reisdocument, string bsn, string medewerkerNaam, string type);

        bool DeleteReisDocument(int reisdocumentId);
    }
}