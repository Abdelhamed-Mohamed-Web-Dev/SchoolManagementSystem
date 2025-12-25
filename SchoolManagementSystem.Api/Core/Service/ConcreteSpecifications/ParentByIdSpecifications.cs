using Domain.Entities;

namespace Service.ConcreteSpecifications
{
    public class ParentByIdSpecifications : Specifications<Parent>
    {
        public ParentByIdSpecifications(int id) : base(p => p.Id == id)
        {
            //AddInclude(p => p.ParentStudents);
            //// include students for linking/unlinking operations
            //AddInclude(p => p.ParentStudents.Select(ps => ps.Student));
        }
    }
}
