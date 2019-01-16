namespace eMMA.Entities
{
    public class SeminarInstance : IPractical
    {
        public SeminarInstance()
        {
            //EF needs this
            this.UniClassType = UniClassType.Seminar;
        }
    }
}
