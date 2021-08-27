using DALContracts;
using ProjectDTO;

namespace ProjectContracts
{
    public interface IStoreService
    {
        public bool AddNewStor(StoreDTO i_StoreDetails);
        public bool isStoreExist(string i_StoreID);
        public string getOpeningHours(string i_StoreID);
        public string[] GetStores(string i_UserID);
        public string[] GetFavoriteStores(string i_UserID);
        public IDAL DALServices { get; set; }

    }
}
