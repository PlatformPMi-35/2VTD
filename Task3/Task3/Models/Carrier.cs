namespace Task3.Models
{
    using System;

    [Serializable]
    class Carrier
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
