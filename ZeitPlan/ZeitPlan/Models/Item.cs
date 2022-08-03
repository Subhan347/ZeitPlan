using System;
using Xamarin.Forms;

namespace ZeitPlan.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public ImageSource ImagePath { get; set; }
        public string Description { get; set; }
    }
}