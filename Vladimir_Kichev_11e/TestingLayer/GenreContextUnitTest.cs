using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestingLayer
{
    public class GenreContextUnitTest
    {
        private GamingDbContext dbContext;
        private GenreContext genreContext;
        DbContextOptionsBuilder builder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new GamingDbContext(builder.Options);
            genreContext = new GenreContext(dbContext);
        }

        [Test]
        public void TestCreateGenre()
        {
            int genresBefore = genreContext.ReadAll().Count();

            genreContext.Create(new Genre("RPG"));

            int genresAfter = genreContext.ReadAll().Count();

            Assert.IsTrue(genresBefore != genresAfter);
        }

        [Test]
        public void TestReadGenre()
        {
            genreContext.Create(new Genre("RPG"));

            Genre genre = genreContext.Read(1);

            Assert.That(genre != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateGenre()
        {
            genreContext.Create(new Genre("RPG"));

            Genre genre = genreContext.Read(1);

            genre.Name = "RTS";

            genreContext.Update(genre);

            Genre genre1 = genreContext.Read(1);

            Assert.IsTrue(genre1.Name == "RTS", "Genre Update() does not change name!");
        }

        [Test]
        public void TestDeleteGenre()
        {
            genreContext.Create(new Genre("Delete genre"));

            int genresBeforeDeletion = genreContext.ReadAll().Count();

            genreContext.Delete(1);

            int genresAfterDeletion = genreContext.ReadAll().Count();

            Assert.AreNotEqual(genresBeforeDeletion, genresAfterDeletion);
        }

    }
}