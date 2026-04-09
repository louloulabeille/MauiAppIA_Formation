using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppIA_Formation.Models
{
    public class Usage
    {
        public int Prompt_tokens { get; set; } = 0;
        public int Completion_tokens { get; set; } = 0;
        public int Total_tokens { get; set; } = 0;
    }
}
