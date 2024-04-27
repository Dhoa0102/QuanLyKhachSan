using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyKhachSan
{
    public class User
    {

        public static string connectString = @"Data Source=LAPTOP-T2D8QL38\SQLSV2;Initial Catalog=QuanLyKhachSan_Fix;Integrated Security=false;User ID={0};password={1}";
        public static string user = "";
        public static string pass = "";

        public static Boolean ConnectByUser(string username, string password)
        {
            try
            {
                SqlConnection connection = new SqlConnection(String.Format(connectString, username, password));
                connection.Open();
                user = username;
                pass = password;
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        public static string getRole()
        {
            var result = DataProvider.Instance.ExecuteScalar(String.Format("SELECT dbo.getRole('{0}')", user));
            return Convert.ToString(result);

        }
        /*CREATE FUNCTION getRole(@name nvarchar(50))
        RETURNS nvarchar(50)
        AS BEGIN

            RETURN(SELECT DatabaseRoleName FROM (SELECT DP1.name AS DatabaseRoleName,
            isnull (DP2.name, 'No members') AS DatabaseUserName
        FROM sys.database_role_members AS DRM
        RIGHT OUTER JOIN sys.database_principals AS DP1
            ON DRM.role_principal_id = DP1.principal_id
        LEFT OUTER JOIN sys.database_principals AS DP2
            ON DRM.member_principal_id = DP2.principal_id
        WHERE DP1.type = 'R'
        ) AS DBB WHERE DBB.DatabaseUserName=@name)
        END*/
        public static string getConnectionString()
        {
            return String.Format(connectString, user, pass);
        }

    }
}
