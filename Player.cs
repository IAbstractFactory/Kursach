using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    [Serializable]
    public class Player
    {
        public Player(string name,TimeSpan time)
        {
            Name = name;
            Time = time;
        }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
    }
}
