using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Service.ConcreteSpecifications
{
    public static class StudentSpecifications
    {
        // 🔹 Specification: Get all students with needed includes
        public static Func<IQueryable<Student>, IQueryable<Student>> WithDetails()
        {
            return query => query
                .Include(s => s.Grade)
                .Include(s => s.User)
                .Include(s => s.Parent)
                .Include(s => s.Class);
        }

        // 🔹 Specification: Get student by id with details
        public static Func<IQueryable<Student>, IQueryable<Student>> ByIdWithDetails(int id)
        {
            return query => query
                .Where(s => s.Id == id)
                .Include(s => s.Grade)
                .Include(s => s.User)
                .Include(s => s.Parent)
                .Include(s => s.Class);
        }
    }
}
