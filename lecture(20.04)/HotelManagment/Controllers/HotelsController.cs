using HotelManagment.Dto;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace HotelManagment.Controllers;

[ApiController]
[Route( "hotels" )]
public class HotelsController : ControllerBase
{
    private static List<Hotel> _hotels;

    // статический конструктор запускается один раз для класса
    static HotelsController()
    {
        _hotels = new();
    }

    // Http-метод GET
    // GET подразумевает, что мы за прашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметр в качествеметода фильтрауточнения запроса дангных
    [HttpGet("")]
    public IActionResult GetHotels()
    {
        return Ok(_hotels);
    }
    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создания нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost( "" )]
    public IActionResult CreateHotel([FromBody] CreateHotelRequest request)
    {
        int id = _hotels.Count + 1;
        var newHotel = new Hotel(id, request.Name, request.Address, request.OpenSince);
        _hotels.Add(newHotel);
        //возвращает http-ответ ос статусом 200-ОК  
        return Ok();
    }

    [HttpPut( "{id:int}" )]
    public IActionResult ModifyHotel([FromRoute] int id, [FromBody] ModifyHotelRequest request)
    {
        // находим отель который пользователь хочет изменить
        var hotel = _hotels.FirstOrDefault(h => h.Id == id);

        if (hotel is null)
        {
            return NotFound();
        }

        hotel.SetName(request.Name);
        hotel.SetAddress(request.Address);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletHotel([FromRoute] int id)
    {
        // to do
        throw new NotImplementedException();
    }
}
