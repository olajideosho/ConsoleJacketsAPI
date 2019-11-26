using ConsoleJacketsAPI.Contracts.V1;
using ConsoleJacketsAPI.Contracts.V1.Requests;
using ConsoleJacketsAPI.Contracts.V1.Responses;
using ConsoleJacketsAPI.Domain;
using ConsoleJacketsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Controllers.V1
{
    public class JacketsController : Controller
    {
        private readonly IJacketService _jacketService;

        public JacketsController(IJacketService jacketService)
        {
            _jacketService = jacketService;
        }

        [HttpGet(ApiRoutes.Jackets.GetRecent)]
        public async Task<IActionResult> GetRecentJackets()
        {
            var recent = await _jacketService.GetRecentJacketsAsync();
            if (recent != null)
            {
                return Ok(recent);
            }
            return Ok(new List<Jacket> { new Jacket { Id = 0, JacketID = null, JacketOwner = null, Location = null } });
        }

        [HttpGet(ApiRoutes.Jackets.GetById)]
        public async Task<IActionResult> GetJacketById([FromRoute] string jacketId)
        {
            var jacket = await _jacketService.GetJacketByIdAsync(jacketId);

            if(jacket == null)
            {
                var response = new Jacket { Id = 0, JacketID = null, JacketOwner = null, Location = null };
                return Ok(response);
            }

            return Ok(jacket);
        }

        [HttpGet(ApiRoutes.Jackets.GetCount)]
        public async Task<IActionResult> GetRemainingCount()
        {
            var count = await _jacketService.GetCountAsync();
            var remaining = new JacketsRemainingResponse();
            if(count > 0)
            {
                remaining = new JacketsRemainingResponse { Count = (5000 - count) };
                if(remaining.Count != 0)
                {
                    return Ok(remaining);
                }
                else
                {
                    remaining.Count = 9999;
                    return Ok(remaining);
                }
                
            }
            remaining.Count = 9999;
            return Ok(remaining);
        }

        [HttpPost(ApiRoutes.Jackets.Upload)]
        public async Task<IActionResult> Upload([FromBody] JacketUploadRequest jacketUploadRequest)
        {
            var jacket = new Jacket();
            var secret = "";
            var response = new JacketUploadResponse();

            if (jacketUploadRequest != null)
            {
                jacket = new Jacket
                {
                    //Id = jacketUploadRequest.IndexId,
                    JacketOwner = jacketUploadRequest.Owner,
                    JacketID = jacketUploadRequest.ID,
                    Location = jacketUploadRequest.Country
                };
                secret = jacketUploadRequest.Secret;
            }
            else
            {
                response = new JacketUploadResponse { Error = true, Message = "Something went wrong" };
                return Ok(response);
            }

            var exists = await _jacketService.GetJacketByIdAsync(jacket.JacketID);
            if(exists != null)
            {
                response = new JacketUploadResponse { Error = true, Message = "Jacket Already Assigned" };
                return Ok(response);
            }
            
            //if(jacket.Id == 0)
            //{
              //  jacket.Id = (await _jacketService.GetCountAsync()) + 1;
            //}

            var secretPass = SecretCheck.IsValid(jacket.JacketID, secret);
            var locationUri = "";
            if (secretPass)
            {
                var uploaded = await _jacketService.UploadAsync(jacket);

                if (uploaded)
                {
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                    locationUri = baseUrl + "/" + ApiRoutes.Jackets.GetById.Replace("{jacketId}", jacket.Id.ToString());
                    response = new JacketUploadResponse { Error = false, Message = "Jacket Upload Successful" };
                }
                else
                {
                    response = new JacketUploadResponse { Error = true, Message = "Something went wrong" };
                }
                
            }
            else
            {
                response = new JacketUploadResponse { Error = true, Message = "Secret Key is not Valid" };
            }
            
            return Created(locationUri, response);
        }
    }
}
