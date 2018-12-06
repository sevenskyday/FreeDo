using Dapper;
using Sample05.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Sample05
{
    class Program
    {
        private static readonly string connstr = "Data Source=LIU-COMPUTER\\MMSSQLSERVER;User ID=sa;Password=jsxh;Initial Catalog=test;Pooling=true;Max Pool Size=100;";
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            test_insert_comment();
            //test_mult_insert();
            //test_del();
            //test_mult_del();
            //test_update();
            //test_mult_update();
            //test_select_one();
            //test_select_list();
            test_select_content_with_comment();
            Console.Read();
        }

        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1",
            };
            using (var conn = new SqlConnection(connstr))
            {
                string sql_intsert = @"INSERT INTO [Content](title,[content],status,add_time,modify_time)
                                  VALUES (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_intsert, content);
                Console.WriteLine($"test_insert:插入了{result}条数据");
            }
        }
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                title = "批量插入标题1",
                content = "批量插入内容1",

            },
               new Content
            {
                title = "批量插入标题2",
                content = "批量插入内容2",

            },
            };
            using (var conn = new SqlConnection(connstr))
            {
                string sql_intsert = @"INSERT INTO [Content](title,[content],status,add_time,modify_time)
                                  VALUES (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_intsert, contents);
                Console.WriteLine($"test_mult_insert:插入了{result}条数据");
            }
        }
        static void test_del()
        {
            var content = new Content { id = 2 };
            using (var conn = new SqlConnection(connstr))
            {
                string sql_del = @"DELETE FROM [Content] WHERE (id = @id)";
                var result = conn.Execute(sql_del, content);
                Console.WriteLine($"test_del:删除了{result}条数据");
            }
        }
        static void test_mult_del()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=3,

            },
               new Content
            {
               id=4,
            },
            };
            using (var conn = new SqlConnection(connstr))
            {
                string sql_del = @"DELETE FROM [Content] WHERE (id = @id)";
                var result = conn.Execute(sql_del, contents);
                Console.WriteLine($"test_mult_del:删除了{result}条数据");
            }
        }
        static void test_update()
        {
            var content = new Content { id = 5, title = "标题5", content = "内容5" };
            using (var conn = new SqlConnection(connstr))
            {
                string sql_str = @"UPDATE [Content] SET title=@title,[content]=@content,modify_time=GETDATE() WHERE  ( id = @id)";
                var result = conn.Execute(sql_str, content);
                Console.WriteLine($"test_update：修改了{result}条数据");
            }
        }
        static void test_mult_update()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=6,
                title="批量修改标题6",
                content="批量修改内容6"

            },
               new Content
            {
               id=1,
                title="批量修改标题1",
                content="批量修改内容1"
               }
            };
            using (var conn = new SqlConnection(connstr))
            {
                string sql_str = @"UPDATE [Content] SET title=@title,[content]=@content,modify_time=GETDATE() WHERE  ( id = @id)";
                var result = conn.Execute(sql_str, contents);
                Console.WriteLine($"test_mult_update：修改了{result}条数据");
            }
        }

        static void test_select_one()
        {
            using (var conn = new SqlConnection(connstr))
            {
                string sql = @"select * from [dbo].[Content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql, new { id = 5 });
                Console.WriteLine($"test_select_one:搜索结果;{JsonConvert.SerializeObject(result)}");
            }

        }
        static void test_select_list()
        {
            using (var conn = new SqlConnection(connstr))
            {
                string sql = @"select * from [dbo].[Content] where id in @ids";
                var result = conn.Query<Content>(sql, new { ids = new int[] { 5, 6, 7 } });
                Console.WriteLine($"test_select_list:搜索结果;{ JsonConvert.SerializeObject(result)}");
            }
        }
        static void test_insert_comment()
        {
            var content = new Comment
            {
                content_id = 6,
                content = "评论666",
            };
            using (var conn = new SqlConnection(connstr))
            {
                string sql_intsert = @"INSERT INTO Comment(content_id,[content],add_time)
                                  VALUES (@content_id,@content,@add_time)";
                var result = conn.Execute(sql_intsert, content);
                Console.WriteLine($"test_insert_comment:插入了{result}条数据");
            }
        }
        static void test_select_content_with_comment()
        {
            using (var conn = new SqlConnection(connstr))
            {
                string sql = @"select* from content where id=@id;select * from comment where content_id=@id ";
                using (var result = conn.QueryMultiple(sql, new { id = 6 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithCommnet>();
                    content.comments = result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_comment:搜索结果:{JsonConvert.SerializeObject(content)}");
                }
            }
        }
    }
}
