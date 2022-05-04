namespace DesafioSidequest.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}