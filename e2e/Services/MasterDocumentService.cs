using e2e.Data;
using e2e.Model;
using e2e.Shared;
using Microsoft.EntityFrameworkCore;

namespace e2e.Services
{
    public class MasterDocumentService : IMasterDocumentService
    {
        private readonly ApplicationDbContext _context;

        public MasterDocumentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddGeneralSectionAsync(GeneralModel model, Guid campaignId, string participant, string participantName, string area)
        {
            var participantDetails = MapGeneralModelToParticipantDetails(model, campaignId, participant, participantName, area);

            _context.ParticipantDetails.AddRange(participantDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<GeneralModel> GetMasterDocumentsByCampaignID(Guid id, string participant, string participantName, string area)
        {
            var participantDetails = await _context.ParticipantDetails
                .Where(x=> x.CampaignId.Equals(id) 
                    && x.ParticipantName.Equals(participant) 
                    && x.ParticipantSectionName.Equals(participantName)
                    && x.AreaName.Equals(area)
                    )
                .ToListAsync();
            var general = MapParticipantDetailsToModel(participantDetails);
            return general;
        }

        public async Task UpdateGeneralAsync(GeneralModel model, Guid campaignId, string participant, string participantName, string area)
        {
            // Obtener los detalles existentes para la campaña
            var existingDetails = await _context.ParticipantDetails
                .Where(d => d.CampaignId == campaignId
                    && d.ParticipantName.Equals(participant)
                    && d.ParticipantSectionName.Equals(participantName)
                    && d.AreaName.Equals(area)
                )
                .ToListAsync();

            // Mapear los datos de `Model` a una lista de `ParticipantDetail` que queremos tener en la base de datos
            var updatedDetails = MapGeneralModelToParticipantDetails(model, campaignId, participant, participantName, area);

            // Iterar sobre `updatedDetails` para actualizar o agregar cada registro
            foreach (var updatedDetail in updatedDetails)
            {
                var existingDetail = existingDetails
                    .FirstOrDefault(d => d.TitleName == updatedDetail.TitleName);

                if (existingDetail != null)
                {
                    // Actualizar el registro existente
                    existingDetail.FieldValue = updatedDetail.FieldValue;
                    existingDetail.FieldType = updatedDetail.FieldType;
                }
                else
                {
                    // Agregar un nuevo registro si no existe
                    _context.ParticipantDetails.Add(updatedDetail);
                }
            }

            // Eliminar registros que ya no están presentes en `updatedDetails`
            var fieldsToKeep = updatedDetails.Select(d => d.TitleName).ToList();
            var detailsToRemove = existingDetails
                .Where(d => !fieldsToKeep.Contains(d.TitleName))
                .ToList();

            if (detailsToRemove.Any())
            {
                _context.ParticipantDetails.RemoveRange(detailsToRemove);
            }

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }


        private List<ParticipantDetail> MapGeneralModelToParticipantDetails(GeneralModel model, Guid campaignId, string participant, string participantName, string area)
        {
            var details = new List<ParticipantDetail> {};

            if (model.isSell.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "isSell", FieldValue = model.isSell.Value.ToString(), FieldType = "bool" });

            if (model.isATC.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "isATC", FieldValue = model.isATC.Value.ToString(), FieldType = "bool" });

            if (model.isCollection.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "IsCollection", FieldValue = model.isCollection.Value.ToString(), FieldType = "bool" });

            if (model.numberStations.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "NumberStations", FieldValue = model.numberStations.Value.ToString(), FieldType = "int" });

