using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class MedicalReportController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all medical reports", OperationId = "GetAllMedicalReports")]
        [HttpGet(Router.MedicalReportRouting.List)]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetMedicalReportListQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new medical report", OperationId = "CreateMedicalReport")]
        [HttpPost(Router.MedicalReportRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddMedicalReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update medical report", OperationId = "UpdateMedicalReport")]
        [HttpPut(Router.MedicalReportRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditMedicalReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion

        #region Additional Queries
        [SwaggerOperation(Summary = "Get reports by patient ID", OperationId = "GetReportsByPatientId")]
        [HttpGet(Router.MedicalReportRouting.GetByPatientId)]
        public async Task<IActionResult> GetByPatientId([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetMedicalReportByPatientIdQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get reports by doctor ID", OperationId = "GetReportsByDoctorId")]
        [HttpGet(Router.MedicalReportRouting.GetByDoctorId)]
        public async Task<IActionResult> GetByDoctorId([FromRoute] int doctorId)
        {
            var response = await Mediator.Send(new GetMedicalReportByDoctorIdQuery { DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get reports by report type", OperationId = "GetReportsByReportType")]
        [HttpGet(Router.MedicalReportRouting.GetByReportType)]
        public async Task<IActionResult> GetByReportType([FromRoute] string reportType)
        {
            var response = await Mediator.Send(new GetMedicalReportByReportTypeQuery { ReportType = reportType });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get reports by date range", OperationId = "GetReportsByDateRange")]
        [HttpGet(Router.MedicalReportRouting.GetByDateRange)]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var response = await Mediator.Send(new GetMedicalReportByDateRangeQuery { FromDate = fromDate, ToDate = toDate });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient medical history", OperationId = "GetPatientMedicalHistory")]
        [HttpGet(Router.MedicalReportRouting.GetPatientMedicalHistory)]
        public async Task<IActionResult> GetPatientMedicalHistory([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientMedicalHistoryQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get medical report statistics", OperationId = "GetMedicalReportStatistics")]
        [HttpGet(Router.MedicalReportRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics()
        {
            var response = await Mediator.Send(new GetMedicalReportStatisticsQuery());
            return NewResult(response);
        }
        #endregion

        #region File Operations
        [SwaggerOperation(Summary = "Upload report file", OperationId = "UploadReportFile")]
        [HttpPost(Router.MedicalReportRouting.UploadFile)]
        public async Task<IActionResult> UploadFile([FromForm] UploadReportFileCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Download report file", OperationId = "DownloadReportFile")]
        [HttpGet(Router.MedicalReportRouting.DownloadFile)]
        public async Task<IActionResult> DownloadFile([FromRoute] int reportId)
        {
            var response = await Mediator.Send(new DownloadReportFileQuery(reportId));

            if (!response.Succeeded)
                return BadRequest(response.Message);

            var (filePath, fileName, contentType) = response.Data;
            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, contentType, fileName);
        }

        [SwaggerOperation(Summary = "Delete report file", OperationId = "DeleteReportFile")]
        [HttpDelete(Router.MedicalReportRouting.DeleteFile)]
        public async Task<IActionResult> DeleteFile([FromRoute] int reportId)
        {
            var response = await Mediator.Send(new DeleteReportFileCommand(reportId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update report file", OperationId = "UpdateReportFile")]
        [HttpPut(Router.MedicalReportRouting.UpdateFile)]
        public async Task<IActionResult> UpdateFile([FromForm] UpdateReportFileCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}