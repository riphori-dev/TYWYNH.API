using System;

namespace Tywynh.Domain.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? Path { get; set; }
        public string? Method { get; set; }
        public DateTime Timestamp { get; set; }
    }
}