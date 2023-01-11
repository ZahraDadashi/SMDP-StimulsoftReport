using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SMDP.SMDPModels;
using Microsoft.AspNetCore.Authorization;
using SMDP;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SMDP.Repository;
using System.Security.Cryptography;
using SMDP.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Microsoft.Data.SqlClient;
using System.Data;
using Stimulsoft.Base;
using Stimulsoft.Report.Mvc;
using System.Net;
using System.Net.Http.Headers;

namespace SMDP.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    

    public class DataController : ControllerBase
    {
        private ValidationService _validationService;        
        private LogSingleton _logger;      

        public DataController()
        {
            _validationService = new ValidationService();
            _logger = LogSingleton.Instance;            

        }
        //[ProducesResponseType(typeof(List<DailyPrice>), 200)]
        [HttpGet("/DailyPrice")]       
        public dynamic DailyPrice(long InsCode, int FromDate, int ToDate)
         {
            bool validate = _validationService.validateDailyPrice(InsCode);
            if(validate)
            {   

                string userAgent = Request.Headers["User-Agent"].ToString();
                string method = Request.Method.ToString();
                string userr = User?.Identity.Name;
                var Dailypricelist = _validationService.DailyPrice(InsCode,FromDate,ToDate);
                var json = System.Text.Json.JsonSerializer.Serialize(Dailypricelist);


                _logger.WriteRequest(userAgent);
                _logger.WriteKind(method);
                _logger.GetUser(userr);
                _logger.WriteResponse(json);

                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<DailyPrice>));                
                var path = Path.Combine(".\\Reports\\DailyPrice.xml");
                System.IO.FileStream fileObj;
                fileObj = System.IO.File.Create(path);
                writer.Serialize(fileObj, Dailypricelist);
                fileObj.Close();

                var report = new StiReport();
                report.Load(path: ".\\Reports\\DailyPrice.mrt");
                report.RegBusinessObject("DailyPrice", Dailypricelist);
                var rendered = report.Render(false);
                MemoryStream memoryStream = new MemoryStream();
                rendered.ExportDocument(StiExportFormat.Pdf, memoryStream);
                return File(memoryStream.GetBuffer(), "application/pdf", "DailyPrice.pdf");
                return Dailypricelist;
            }
            else
            {
                return BadRequest("enter a valid number");
            }
        }

        //[ProducesResponseType(typeof(List<Fund>), 200)]
        [HttpGet("/Fund")]
        public dynamic Fund()
        {
           
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var Fundlist = _validationService.Fund();
            var json = System.Text.Json.JsonSerializer.Serialize(Fundlist);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);
            var report = new StiReport();
            report.Load(path: ".\\Reports\\Fund.mrt");
            report.RegBusinessObject("Fund", Fundlist);
            var rendered = report.Render(false);
            MemoryStream memoryStream = new MemoryStream();
            var result = rendered.ExportDocument(StiExportFormat.Pdf, memoryStream);
            return File(memoryStream.GetBuffer(), "application/pdf", "Fund.pdf");           

        }
      
        //[ProducesResponseType(typeof(List<Industry>), 200)]
        [HttpGet("/Industry")]    
        
        public dynamic Industry()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var Industrylist = _validationService.Industry();
            var json = System.Text.Json.JsonSerializer.Serialize(Industrylist);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);
            var report = new StiReport();
            report.Load(path: ".\\Reports\\Industry.mrt");
            report.RegBusinessObject("Industry", Industrylist);
            var rendered = report.Render(false);
            MemoryStream memoryStream = new MemoryStream();
            rendered.ExportDocument(StiExportFormat.Pdf, memoryStream);
            return File(memoryStream.GetBuffer(), "application/pdf", "Industry.pdf");
                   
        }

        //[ProducesResponseType(typeof(List<Instrument>), 200)]
        [HttpGet("/Instrument")]        
        public dynamic Instrument()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var Instrumentlist = _validationService.Instrument();
            var json = System.Text.Json.JsonSerializer.Serialize(Instrumentlist);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);
            var report = new StiReport();
            report.Load(path: ".\\Reports\\Instrument.mrt");
            report.RegBusinessObject("Instrument", Instrumentlist);
            var rendered = report.Render(false);
            MemoryStream memoryStream = new MemoryStream();
            rendered.ExportDocument(StiExportFormat.Pdf, memoryStream);
            return File(memoryStream.GetBuffer(), "application/pdf", "Instrument.pdf");
            
        
        }
       
        //[ProducesResponseType(typeof(List<LetterType>), 200)]
        [HttpGet("/LetterType")]
        public dynamic LetterType()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var letterTypelist = _validationService.Lettertype();
            var json = System.Text.Json.JsonSerializer.Serialize(letterTypelist);          

            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);        

            var report = new StiReport();
            report.Load(path: ".\\Reports\\LetterType.mrt");
            report.RegBusinessObject("LetterType", letterTypelist);
            var rendered = report.Render(false);
            MemoryStream memoryStream = new MemoryStream();
            rendered.ExportDocument(StiExportFormat.Pdf, memoryStream);
            return File(memoryStream.GetBuffer(), "application/pdf", "LetterType.pdf");
                
        }

    }                                                                                                                                                                                                                                      
} 