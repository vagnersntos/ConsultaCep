namespace ConsultaCep.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public AddressModel? Address { get; set; }
        public int Cpf { get; set; }
        public bool IsInstructor { get; set; }
    }
}
