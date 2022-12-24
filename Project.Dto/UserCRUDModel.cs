using Project.Entity.Concretes;

namespace Project.Dto;

public class UserCRUDModel
{
    //public Users Users { get; set; }

    public int Id { get; set; } 
    public string Mail { get; set; }
    public string Password { get; set; }

    public string UserName { get; set; }
    public string Street { get; set; }
    public int Avenue { get; set; }
    public int No { get; set; }
    public int CountyId { get; set; }
    public bool Error { get; set; }
    public string Role { get; set; }
    public char Sex { get; set; }

    //public string RePassword { get; set; }

    //public List<County> Counties { get; set; }
    //public string Msg { get; set; }


}
