using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Assignment3.Code.DataModels;

namespace Assignment3.Code.Repositories
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        private readonly string _connectionString;

        public BlogDBRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DB_BlogPosts")
                ?? throw new ArgumentNullException(nameof(configuration), "Connection string 'DB_BlogPosts' not found.");
        }

        public BlogPost Get(int id)
        {
            BlogPost blogPost = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, Author, Title, Content, Timestamp FROM BlogPost WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        blogPost = new BlogPost
                        {
                            ID = reader.GetInt32(0),
                            Author = reader.GetString(1),
                            Title = reader.GetString(2),
                            Content = reader.GetString(3),
                            Timestamp = reader.GetDateTime(4)
                        };
                    }
                }
            }
            return blogPost;
        }

        public List<BlogPost> GetList()
        {
            var blogPosts = new List<BlogPost>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, Title, Content, Author, Timestamp FROM BlogPost", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        blogPosts.Add(new BlogPost
                        {
                            ID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Content = reader.GetString(2),
                            Author = reader.GetString(3),
                            Timestamp = reader.GetDateTime(4)
                        });
                    }
                }
            }

            return blogPosts;
        }

        public void Save(BlogPost entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(entity.ID == 0 ?
                    "INSERT INTO BlogPost (Author, Title, Content, Timestamp) VALUES (@Author, @Title, @Content, @Timestamp);" +
                    "SELECT CAST(scope_identity() AS int)" :
                    "UPDATE BlogPost SET Author = @Author, Title = @Title, Content = @Content, Timestamp = @Timestamp WHERE ID = @ID", connection);

                command.Parameters.AddWithValue("@Author", entity.Author);
                command.Parameters.AddWithValue("@Title", entity.Title);
                command.Parameters.AddWithValue("@Content", entity.Content);
                command.Parameters.AddWithValue("@Timestamp", entity.Timestamp);

                if (entity.ID != 0) command.Parameters.AddWithValue("@ID", entity.ID);

                if (entity.ID == 0)
                    entity.ID = (int)command.ExecuteScalar();
                else
                    command.ExecuteNonQuery();
            }
        }
    }
}
