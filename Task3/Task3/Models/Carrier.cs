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

        public Carrier(string Name, string PhoneNumber, string Email, Vehicle Vehicle)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Vehicle = Vehicle;
        }
      
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, PhoneNumber, Email);
        }
    }
}
