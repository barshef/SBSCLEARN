using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SBSCLEARN.Domain.Entities;
using SBSCLEARN.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSCLEARN.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertCustomerIntoDatabasee()
        {

            using var context = new ApplicationDbContext();
            var course = new Course();
            context.Courses.Add(course);
            Assert.AreEqual(EntityState.Added, context.Entry(course).State);
        }
    }
}
