using System;

namespace Series
{
    public class Serie : BasicEntity
    {
        private Genre Genre;
        private string title;
        private string Description;
        private int Year;
        public bool deleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.ID = id;
            this.Genre = genre;
            this.SetTitle(title);
            this.Description = description;
            this.Year = year;
            this.deleted = false;
        }

        public override string ToString()
        {
            string ret = "";
            ret += "Genre: " + this.Genre + Environment.NewLine;
            ret += "Title: " + this.GetTitle() + Environment.NewLine;
            ret += "Description: " + this.Description + Environment.NewLine;
            ret += "Year: " + this.Year + Environment.NewLine;
            return ret;
        }
        private string GetTitle()
        {
            return title;
        }

        private void SetTitle(string value)
        {
            title = value;
        }
    }
}