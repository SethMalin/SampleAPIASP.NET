using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class DatabaseContentRepo
    {
        List<Content> contentList = new List<Content>();
        Content content;
        string[] Temp;
        XYZ Position;
        XYZ Rotation;
        XYZ Scale;
        string posString;
        string rotString;
        string scalString;

        public List<Content> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = ("usp_GetAll");
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Content content = new Content();
                        content.ID = (int)dr["ID"];
                        if (dr["ContentType"] != DBNull.Value)
                        {
                            content.contentType = dr["ContentType"].ToString();
                        }
                        else
                        {
                            content.contentType = "";
                        }
                        if (dr["ScreenSpace"] != DBNull.Value)
                        {
                            content.screenSpace = dr["ScreenSpace"].ToString();
                        }
                        else
                        {
                            content.screenSpace = "";
                        }
                        if (dr["Name"] != DBNull.Value)
                        {
                            content.name = dr["Name"].ToString();
                        }
                        else
                        {
                            content.name = "";
                        }
                        if (dr["Shape"] != DBNull.Value)
                        {
                            content.shape = dr["Shape"].ToString();
                        }
                        else
                        {
                            content.shape = "";
                        }
                        if (dr["Position"] != DBNull.Value && dr["Rotation"] != DBNull.Value && dr["Scale"] != DBNull.Value)
                        {
                            Temp = dr["Position"].ToString().Split(',');
                            Position = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Rotation"].ToString().Split(',');
                            Rotation = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Scale"].ToString().Split(',');
                            Scale = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));
                            content.metaTransform = new MetaTransform(Position, Rotation, Scale);

                        }
                        else
                        {
                            content.metaTransform = null;
                        }    
                        contentList.Add(content);
                    }
                }
            }
            return contentList;
        }

        public Content GetByID(int contentID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = ("usp_GetByID");
                cmd.Parameters.AddWithValue("@ID", contentID);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        content = new Content();
                        content.ID = (int)dr["ID"];
                        if (dr["ContentType"] != DBNull.Value)
                        {
                            content.contentType = dr["ContentType"].ToString();
                        }
                        else
                        {
                            content.contentType = "";
                        }
                        if (dr["ScreenSpace"] != DBNull.Value)
                        {
                            content.screenSpace = dr["ScreenSpace"].ToString();
                        }
                        else
                        {
                            content.screenSpace = "";
                        }
                        if (dr["Name"] != DBNull.Value)
                        {
                            content.name = dr["Name"].ToString();
                        }
                        else
                        {
                            content.name = "";
                        }
                        if (dr["Shape"] != DBNull.Value)
                        {
                            content.shape = dr["Shape"].ToString();
                        }
                        else
                        {
                            content.shape = "";
                        }
                        if (dr["Position"] != DBNull.Value && dr["Rotation"] != DBNull.Value && dr["Scale"] != DBNull.Value)
                        {
                            Temp = dr["Position"].ToString().Split(',');
                            Position = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Rotation"].ToString().Split(',');
                            Rotation = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Scale"].ToString().Split(',');
                            Scale = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));
                            content.metaTransform = new MetaTransform(Position, Rotation, Scale);

                        }
                        else
                        {
                            content.metaTransform = null;
                        }
                    }
                }
            }return content;
        }

        public List<Content> GetByContentType(string _contentType)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = ("usp_GetByContentType");
                cmd.Parameters.AddWithValue("@ContentType", _contentType);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        content = new Content();
                        content.ID = (int)dr["ID"];
                        if (dr["ContentType"] != DBNull.Value)
                        {
                            content.contentType = dr["ContentType"].ToString();
                        }
                        else
                        {
                            content.contentType = "";
                        }
                        if (dr["ScreenSpace"] != DBNull.Value)
                        {
                            content.screenSpace = dr["ScreenSpace"].ToString();
                        }
                        else
                        {
                            content.screenSpace = "";
                        }
                        if (dr["Name"] != DBNull.Value)
                        {
                            content.name = dr["Name"].ToString();
                        }
                        else
                        {
                            content.name = "";
                        }
                        if (dr["Shape"] != DBNull.Value)
                        {
                            content.shape = dr["Shape"].ToString();
                        }
                        else
                        {
                            content.shape = "";
                        }
                        if (dr["Position"] != DBNull.Value && dr["Rotation"] != DBNull.Value && dr["Scale"] != DBNull.Value)
                        {
                            Temp = dr["Position"].ToString().Split(',');
                            Position = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Rotation"].ToString().Split(',');
                            Rotation = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Scale"].ToString().Split(',');
                            Scale = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));
                            content.metaTransform = new MetaTransform(Position, Rotation, Scale);

                        }
                        else
                        {
                            content.metaTransform = null;
                        }
                        contentList.Add(content);
                    }
                }
            }
            return contentList;
        }

        public List<Content> GetByScreenSpace(string _space)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = ("usp_GetByName");
                cmd.Parameters.AddWithValue("@ScreenSpace", _space);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        content = new Content();
                        content.ID = (int)dr["ID"];
                        if (dr["ContentType"] != DBNull.Value)
                        {
                            content.contentType = dr["ContentType"].ToString();
                        }
                        else
                        {
                            content.contentType = "";
                        }

                        if (dr["ScreenSpace"] != DBNull.Value)
                        {
                            content.screenSpace = dr["ScreenSpace"].ToString();
                        }
                        else
                        {
                            content.screenSpace = "";
                        }
                        if (dr["Name"] != DBNull.Value)
                        {
                            content.name = dr["Name"].ToString();
                        }
                        else
                        {
                            content.name = "";
                        }
                        if (dr["Shape"] != DBNull.Value)
                        {
                            content.shape = dr["Shape"].ToString();
                        }
                        else
                        {
                            content.shape = "";
                        }
                        if (dr["Position"] != DBNull.Value && dr["Rotation"] != DBNull.Value && dr["Scale"] != DBNull.Value)
                        {
                            Temp = dr["Position"].ToString().Split(',');
                            Position = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Rotation"].ToString().Split(',');
                            Rotation = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Scale"].ToString().Split(',');
                            Scale = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));
                            content.metaTransform = new MetaTransform(Position, Rotation, Scale);

                        }
                        else
                        {
                            content.metaTransform = null;
                        }
                        contentList.Add(content);
                    }
                }
            }
            return contentList;
        }

        public List<Content> GetByName(string _name)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = ("usp_GetByName");
                cmd.Parameters.AddWithValue("@Name", _name);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        content = new Content();
                        content.ID = (int)dr["ID"];
                        if (dr["ContentType"] != DBNull.Value)
                        {
                            content.contentType = dr["ContentType"].ToString();
                        }
                        else
                        {
                            content.contentType = "";
                        }

                        if (dr["ScreenSpace"] != DBNull.Value)
                        {
                            content.screenSpace = dr["ScreenSpace"].ToString();
                        }
                        else
                        {
                            content.screenSpace = "";
                        }
                        if (dr["Name"] != DBNull.Value)
                        {
                            content.name = dr["Name"].ToString();
                        }
                        else
                        {
                            content.name = "";
                        }
                        if (dr["Shape"] != DBNull.Value)
                        {
                            content.shape = dr["Shape"].ToString();
                        }
                        else
                        {
                            content.shape = "";
                        }
                        contentList.Add(content);
                        if (dr["Position"] != DBNull.Value && dr["Rotation"] != DBNull.Value && dr["Scale"] != DBNull.Value)
                        {
                            Temp = dr["Position"].ToString().Split(',');
                            Position = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Rotation"].ToString().Split(',');
                            Rotation = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Scale"].ToString().Split(',');
                            Scale = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));
                            content.metaTransform = new MetaTransform(Position, Rotation, Scale);

                        }
                        else
                        {
                            content.metaTransform = null;
                        }
                    }
                }
            }
            return contentList;
        }

        public List<Content> GetByShape(string _shape)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = ("usp_GetByShape");
                cmd.Parameters.AddWithValue("@Shape", _shape);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        content = new Content();
                        content.ID = (int)dr["ID"];
                        if (dr["ContentType"] != DBNull.Value)
                        {
                            content.contentType = dr["ContentType"].ToString();
                        }
                        else
                        {
                            content.contentType = "";
                        }

                        if (dr["ScreenSpace"] != DBNull.Value)
                        {
                            content.screenSpace = dr["ScreenSpace"].ToString();
                        }
                        else
                        {
                            content.screenSpace = "";
                        }
                        if (dr["Name"] != DBNull.Value)
                        {
                            content.name = dr["Name"].ToString();
                        }
                        else
                        {
                            content.name = "";
                        }
                        if (dr["Shape"] != DBNull.Value)
                        {
                            content.shape = dr["Shape"].ToString();
                        }
                        else
                        {
                            content.shape = "";
                        }
                        contentList.Add(content);
                        if (dr["Position"] != DBNull.Value && dr["Rotation"] != DBNull.Value && dr["Scale"] != DBNull.Value)
                        {
                            Temp = dr["Position"].ToString().Split(',');
                            Position = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Rotation"].ToString().Split(',');
                            Rotation = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));

                            Temp = dr["Scale"].ToString().Split(',');
                            Scale = new XYZ(Convert.ToSingle(Temp[0]), Convert.ToSingle(Temp[1]), Convert.ToSingle(Temp[2]));
                            content.metaTransform = new MetaTransform(Position, Rotation, Scale);

                        }
                        else
                        {
                            content.metaTransform = null;
                        }
                    }
                }
            }
            return contentList;
        }

        public void CreateContent(Content _newContent)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CreateContent";
                cmd.Parameters.AddWithValue("@ContentType", _newContent.contentType);
                cmd.Parameters.AddWithValue("@ScreenSpace", _newContent.screenSpace);
                cmd.Parameters.AddWithValue("@Name", _newContent.name);
                cmd.Parameters.AddWithValue("@Shape", _newContent.shape);
                posString = XYZToString.ConvertToString(_newContent.metaTransform.position);
                rotString = XYZToString.ConvertToString(_newContent.metaTransform.rotation);
                scalString = XYZToString.ConvertToString(_newContent.metaTransform.scale);
                cmd.Parameters.AddWithValue("@Position", posString);
                cmd.Parameters.AddWithValue("@Rotation", rotString);
                cmd.Parameters.AddWithValue("@Scale", scalString);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateContent(Content _updatedContent)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateContent";
                cmd.Parameters.AddWithValue("@ID", _updatedContent.ID);
                cmd.Parameters.AddWithValue("@ContentType", _updatedContent.contentType);
                cmd.Parameters.AddWithValue("@ScreenSpace", _updatedContent.screenSpace);
                cmd.Parameters.AddWithValue("@Name", _updatedContent.name);
                cmd.Parameters.AddWithValue("@Shape", _updatedContent.shape);
                posString = XYZToString.ConvertToString(_updatedContent.metaTransform.position);
                rotString = XYZToString.ConvertToString(_updatedContent.metaTransform.rotation);
                scalString = XYZToString.ConvertToString(_updatedContent.metaTransform.scale);
                cmd.Parameters.AddWithValue("@Position", posString);
                cmd.Parameters.AddWithValue("@Rotation", rotString);
                cmd.Parameters.AddWithValue("@Scale", scalString);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteContent (int _contentID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ContentSample"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeleteContent";
                cmd.Parameters.AddWithValue("@ID", _contentID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}