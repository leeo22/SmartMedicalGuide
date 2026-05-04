using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Core.Features.Payments.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class PaymentController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all payments", OperationId = "GetAllPayments")]
        [HttpGet(Router.PaymentRouting.List)]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetPaymentListQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get payment by ID", OperationId = "GetPaymentById")]
        [HttpGet(Router.PaymentRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetPaymentByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new payment", OperationId = "CreatePayment")]
        [HttpPost(Router.PaymentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPaymentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update payment", OperationId = "UpdatePayment")]
        [HttpPut(Router.PaymentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPaymentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete payment", OperationId = "DeletePayment")]
        [HttpDelete(Router.PaymentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeletePaymentCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Queries
        [SwaggerOperation(Summary = "Get payments by patient ID", OperationId = "GetPaymentsByPatientId")]
        [HttpGet(Router.PaymentRouting.GetByPatientId)]
        public async Task<IActionResult> GetByPatientId([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPaymentsByPatientIdQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get payments by doctor ID", OperationId = "GetPaymentsByDoctorId")]
        [HttpGet(Router.PaymentRouting.GetByDoctorId)]
        public async Task<IActionResult> GetByDoctorId([FromRoute] int doctorId)
        {
            var response = await Mediator.Send(new GetPaymentsByDoctorIdQuery { DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get payments by status", OperationId = "GetPaymentsByStatus")]
        [HttpGet(Router.PaymentRouting.GetByStatus)]
        public async Task<IActionResult> GetByStatus([FromRoute] string status)
        {
            var response = await Mediator.Send(new GetPaymentsByStatusQuery { Status = status });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get payments by date range", OperationId = "GetPaymentsByDateRange")]
        [HttpGet(Router.PaymentRouting.GetByDateRange)]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var response = await Mediator.Send(new GetPaymentsByDateRangeQuery { FromDate = fromDate, ToDate = toDate });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get payments by payment method", OperationId = "GetPaymentsByMethod")]
        [HttpGet(Router.PaymentRouting.GetByMethod)]
        public async Task<IActionResult> GetByMethod([FromRoute] string method)
        {
            var response = await Mediator.Send(new GetPaymentsByMethodQuery { Method = method });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor revenue", OperationId = "GetDoctorRevenue")]
        [HttpGet(Router.PaymentRouting.GetDoctorRevenue)]
        public async Task<IActionResult> GetDoctorRevenue([FromQuery] int doctorId)
        {
            var response = await Mediator.Send(new GetDoctorRevenueQuery { DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get platform revenue", OperationId = "GetPlatformRevenue")]
        [HttpGet(Router.PaymentRouting.GetPlatformRevenue)]
        public async Task<IActionResult> GetPlatformRevenue()
        {
            var response = await Mediator.Send(new GetPlatformRevenueQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get revenue report", OperationId = "GetRevenueReport")]
        [HttpGet(Router.PaymentRouting.GetRevenueReport)]
        public async Task<IActionResult> GetRevenueReport([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(new GetRevenueReportQuery { FromDate = fromDate, ToDate = toDate });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get pending payments", OperationId = "GetPendingPayments")]
        [HttpGet(Router.PaymentRouting.GetPending)]
        public async Task<IActionResult> GetPending()
        {
            var response = await Mediator.Send(new GetPendingPaymentsQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get payment statistics", OperationId = "GetPaymentStatistics")]
        [HttpGet(Router.PaymentRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics()
        {
            var response = await Mediator.Send(new GetPaymentStatisticsQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get wallet payments", OperationId = "GetWalletPayments")]
        [HttpGet(Router.PaymentRouting.GetWalletPayments)]
        public async Task<IActionResult> GetWalletPayments()
        {
            var response = await Mediator.Send(new GetWalletPaymentsQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get bank transfer payments", OperationId = "GetTransferPayments")]
        [HttpGet(Router.PaymentRouting.GetTransferPayments)]
        public async Task<IActionResult> GetTransferPayments()
        {
            var response = await Mediator.Send(new GetTransferPaymentsQuery());
            return NewResult(response);
        }
        #endregion

        #region Additional Commands
        [SwaggerOperation(Summary = "Update payment status", OperationId = "UpdatePaymentStatus")]
        [HttpPut(Router.PaymentRouting.UpdateStatus)]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdatePaymentStatusCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Verify payment", OperationId = "VerifyPayment")]
        [HttpPut(Router.PaymentRouting.Verify)]
        public async Task<IActionResult> Verify([FromBody] VerifyPaymentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}