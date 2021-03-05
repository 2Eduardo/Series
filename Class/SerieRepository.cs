using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public bool Create(Serie entity)
        {
            serieList.Add(entity);
            return true;
        }

        public bool Delete(int id)
        {
            Serie s = serieList.Find(obj => obj.ID == id);
            if(s == null)
                return false;
            s.deleted = true;
            return true;
        }

        public List<Serie> GetAll()
        {
            return serieList;
        }

        public Serie GetById(int id)
        {
            return serieList.Find(obj => obj.ID == id);
        }

        public int NextID()
        {
            return serieList.Count;
        }

        public bool ReadAll()
        {
            if (serieList.Count == 0)
            {
                System.Console.WriteLine("No series found!");
                return false;
            }
            else
            {
                serieList.ForEach(delegate (Serie s)
                {
                    Console.WriteLine("##ID: " + s.ID);
                    Console.WriteLine(s.ToString());
                    if(s.deleted)
                        Console.WriteLine("*deleted*");
                });
                return true;
            }
        }

        public bool ReadByID(int id)
        {
            Serie s;
            s = serieList.Find(obj => obj.ID == id);
            if (s == null)
                return false;
            Console.WriteLine(s.ToString());
            return true;
        }

        public bool Update(int id, Serie entity)
        {
            Serie s;
            s = serieList.Find(obj => obj.ID == id);
            if (s == null)
                return false;
            s = entity;
            return true;
        }
    }
}