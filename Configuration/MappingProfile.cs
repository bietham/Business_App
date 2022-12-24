using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Task3.Store.Models;
using Task3.ViewModels;

namespace Task3.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Section, SectionViewModel>();



            CreateMap<Section, ModeratedSections>()
                .ForMember(x => x.Section, opt => opt.MapFrom(src => src));

            CreateMap<ModeratedSections, IdentityUser>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<Section, SectionEditViewModel>();
            CreateMap<Section, SectionDeleteViewModel>();
            CreateMap<SectionCreateViewModel, Section>();
            CreateMap<Topic, TopicViewModel>();
            CreateMap<Topic, TopicEditViewModel>();
            CreateMap<Topic, TopicDeleteViewModel>();
            CreateMap<TopicCreateViewModel, Topic>();
            CreateMap<Section, TopicCreateViewModel>()
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.Section, opt => opt.MapFrom(src => src))
                .ForMember(x => x.SectionId, opt => opt.MapFrom(src => src.Id));
            CreateMap<IdentityUser, AccountViewModel>()
                .ForMember(x => x.User, opt => opt.MapFrom(src => src));
            CreateMap<Message, MessageViewModel>();
            CreateMap<Message, MessageEditViewModel>();
            CreateMap<Message, MessageDeleteViewModel>();
            CreateMap<MessageCreateViewModel, Message>()
                .ForMember(x => x.Attachments, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Topic, MessageCreateViewModel>()
                .ForMember(x => x.Topic, opt => opt.MapFrom(src => src))
                .ForMember(x => x.TopicId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Attachment, AttachmentViewModel>();

            CreateMap<Inventory, InventoryViewModel>();
            CreateMap<Inventory, InventoryEditViewModel>()
                .ForMember(x => x.SelectedTypeId, opt => opt.MapFrom(src => src.TypeId));
            CreateMap<Inventory, InventoryDeleteViewModel>();
            CreateMap<InventoryCreateViewModel, Inventory>()
                .ForMember(x => x.TypeId, opt => opt.MapFrom(src => src.SelectedTypeId));
            CreateMap<School, InventoryCreateViewModel>()
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.School, opt => opt.MapFrom(src => src))
                .ForMember(x => x.SchoolId, opt => opt.MapFrom(src => src.Id));

            CreateMap<InventoryType, InventoryTypeViewModel>();
            CreateMap<InventoryType, InventoryTypeDeleteViewModel>();
            CreateMap<InventoryType, InventoryTypeEditViewModel>();
            CreateMap<InventoryTypeCreateViewModel, InventoryType>();

            CreateMap<PlannedInventory, PlannedInventoryViewModel>();
            CreateMap<PlannedInventory, PlannedInventoryDeleteViewModel>();
            CreateMap<PlannedInventory, PlannedInventoryEditViewModel>();
            CreateMap<PlannedInventoryCreateViewModel, PlannedInventory>()
                .ForMember(x => x.InventoryTypeId, opt => opt.MapFrom(src => src.SelectedInventoryTypeId));
            CreateMap<Event, PlannedInventoryCreateViewModel>()
                .ForMember(x => x.EventId, opt => opt.MapFrom(src => src.Id));

            CreateMap<School, SchoolViewModel>();
            CreateMap<School, SchoolEditViewModel>();
            CreateMap<School, SchoolDeleteViewModel>();
            CreateMap<SchoolCreateViewModel, School>();

            CreateMap<Event, EventViewModel>();
            CreateMap<Event, EventEditViewModel>();
            CreateMap<Event, EventDeleteViewModel>();
            CreateMap<EventCreateViewModel, Event>();
            CreateMap<Event, RentRequestCreateViewModel>()
                .ForMember(x => x.Event, opt => opt.MapFrom(src => src))
                .ForMember(x => x.EventId, opt => opt.MapFrom(src => src.Id));

            CreateMap<RentRequest, RentRequestViewModel>();
            CreateMap<RentRequest, RentRequestEditViewModel>();
            CreateMap<RentRequest, RentRequestDeleteViewModel>();
            CreateMap<RentRequestCreateViewModel, RentRequest>();



        }
    }
}