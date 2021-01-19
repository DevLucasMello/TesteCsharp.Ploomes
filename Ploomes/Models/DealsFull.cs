using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ploomes
{
    public class ValueDeals
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public object PersonId { get; set; }
        public object PersonName { get; set; }
        public int PipelineId { get; set; }
        public int StageId { get; set; }
        public int StatusId { get; set; }
        public object FirstTaskId { get; set; }
        public DateTime? FirstTaskDate { get; set; }
        public bool HasScheduledTasks { get; set; }
        public int TasksOrdination { get; set; }
        public object ContactProductId { get; set; }
        public object LastQuoteId { get; set; }
        public bool IsLastQuoteApproved { get; set; }
        public object WonQuoteId { get; set; }
        public object LastStageId { get; set; }
        public object LossReasonId { get; set; }
        public object OriginId { get; set; }
        public object OwnerId { get; set; }
        public DateTime StartDate { get; set; }
        public object FinishDate { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public int StartCurrencyId { get; set; }
        public decimal StartAmount { get; set; }
        public bool Read { get; set; }
        public object LastInteractionRecordId { get; set; }
        public object LastOrderId { get; set; }
        public int DaysInStage { get; set; }
        public int HoursInStage { get; set; }
        public int Length { get; set; }
        public object CreateImportId { get; set; }
        public object UpdateImportId { get; set; }
        public object LeadId { get; set; }
        public object OriginDealId { get; set; }
        public object ReevId { get; set; }
        public bool Editable { get; set; }
        public bool Deletable { get; set; }
        public int CreatorId { get; set; }
        public object UpdaterId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public object LastDocumentId { get; set; }
        public object DealNumber { get; set; }
    }

    public class DealsFull
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<ValueDeals> value { get; set; }
    }
}
