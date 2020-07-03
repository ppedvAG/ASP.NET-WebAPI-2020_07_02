using System.Collections.Generic;

namespace _011_Shared.ViewModels
{
    public class StandardViewModel
    {
        public int StandardId { get; set; }
        public string Name { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}