﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using PFC_Toolbox.v._4._0.Models;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class LocationsController : ApiController
    {
        [Route("api/Locations")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult Locations()
        {
            var request = HttpContext.Current.Request;

            using (var db = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db, "Locations", "locationID")
                    .Model<LocationsModel>()
                    .Field(new Field("locationID")
                        .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("locationname")
                        .Validator(Validation.NotEmpty())
                    )
                     .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}