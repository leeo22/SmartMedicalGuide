using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Handlers
{
    public class PrescriptionItemCommandHandler : ResponseHandler,
        IRequestHandler<AddPrescriptionItemCommand, Response<string>>,
        IRequestHandler<EditPrescriptionItemCommand, Response<string>>,
        IRequestHandler<DeletePrescriptionItemCommand, Response<string>>,
        IRequestHandler<BulkAddPrescriptionItemsCommand, Response<bool>>,
        IRequestHandler<UpdateItemQuantityCommand, Response<bool>>
    {
        private readonly IPrescriptionItemServices _itemServices;
        private readonly IMapper _mapper;

        public PrescriptionItemCommandHandler(IPrescriptionItemServices itemServices, IMapper mapper)
        {
            _itemServices = itemServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddPrescriptionItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<PrescriptionItem>(request);
            var result = await _itemServices.AddAsync(item);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Prescription item added successfully");
        }

        public async Task<Response<string>> Handle(EditPrescriptionItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<PrescriptionItem>(request);
            var result = await _itemServices.EditAsync(item);

            if (result == "Item not found")
                return NotFound<string>("Item not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Prescription item edited successfully");
        }

        public async Task<Response<string>> Handle(DeletePrescriptionItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemServices.GetByIDAsync(request.Id);
            if (item == null)
                return NotFound<string>("Item not found");

            var result = await _itemServices.DeleteAsync(item);
            return result == "Success" ? Deleted<string>("Prescription item deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<bool>> Handle(BulkAddPrescriptionItemsCommand request, CancellationToken cancellationToken)
        {
            var items = _mapper.Map<List<PrescriptionItem>>(request.Items);
            var result = await _itemServices.BulkAddItemsAsync(items);
            return result ? Success(true) : BadRequest<bool>("Failed to bulk add items");
        }

        public async Task<Response<bool>> Handle(UpdateItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var result = await _itemServices.UpdateItemQuantityAsync(request.ItemId, request.Quantity);
            return result ? Success(true) : BadRequest<bool>("Failed to update quantity");
        }
    }
}