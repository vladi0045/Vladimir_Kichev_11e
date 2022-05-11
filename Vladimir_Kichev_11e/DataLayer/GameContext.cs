using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer
{
    public class GameContext : IDB<Game, int>
    {
        GamingDbContext _context;

        public GameContext(GamingDbContext context)
        {
            _context = context;
        }

        public void Create(Game item)
        {
            try
            {
                _context.Games.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Game Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games;

                if (noTracking)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Genres).Include(g => g.Users);
                }

                return query.SingleOrDefault(g => g.Game_ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Game> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games.AsNoTrackingWithIdentityResolution();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Genres).Include(g => g.Users);
                }

                return query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Game> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Genres).Include(g => g.Users);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Game item, bool useNavigationProperties = false)
        {
            try
            {
                Game gameFromDB = Read(item.Game_ID);

                _context.Entry(gameFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Games.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}