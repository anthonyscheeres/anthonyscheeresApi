﻿using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService roomService = new RoomService();

        // GET: api/room/
        [HttpGet]
        public string Get()
        {
            return roomService.getAllAvailableRoomsForReservation();
        }


        // POST api/room
        [HttpPost("{token}")]
        public string Post(string token, [FromBody] RoomModel room)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));

            return roomService.ValidateAddRoom(room, token);
        }
    }
}