            if (model.startDate.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "StartDate", FieldValue = model.startDate.Value.ToString("yyyy-MM-dd"), FieldType = "DateOnly" });

            if (model.voice.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Voice", FieldValue = model.voice.Value.ToString(), FieldType = "bool" });

            if (model.sms.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Sms", FieldValue = model.sms.Value.ToString(), FieldType = "bool" });

            if (model.email.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Email", FieldValue = model.email.Value.ToString(), FieldType = "bool" });

            if (model.whatsApp.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "WhatsApp", FieldValue = model.whatsApp.Value.ToString(), FieldType = "bool" });

            if (model.facebook.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Facebook", FieldValue = model.facebook.Value.ToString(), FieldType = "bool" });

            if (model.blaster.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Blaster", FieldValue = model.blaster.Value.ToString(), FieldType = "bool" });

            if (model.voiceBot.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "VoiceBot", FieldValue = model.voiceBot.Value.ToString(), FieldType = "bool" });

            if (!string.IsNullOrEmpty(model.voiceBotType))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "VoiceBotType", FieldValue = model.voiceBotType, FieldType = "string" });

            if (model.chatBot.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "ChatBot", FieldValue = model.chatBot.Value.ToString(), FieldType = "bool" });

            if (!string.IsNullOrEmpty(model.chatBotType))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "ChatBotType", FieldValue = model.chatBotType, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.otherChannel))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "OtherChannel", FieldValue = model.otherChannel, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.mainActivitiesOne))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "MainActivitiesOne", FieldValue = model.mainActivitiesOne, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.mainActivitiesTwo))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "MainActivitiesTwo", FieldValue = model.mainActivitiesTwo, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.mainActivitiesThree))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "MainActivitiesThree", FieldValue = model.mainActivitiesThree, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.pocClient))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "PocClient", FieldValue = model.pocClient, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.other))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area,ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Other", FieldValue = model.other, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.typeInteraction))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area,ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "TypeInteraction", FieldValue = model.typeInteraction, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.otherChannel))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area,ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "OtherChannel", FieldValue = model.otherChannel, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.mainActivitiesOne))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area,ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "MainActivitiesOne", FieldValue = model.mainActivitiesOne, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.mainActivitiesTwo))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area,ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "MainActivitiesTwo", FieldValue = model.mainActivitiesTwo, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.mainActivitiesThree))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area,ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "MainActivitiesThree", FieldValue = model.mainActivitiesThree, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.pocClient))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area,ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "PocClient", FieldValue = model.pocClient, FieldType = "string" });
            /*
             * WFM Section
             */
            if (!string.IsNullOrEmpty(model.timeFrameAttentionOne))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "TimeFrameAttentionOne", FieldValue = model.timeFrameAttentionOne, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.timeFrameAttentionTwo))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "TimeFrameAttentionTwo", FieldValue = model.timeFrameAttentionTwo, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.timeFrameAttentionThree))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "TimeFrameAttentionThree", FieldValue = model.timeFrameAttentionThree, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.publicHoliday))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "PublicHoliday", FieldValue = model.publicHoliday, FieldType = "string" });

            if (model.numberStationsWFM.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "NumberStationsWFM", FieldValue = model.numberStationsWFM?.ToString(), FieldType = "int" });

            if (!string.IsNullOrEmpty(model.cities))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Cities", FieldValue = model.cities, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.sites))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Sites", FieldValue = model.sites, FieldType = "string" });

            if (model.interactionPerDays.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "InteractionPerDays", FieldValue = model.interactionPerDays?.ToString(), FieldType = "int" });

            if (model.interactionPerMonths.HasValue)
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "InteractionPerMonths", FieldValue = model.interactionPerMonths?.ToString(), FieldType = "int" });

            if (!string.IsNullOrEmpty(model.ratioAgentsSupervisors))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "RatioAgentsSupervisors", FieldValue = model.ratioAgentsSupervisors, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.ratioAgentsCoordinators))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "RatioAgentsCoordinators", FieldValue = model.ratioAgentsCoordinators, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.ratioAgentsQA))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "RatioAgentsQA", FieldValue = model.ratioAgentsQA, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.serviceLevel))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "ServiceLevel", FieldValue = model.serviceLevel, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.aba))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Aba", FieldValue = model.aba, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.asa))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Asa", FieldValue = model.asa, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.aht))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Aht", FieldValue = model.aht, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.occupancy))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Occupancy", FieldValue = model.occupancy, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.adherence))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Adherence", FieldValue = model.adherence, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.fcr))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Fcr", FieldValue = model.fcr, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.qa))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Qa", FieldValue = model.qa, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.nps))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Nps", FieldValue = model.nps, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.csat))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Csat", FieldValue = model.csat, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.totalPromisesPayment))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "TotalPromisesPayment", FieldValue = model.totalPromisesPayment, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.totalPromisesPaymentAmount))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "TotalPromisesPaymentAmount", FieldValue = model.totalPromisesPaymentAmount, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.avarageTicket))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "AvarageTicket", FieldValue = model.avarageTicket, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.promisesPerHour))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "PromisesPerHour", FieldValue = model.promisesPerHour, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.percentagePromises))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "PercentagePromises", FieldValue = model.percentagePromises, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.bucket))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "Bucket", FieldValue = model.bucket, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.occupancyKPI))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "OccupancyKPI", FieldValue = model.occupancyKPI, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.ahtTMO))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "AhtTMO", FieldValue = model.ahtTMO, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.qaKPI))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "QaKPI", FieldValue = model.qaKPI, FieldType = "string" });

            if (!string.IsNullOrEmpty(model.contactEfectiveness))
                details.Add(new ParticipantDetail { CampaignId = campaignId, AreaName = area, ParticipantName = participant, ParticipantSectionName = participantName, TitleName = "ContactEfectiveness", FieldValue = model.contactEfectiveness, FieldType = "string" });

            return details;
        }

        private GeneralModel MapParticipantDetailsToModel(List<ParticipantDetail> details)
        {
            var model = new GeneralModel();

            foreach (var detail in details)
            {
                switch (detail.TitleName)
                {
                    case "IsSell":
                        model.isSell = bool.Parse(detail.FieldValue);
                        break;
                    case "IsATC":
                        model.isATC = bool.Parse(detail.FieldValue);
                        break;
                    case "IsCollection":
                        model.isCollection = bool.Parse(detail.FieldValue);
                        break;
                    case "Other":
                        model.other = detail.FieldValue;
                        break;
                    case "TypeInteraction":
                        model.typeInteraction = detail.FieldValue;
                        break;
                    case "Voice":
                        model.voice = bool.Parse(detail.FieldValue);
                        break;
                    case "Sms":
                        model.sms = bool.Parse(detail.FieldValue);
                        break;
                    case "Email":
                        model.email = bool.Parse(detail.FieldValue);
                        break;
                    case "WhatsApp":
                        model.whatsApp = bool.Parse(detail.FieldValue);
                        break;
                    case "Facebook":
                        model.facebook = bool.Parse(detail.FieldValue);
                        break;
                    case "Blaster":
                        model.blaster = bool.Parse(detail.FieldValue);
                        break;
                    case "VoiceBot":
                        model.voiceBot = bool.Parse(detail.FieldValue);
                        break;
                    case "VoiceBotType":
                        model.voiceBotType = detail.FieldValue;
                        break;
                    case "ChatBot":
                        model.chatBot = bool.Parse(detail.FieldValue);
                        break;
                    case "ChatBotType":
                        model.chatBotType = detail.FieldValue;
                        break;
                    case "OtherChannel":
                        model.otherChannel = detail.FieldValue;
                        break;
                    case "MainActivitiesOne":
                        model.mainActivitiesOne = detail.FieldValue;
                        break;
                    case "MainActivitiesTwo":
                        model.mainActivitiesTwo = detail.FieldValue;
                        break;
                    case "MainActivitiesThree":
                        model.mainActivitiesThree = detail.FieldValue;
                        break;
                    case "NumberStations":
                        model.numberStations = int.TryParse(detail.FieldValue, out var stations) ? stations : new int();
                        break;
                    case "StartDate":
                        model.startDate = DateOnly.TryParse(detail.FieldValue, out var startDate) ? startDate : new DateOnly();
                        break;
                    case "PocClient":
                        model.pocClient = detail.FieldValue;
                        break;
                    // WFM Section
                    case "TimeFrameAttentionOne":
                        model.timeFrameAttentionOne = detail.FieldValue;
                        break;
                    case "TimeFrameAttentionTwo":
                        model.timeFrameAttentionTwo = detail.FieldValue;
                        break;
                    case "TimeFrameAttentionThree":
                        model.timeFrameAttentionThree = detail.FieldValue;
                        break;
                    case "PublicHoliday":
                        model.publicHoliday = detail.FieldValue;
                        break;
                    case "NumberStationsWFM":
                        model.numberStationsWFM = int.TryParse(detail.FieldValue, out var stationsWFM) ? stationsWFM : (int?)null;
                        break;
                    case "Cities":
                        model.cities = detail.FieldValue;
                        break;
                    case "Sites":
                        model.sites = detail.FieldValue;
                        break;
                    case "InteractionPerDays":
                        model.interactionPerDays = int.TryParse(detail.FieldValue, out var interactionDays) ? interactionDays : (int?)null;
                        break;
                    case "InteractionPerMonths":
                        model.interactionPerMonths = int.TryParse(detail.FieldValue, out var interactionMonths) ? interactionMonths : (int?)null;
                        break;
                    case "RatioAgentsSupervisors":
                        model.ratioAgentsSupervisors = detail.FieldValue;
                        break;
                    case "RatioAgentsCoordinators":
                        model.ratioAgentsCoordinators = detail.FieldValue;
                        break;
                    case "RatioAgentsQA":
                        model.ratioAgentsQA = detail.FieldValue;
                        break;
                    case "ServiceLevel":
                        model.serviceLevel = detail.FieldValue;
                        break;
                    case "Aba":
                        model.aba = detail.FieldValue;
                        break;
                    case "Asa":
                        model.asa = detail.FieldValue;
                        break;
                    case "Aht":
                        model.aht = detail.FieldValue;
                        break;
                    case "Occupancy":
                        model.occupancy = detail.FieldValue;
                        break;
                    case "Adherence":
                        model.adherence = detail.FieldValue;
                        break;
                    case "Fcr":
                        model.fcr = detail.FieldValue;
                        break;
                    case "Qa":
                        model.qa = detail.FieldValue;
                        break;
                    case "Nps":
                        model.nps = detail.FieldValue;
                        break;
                    case "Csat":
                        model.csat = detail.FieldValue;
                        break;
                    case "TotalPromisesPayment":
                        model.totalPromisesPayment = detail.FieldValue;
                        break;
                    case "TotalPromisesPaymentAmount":
                        model.totalPromisesPaymentAmount = detail.FieldValue;
                        break;
                    case "AvarageTicket":
                        model.avarageTicket = detail.FieldValue;
                        break;
                    case "PromisesPerHour":
                        model.promisesPerHour = detail.FieldValue;
                        break;
                    case "PercentagePromises":
                        model.percentagePromises = detail.FieldValue;
                        break;
                    case "Bucket":
                        model.bucket = detail.FieldValue;
                        break;
                    case "OccupancyKPI":
                        model.occupancyKPI = detail.FieldValue;
                        break;
                    case "AhtTMO":
                        model.ahtTMO = detail.FieldValue;
                        break;
                    case "QaKPI":
                        model.qaKPI = detail.FieldValue;
                        break;
                    case "ContactEfectiveness":
                        model.contactEfectiveness = detail.FieldValue;
                        break;
                }
            }

            return model;
        }


    }
}
