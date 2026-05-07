using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Attachments.Commands.Models;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace SmartMedicalGuide.API.Controllers
{
    //[Authorize]
    [ApiController]
    public class AttachmentController : AppControllerBase
    {

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // للتأكد من القيمة أثناء الاختبار
            Console.WriteLine($"UserId from Token: {userIdClaim}");

            if (string.IsNullOrEmpty(userIdClaim))
            {
                // حاول البحث عن الـ Claim بطريقة أخرى
                userIdClaim = User.FindFirst("UserId")?.Value;
                Console.WriteLine($"UserId from alternative claim: {userIdClaim}");
            }

            return int.TryParse(userIdClaim, out int userId) ? userId : 0;
        }

        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all attachments", OperationId = "GetAllAttachments")]
        [HttpGet(Router.AttachmentRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? userId, [FromQuery] string? entityType, [FromQuery] int? entityId)
        {
            var response = await Mediator.Send(new GetAttachmentListQuery
            {
                UserId = userId,
                RelatedEntityType = entityType,
                RelatedEntityId = entityId
            });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get attachment by ID", OperationId = "GetAttachmentById")]
        [HttpGet(Router.AttachmentRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetAttachmentByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create attachment record", OperationId = "CreateAttachment")]
        [HttpPost(Router.AttachmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddAttachmentCommand command)
        {
            command.UserId = GetCurrentUserId();
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update attachment", OperationId = "UpdateAttachment")]
        [HttpPut(Router.AttachmentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditAttachmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete attachment record", OperationId = "DeleteAttachment")]
        [HttpDelete(Router.AttachmentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteAttachmentCommand(id));
            return NewResult(response);
        }
        #endregion

        #region File Operations
        [SwaggerOperation(Summary = "Upload file", OperationId = "UploadFile")]
        [HttpPost(Router.AttachmentRouting.UploadFile)]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileCommand command)
        {
            command.UserId = GetCurrentUserId();
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Download file", OperationId = "DownloadFile")]
        [HttpGet(Router.AttachmentRouting.DownloadFile)]
        public async Task<IActionResult> DownloadFile([FromRoute] int attachmentId)
        {
            var response = await Mediator.Send(new DownloadFileQuery(attachmentId));

            if (!response.Succeeded)
                return BadRequest(response.Message);

            var (filePath, fileName, contentType) = response.Data;
            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, contentType, fileName);
        }

        [SwaggerOperation(Summary = "Delete file", OperationId = "DeleteFile")]
        [HttpDelete(Router.AttachmentRouting.DeleteFile)]
        public async Task<IActionResult> DeleteFile([FromRoute] int attachmentId)
        {
            var response = await Mediator.Send(new DeleteFileCommand { AttachmentId = attachmentId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update file", OperationId = "UpdateFile")]
        [HttpPut(Router.AttachmentRouting.UpdateFile)]
        public async Task<IActionResult> UpdateFile([FromForm] UpdateFileCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get total file size by user", OperationId = "GetTotalFileSize")]
        [HttpGet(Router.AttachmentRouting.GetTotalFileSize)]
        public async Task<IActionResult> GetTotalFileSize([FromQuery] int? userId)
        {
            var targetUserId = userId ?? GetCurrentUserId();
            var response = await Mediator.Send(new GetTotalFileSizeQuery { UserId = targetUserId });
            return NewResult(response);
        }
        #endregion
    }
}