using Newtonsoft.Json;

namespace YandexDeliveryAPI.Services.Models
{
    public sealed class Answer<T> : AnswereBasic
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        public Answer()
        {
            base.AnswerId = 0L;
            base.AnswerMessage = "default";
            base.AnswerComment = "";
        }

        public Answer(long inAnswereId, string inAnswereMessage, string inAnswereComment)
        {
            base.AnswerId = inAnswereId;
            base.AnswerMessage = inAnswereMessage;
            base.AnswerComment = inAnswereComment;
        }

        public Answer(long inAnswereId, string inAnswereMessage)
        {
            base.AnswerId = inAnswereId;
            base.AnswerMessage = (base.AnswerComment = inAnswereMessage);
        }

        public Answer(long inAnswereId, string inAnswereMessage, string inAnswereComment, T inData)
        {
            base.AnswerId = inAnswereId;
            base.AnswerMessage = inAnswereMessage;
            base.AnswerComment = inAnswereComment;
            Data = inData;
        }

        public Answer(T inData)
        {
            base.AnswerId = 1L;
            base.AnswerMessage = "Ok";
            base.AnswerComment = "";
            Data = inData;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
