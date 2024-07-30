using NetFilmx_Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoPurchaseRepository
    {

        List<VideoPurchase> GetAllVideoPurchases();
        List<VideoPurchase> GetVideoPurchasesByUserId(int userId);
        List<VideoPurchase> GetVideoPurchasesByVideoId(int videoId);

        VideoPurchase GetVideoPurchaseById(int videoPurchaseId);

        void AddVideoPurchase(VideoPurchase videoPurchase);
        void UpdateVideoPurchase(VideoPurchase videoPurchase);
        void DeleteVideoPurchase(int videoPurchaseId);

        bool IsVideoPurchaseExist(int videoPurchaseId);
        bool IsVideoPurchaseExist(int userId, int videoId);



    }
}
