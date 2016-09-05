﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.Web.Models.Interfaces;
using OpenCharityAuction.Web.ViewModels;

namespace OpenCharityAuction.UnitTests.Models.Services
{
    public class TestAuctionService : IAuctionService
    {
        public async Task AddAdmissionTicket(AdmissionTicket newAdmissionTicket, Action<AdmissionTicket> callback = null)
        {
            await Task.Run(() => { callback?.Invoke(new AdmissionTicket()); });
        }

        public Task AddEvent(Event newEvent, Action<Event> callback = null)
        {
            newEvent.Id = 1;
            newEvent.CreateDate = DateTime.Now;
            return Task.Run(() => callback(newEvent));
        }

        public Task GetAllEvents(Action<List<Event>> callback)
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    EventName = "TestEvent"
                }
            };

            return Task.Run(() => callback(events));
        }

        public Task GetEventById(int id, Action<Event> callback)
        {
            return Task.Run(() => { return new List<Event>(); });
        }
    }
}
