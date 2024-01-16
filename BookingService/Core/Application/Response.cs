using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public enum ErrorCode
    {
        // Códigos de erro para códidos de Guests 1 - 99
        GUEST_NOT_FOUND = 1,
        GUEST_COULD_NOT_STORE_DATA = 2,
        GUEST_INVALID_DOCUMENT = 3,
        GUEST_MISSING_REQUIRED_INFORMATION = 4,
        GUEST_INVALID_EMAIL = 5,       

        // Códigos de erro para códidos de Guests 100 - 199
        ROOM_NOT_FOUND = 100,
        ROOM_COULD_NOT_STORE_DATA = 101,
        ROOM_INVALID_DOCUMENT = 102,
        ROOM_MISSING_REQUIRED_INFORMATION = 103,      
        

        
    }

    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
