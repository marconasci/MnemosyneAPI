﻿namespace MnemosyneAPI.Model
{
    public class Memory
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<string> Images { get; set; }
    }
}
