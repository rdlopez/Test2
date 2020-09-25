using Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITestService
    {
        Task Update(UploadFile file);
        Task<IList<UploadFile>> GetAll();
    }
}