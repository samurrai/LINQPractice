namespace LINQPractice
{
    public class Song : Entity
    {
        public string Name { get; set; }
        public virtual SongDescription SongDescription { get; set; }
    }
}
