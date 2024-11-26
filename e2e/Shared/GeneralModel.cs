using System.ComponentModel.DataAnnotations;

namespace e2e.Shared
{
    public sealed class GeneralModel
    {
        
        public bool?  isSell { get; set; } = new bool();
        
        public bool?  isATC { get; set; } = new bool();
        
        public bool?  isCollection { get; set; } = new bool();
        
        public string?  other { get; set; } = string.Empty;
        
        public string?  typeInteraction { get; set; } = string.Empty;
        
        public bool?  voice { get; set; } = new bool();
        
        public bool?  sms { get; set; } = new bool();
        
        public bool?  email { get; set; } = new bool();
        
        public bool?  whatsApp { get; set; } = new bool();
        
        public bool?  facebook { get; set; } = new bool();
        
        public bool?  blaster { get; set; } = new bool();
        
        public bool?  voiceBot { get; set; } = new bool();
        
        public string?  voiceBotType { get; set; } = string.Empty;
        
        public bool?  chatBot { get; set; } = new bool();
        
        public string? chatBotType { get; set; } = string.Empty;
        
        public string?  otherChannel { get; set; } = string.Empty;
        
        public string?  mainActivitiesOne { get; set; } = string.Empty;
        
        public string?  mainActivitiesTwo { get; set; } = string.Empty;
        
        public string?  mainActivitiesThree { get; set; } = string.Empty;
        
        public int?  numberStations { get; set; } = 0;
        
        public DateOnly?  startDate { get; set; } = new DateOnly();
        
        public string?  pocClient { get; set; } = string.Empty;

        /*
         * WFM Section
         */
        
        public string? timeFrameAttentionOne { get; set; } = string.Empty;
        
        public string? timeFrameAttentionTwo { get; set; } = string.Empty;
        
        public string? timeFrameAttentionThree { get; set; } = string.Empty;
        
        public string? publicHoliday { get; set; } = string.Empty;
        
        public int? numberStationsWFM { get; set; }
        
        public string? cities { get; set; } = string.Empty;
        
        public string? sites { get; set; } = string.Empty;
        
        public int? interactionPerDays { get; set; }
        
        public int? interactionPerMonths { get; set; }
        
        public string? ratioAgentsSupervisors { get; set; } = string.Empty;
        
        public string? ratioAgentsCoordinators { get; set; } = string.Empty;
        
        public string? ratioAgentsQA { get; set; } = string.Empty;
        
        public string? serviceLevel { get; set; } = string.Empty;
        
        public string? aba { get; set; } = string.Empty;
        
        public string? asa { get; set; } = string.Empty;
        
        public string? aht { get; set; } = string.Empty;
        
        public string? occupancy { get; set; } = string.Empty;
        
        public string? adherence { get; set; } = string.Empty;
        
        public string? fcr { get; set; } = string.Empty;
        
        public string? qa { get; set; } = string.Empty;
        
        public string? nps { get; set; } = string.Empty;
        
        public string? csat { get; set; } = string.Empty;
        
        public string? totalPromisesPayment { get; set; } = string.Empty;
        
        public string? totalPromisesPaymentAmount { get; set; } = string.Empty;
        
        public string? avarageTicket { get; set; } = string.Empty;
        
        public string? promisesPerHour { get; set; } = string.Empty;
        
        public string? percentagePromises { get; set; } = string.Empty;
        
        public string? bucket { get; set; } = string.Empty;
        
        public string? occupancyKPI { get; set; } = string.Empty;
        
        public string? ahtTMO { get; set; } = string.Empty;
        
        public string? qaKPI { get; set; } = string.Empty;
        
        public string? contactEfectiveness { get; set; } = string.Empty;
    }
}
