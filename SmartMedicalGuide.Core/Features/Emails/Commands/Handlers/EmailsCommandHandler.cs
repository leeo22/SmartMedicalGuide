using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Emails.Commands.Models;
//using SmartMedicalGuide.Core.Resources;
using SmartMedicalGuide.Services.Abstracts;
namespace SmartMedicalGuide.Core.Features.Emails.Commands.Handlers
{
    public class EmailsCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IEmailsService _emailsService;
        //private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public EmailsCommandHandler(
                                    IEmailsService emailsService) : base()
        {
            _emailsService = emailsService;
            //_stringLocalizer= stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailsService.SendEmail(request.Email, request.Message, null);
            if (response == "Success")
                return Success<string>("rrrrrr");
            return BadRequest<string>("errorr");
        }
        #endregion
    }
}
