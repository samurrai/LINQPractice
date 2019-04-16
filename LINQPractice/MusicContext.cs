namespace LINQPractice
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MusicContext : DbContext
    {
        public MusicContext()
            : base("name=MusicContext")
        {
        }

        public DbSet<SongDescription> SongDescriptions { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<MusicalGroup> MusicalGroups { get; set; }
    }
}