namespace HotelManagment.Dto;

// класс-dto
// data transfer object
// идея в том, что мы изолируем предметную область
public class CreateHotelRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime OpenSince { get; set; }
}
