using System.Collections.Generic;

namespace LINQPractice
{
    public class MusicalGroup : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
