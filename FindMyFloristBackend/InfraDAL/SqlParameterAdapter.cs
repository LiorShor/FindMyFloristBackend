using DALContracts;
using System.Data.SqlClient;
namespace InfraDAL
{
    class SqlParameterAdapter : IParameter
    {
        public SqlParameter Parameter { get; set; }
    }
}