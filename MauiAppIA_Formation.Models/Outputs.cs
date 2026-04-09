using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MauiAppIA_Formation.Models
{
    public class Outputs
    {
        public string Object {  get; set; } = string.Empty;
        public string  Type { get; set; } = string.Empty;
        public string Created_at { get; set; } = string.Empty;
        public string Completed_at { get; set; } = string.Empty;
        public string Agent_id { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? Content { get; set; }
        
    }
}
