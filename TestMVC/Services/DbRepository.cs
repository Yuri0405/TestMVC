﻿using Microsoft.EntityFrameworkCore;
using TestMVC.Models;
using TestMVC.Models.DTO;

namespace TestMVC.Services
{
    public class DbRepository
    {
        private readonly AppDBContext _dbContext;
        public DbRepository(AppDBContext dBContext) 
        {
            _dbContext = dBContext;
        
        }

        public List<Film> GetAllFilms()
        {
            var list = _dbContext.Films
                .Include(f => f.Categories)
                .ThenInclude(cf => cf.Category)
                .ToList();

            return list;
        }

        public Film GetFilm(int id)
        {
            return _dbContext.Films.FirstOrDefault(film => film.Id == id);
        }

        public void Delete(int id)
        {
            var filmToDelete = _dbContext.Films.FirstOrDefault(f => f.Id == id);
            _dbContext.Films.Remove(filmToDelete);
            _dbContext.SaveChanges();
        }
    }
}
