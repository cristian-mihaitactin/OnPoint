namespace eMMA.Entities
{
    public class LaboratoryInstance : IPractical
    {
        public LaboratoryInstance()
        {
            //EF needs this
            this.UniClassType = UniClassType.Lab;

        }
    }
}
