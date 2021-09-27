using Microsoft.AspNetCore.Http;
using RestWithASPNET.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNET.Business {
    public interface IFileBusiness {
        public byte[] GetFile(string file);
        public Task<FileDetailsVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailsVO>> SaveFilesToDisk(IList<IFormFile> file);
    }
}
