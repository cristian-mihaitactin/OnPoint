namespace eMMA.Entities
{
    public class CourseInstance : IUniClass
    {
        public CourseInstance()
        {
            //EF needs this
            this.UniClassType = UniClassType.Course;
        }
    }
}
