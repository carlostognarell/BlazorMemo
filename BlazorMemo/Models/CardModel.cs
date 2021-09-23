using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMemo.Models
{
    public class CardModel
    {
        private bool isFlipped;

        public string FrontPath { get; set; }
        public string BackPath { get; set; }
        public bool IsFlipped
        {
            get { return isFlipped; }
            set
            {
                if (CanExecute)
                {
                    if (!isFlipped)
                    {
                        FlipStyle = "flip";
                    }
                    else
                    {
                        FlipStyle = "";
                    }
                    isFlipped = value;
                }
                
            }
        }
        public bool CanExecute { get; set; } = true;
        public string FlipStyle { get; set; } = "";
        public int Order { get; set; }
    }
}
