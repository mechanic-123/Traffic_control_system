﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS_CRS.Models;

namespace UI_TMS.Controllers
{
    public class ConsumeRTOController : Controller
    {
        public IActionResult RTOHome()
        {
            return View();
        }
        public IActionResult AddOwner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOwner(TmOwnerdetail o)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:12850/api/RTO/");
                    var postdata = client.PostAsJsonAsync<TmOwnerdetail>("AddUser", o);
                    postdata.Wait();
                    var result = postdata.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "New Owner created");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }

            return View();
        }
        public IActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVehicle(TmVehicledetail v)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:12850/api/RTO/");
                    var postdata = client.PostAsJsonAsync<TmVehicledetail>("AddVehicle", v);
                    postdata.Wait();
                    var result = postdata.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "New Vehicle added");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(TmRegdetail reg)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:12850/api/RTO/");
                    var postdata = client.PostAsJsonAsync<TmRegdetail>("Register", reg);
                    postdata.Wait();
                    var result = postdata.Result;
                    ModelState.AddModelError("",result.ToString());
                    if (result.IsSuccessStatusCode)
                        ModelState.AddModelError("", "New Registration Successful");
                    else
                        ModelState.AddModelError("","Not Registered");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }
            return View();
        }
        public IActionResult Transferdetails(int vehId)
        {
            TmRegdetail reg = new TmRegdetail();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850/api/RTO/");
                var responsedata = client.GetAsync("Transferdetails/" + vehId);
                responsedata.Wait();

                var result = responsedata.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readresult = result.Content.ReadAsAsync<TmRegdetail>();
                    readresult.Wait();
                    reg = readresult.Result;
                }
            }
            return View(reg);
        }
        [HttpPost]
        public IActionResult Transferdetails(TmRegdetail r, int vehId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:12850/api/RTO/");
                    var postdata = client.GetAsync("Transferdetails/" + vehId);
                    postdata.Wait();
                    var result = postdata.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "Record Transfered");
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.ToString());
            }
            return View();
        }
        public IActionResult GenerateReport()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GenerateReport(int id)
        {
            return View();
        }
    }
}
