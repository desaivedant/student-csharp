using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Student015.Models;

namespace Student015.Controllers
{
    public class StudentController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VEDANT\Documents\DBStudent.mdf;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;Connect Timeout=30");

    public ActionResult GetStudents()
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VEDANT\Documents\DBStudent.mdf;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand("Select * from TBLStudent", con);
        List<Student> Students = new List<Student>();
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Student temp = new Student();
            temp.Id = reader.GetInt32(0);
            temp.Name = reader.GetString(1);
            temp.Course = reader.GetString(2);
            temp.Semester = reader.GetInt32(0);
            temp.BirthYear = reader.GetInt32(4);
            Students.Add(temp);
        }
        con.Close();
        return View("StudentList", Students);
    }
    public ActionResult GoToInsert()
    {
        return View("InsertStudent");
    }
    public ActionResult InsertStudent(Student s)
    {
        if (ModelState.IsValid)
        {
            SqlCommand cmd = new SqlCommand("insert into TBLStudent values ('" + s.Name + "','" + s.Course + "'," + s.Semester + "," + s.BirthYear + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("GetStudents");
        }
        return View("InsertStudent");
    }
    }
    }
