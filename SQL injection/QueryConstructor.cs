﻿// QueryConstructor.cs

public class QueryConstructor {

  public QueryConstructor() {
    client = new PostgreSQL_Client("small university", "postgres", "abcd_1234");
    // retain university database
    // but change username and password
  }
 
  public PostgreSQL_Client client;

  // method definitions

  // dynamicQuery()
  // Get user-defined query, send query to db

  public void dynamicQuery() {
    // defining the query 
    Console.Write("Please type any SQL query: ");
    string? sql = Console.ReadLine();
  
    // printing query string to console
    Console.Write("Query to be executed: ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(sql+ "\n");
    Console.ForegroundColor = ConsoleColor.White;

    // executing query
    client.query(sql);
  } // end method dynamicQuery() 

  // composedQuery()
  // Get dynamic part from user,
  // then compose dynamic and static part,
  // and send query to db

  virtual public void composedQuery() {
    // defining the query
    string staticSQLbefore = "select * from course c where c.course_id ilike '%";
    Console.Write("Please type id of a course: ");
    string? user_defined = Console.ReadLine();
    string staticSQLafter = "%' and c.dept_name != 'Biology'";
    string sql = staticSQLbefore + user_defined + staticSQLafter;

    // printing query string to console
    Console.Write("Query to be executed: " + staticSQLbefore);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(user_defined);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(staticSQLafter+ "\n");

    // executing query
    client.query(sql);
  }

  virtual public void safeComposedQuery() {
    string name = "@1";
    string staticSQLbefore = "select * from safe_course(";
    Console.WriteLine("Please type id of a couse: ");
    string? user_defined = Console.ReadLine();
    string staticSQLafter = ")";
    string sql = staticSQLbefore + name + staticSQLafter;

    // printing query string to console
    Console.Write("Query to be executed: " + staticSQLbefore);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(user_defined);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(staticSQLafter+ "\n");

    // executing query
    client.query(sql, "1", user_defined);
  }
}
