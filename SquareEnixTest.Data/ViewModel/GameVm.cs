using System;
using System.Collections.Generic;
using System.Text;

namespace SquareEnixTest.Data.ViewModel
{
    public class GameVm
    {
        public string  Id { get; set; }
        public string  Name { get; set; }
        public List<string>  Platforms { get; set; }
        public string  Genre { get; set; }
        public bool IsSelected { get; set; }
    }
}
