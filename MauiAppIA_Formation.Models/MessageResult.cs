using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppIA_Formation.Models
{
    public class MessageResult
    {
        public string Object { get; set; } = string.Empty;
        public string Conversation_id { get; set; } = string.Empty;
        public List<Outputs>? Outputs { get; set; }
        public Usage? Usage { get; set; }
        public object? Guardrails { get; set; }
    }
}
