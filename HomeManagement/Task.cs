using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Domain
{
    public class Task : IValidatableObject
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime DateEntered { get; set; }

        public virtual DateTime? DateAssigned { get; set; }
        public virtual DateTime? DateCompleted { get; set; }
        public virtual bool Completed { get; set; }

        public virtual int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Completed && PersonId == null && Person == null)
            {
                yield return new ValidationResult("Task cannot be completed without an assigned person", new[] { "Completed" });
            }
        }
    }

    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }


        public virtual ICollection<Task> Tasks { get; set; }
    }
}